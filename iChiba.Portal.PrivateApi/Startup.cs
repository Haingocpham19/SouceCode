using AutoMapper;
using Core.Cache.Redis.Implement;
using Core.Cache.Redis.Interface;
using Core.Common;
using Core.CQRS.Bus.Implements.RabitMq;
using Core.CQRS.Bus.Interfaces.RabitMq;
using Core.Elasticsearch;
using Core.Repository.Abstract;
using Core.Repository.Interface;
using Core.Resilience.Http;
using DinkToPdf;
using DinkToPdf.Contracts;
using iChiba.DC.DbContext;
using iChiba.IS4.Api.Driver;
using iChiba.OM.DbContext;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppService.Implement;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.WH.DbContext;
using iChiba.Portal.PrivateApi.Configs;
using iChiba.Portal.PrivateApi.Driver;
using Ichiba.Cdn.Client.Implement;
using Ichiba.Cdn.Client.Implement.Configs;
using Ichiba.Cdn.Client.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Redis.Implement;
using iChiba.Portal.PrivateApi.AppService.Implement.Concurrent;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Repository.Implement;
using iChiba.OM.Service.Interface;
using iChiba.OM.Service.Implement;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Repository.Implement;
using iChiba.WH.Service.Implement;
using iChiba.WH.Service.Interface;
using iChiba.Portal.Service.Implement;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PrivateApi
{
    public class DateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LoadConfig();
        }

        private void LoadConfig()
        {
            var configurationRoot = (ConfigurationRoot)Configuration;
            var configurationProviders = configurationRoot
                .Providers
                .Where(p => p.GetType() == typeof(JsonConfigurationProvider)
                    && ((JsonConfigurationProvider)p).Source.Path.StartsWith("appsettings"));

            foreach (var item in configurationProviders)
            {
                ConfigSetting.Init<ConfigSettingDefine>(item);
                ConfigSetting.Init<RedisConnectionConfig>(item);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;

                cfg.AddProfile<AdapterProfile>();
            });

            services
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                })
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "PCS portal private api documents",
                        Version = "v1"
                    });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });

                    c.CustomSchemaIds(x => x.FullName);
                })
                .AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(option =>
                    {
                        option.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    });

            services.AddControllers();
            services.AddRouting();
            services.AddHealthChecks();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region Add DI

            services.Configure<AuthorizeConfig>(Configuration.GetSection("Authorize"));
            services.Configure<FileUploadConfig>(Configuration.GetSection("FileStorage"));
            services.Configure<ElasticConnectionSetting>(Configuration.GetSection("ElasticConnectionSettings"));
            services.Configure<RabbitMqConnectionConfig>(Configuration.GetSection("RabbitMq:Connection"));

            services.AddSingleton<IRabbitMqPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMqPersistentConnection>>();
                var connectionConfig = sp.GetRequiredService<IOptions<RabbitMqConnectionConfig>>().Value;
                var factory = new ConnectionFactory
                {
                    HostName = connectionConfig.HostName,
                    UserName = connectionConfig.UserName,
                    Password = connectionConfig.Password
                };

                return new DefaultRabbitMqPersistentConnection(factory, logger);
            });

            //services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(ConfigSettingDefine.DbiChibaAccConnectionString.GetConfig()), ServiceLifetime.Transient);
            services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(ConfigSettingDefine.DbiChibaAccConnectionString.GetConfig()));
            services.AddScoped<IUnitOfWork, UnitOfWork<CustomerDBContext>>();

            services.AddDbContext<DATA_COMMONContext>(options => options.UseSqlServer(ConfigSettingDefine.DbDataCommonConnectionString.GetConfig()));
            services.AddScoped<IUnitOfWorkGeneric<DATA_COMMONContext>, UnitOfWork<DATA_COMMONContext>>();

            services.AddDbContext<WarehouseDBContext>(options => options.UseSqlServer(ConfigSettingDefine.DbWarehouseConnectionString.GetConfig()));
            services.AddScoped<IUnitOfWorkGeneric<WarehouseDBContext>, UnitOfWork<WarehouseDBContext>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentContext, CurrentContext>();
            services.AddTransient<IFileAppService, FileAppService>();
            services.AddTransient<IFileStorage, FileStorage>();
            services.AddSingleton<ElasticClientProvider<ElasticConnectionSetting>>();
            services.AddTransient<ElasticIndexer<ElasticConnectionSetting>>();
            services.AddTransient<IRedisStorage, RedisStorage>();

            #region Services / Jobs

            //services.AddHostedService<TimedHostedService>();
            //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
            //services.AddScoped<ClientIpFilters>();

            #endregion

            #region WH event

            //services.Configure<WhEventRabbitMqConfig>(Configuration.GetSection("RabbitMq:Event:Wh"));

            //services.AddSingleton(sp =>
            //{
            //    var rabbitMqConfig = sp.GetRequiredService<IOptions<WhEventRabbitMqConfig>>().Value;

            //    return new WhEventRabbitMqConfig()
            //    {
            //        Environment = rabbitMqConfig.Environment,
            //        BrokerName = rabbitMqConfig.BrokerName,
            //        RoutingKey = rabbitMqConfig.RoutingKey,
            //        QueueName = rabbitMqConfig.QueueName
            //    };
            //});

            //services.AddTransient<WhEventAppService>();
            //services.AddTransient<IEventSender<WhEventRabbitMqConfig>, EventSender<WhEventRabbitMqConfig>>();
            //services.AddSingleton<IEventBus<WhEventRabbitMqConfig>, EventBusRabbitMq<WhEventRabbitMqConfig>>();

            #endregion

            #region Concurrent

            services.AddSingleton<CodeConcurrentManager>();

            #endregion

            #region Ichiba.Partner.Api.Driver

            services.Configure<Ichiba.Partner.Api.Driver.ProductFromUrlConfig>(Configuration.GetSection("PartnerApi:ProductFromUrlConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<Ichiba.Partner.Api.Driver.ProductFromUrlConfig>>().Value);
            services.AddSingleton<Ichiba.Partner.Api.Driver.IAuthorizeClient, AuthorizeClientImplement>();
            services.AddSingleton<Ichiba.Partner.Api.Driver.ProductFromUrlClient>();

            #endregion Ichiba.Partner.Api.Driver

            #region AspNetUserCache
            services.AddTransient<IAspNetUserCache, AspNetUserCache>();
            services.AddSingleton<IAuthorizeClient, AuthorizeClientImplement>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            #region Access

            services.Configure<AccessConfig>(Configuration.GetSection("IS4:AccessConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<AccessConfig>>().Value);
            services.AddTransient<IAccessAppService, AccessAppService>();
            services.AddSingleton<IS4.Api.Driver.IAuthorizeClient, Is4AuthorizeClientImplement>();
            services.AddTransient<AccessClient>();

            #endregion

            #region CodImport
            services.AddTransient<ICodImportRepository, CodImportRepository>();
            services.AddTransient<ICodImportService, CodImportService>();
            #endregion

            #region Supplier
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();
            #endregion

            #region IWarehouseService
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            #endregion

            #region IShippingRoute
            services.AddTransient<IShippingRouteRepository, ShippingRouteRepository>();
            services.AddTransient<IShippingRouteService, ShippingRouteService>();
            #endregion

            #region IShippingRouteWarehouse
            services.AddTransient<IShippingRouteWarehouseRepository, ShippingRouteWarehouseRepository>();
            services.AddTransient<IShippingRouteWarehouseService, ShippingRouteWarehouseService>();
            #endregion

            #region IOrderServiceService
            services.AddTransient<IOrderServiceRepository, OrderServiceRepository>();
            services.AddTransient<IOrderServiceService, OrderServiceService>();
            #endregion

            #region Customer
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerAppService, CustomerAppService>();
            #endregion

            #region CustomerAddress
            services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();
            services.AddTransient<ICustomerAddressService, CustomerAddressService>();
            services.AddTransient<ICustomerAddressAppService, CustomerAddressAppService>();
            #endregion

            #region Order
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            #endregion

            #region OrderDetail
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            #endregion

            #region OrderPackage
            services.AddTransient<IOrderPackageRepository, OrderPackageRepository>();
            services.AddTransient<IOrderPackageService, OrderPackageService>();
            services.AddTransient<IOrderPackageAppService, OrderPackageAppService>();
            #endregion

            #region OrderPackageProduct
            services.AddTransient<IOrderPackageProductRepository, OrderPackageProductRepository>();
            services.AddTransient<IOrderPackageProductService, OrderPackageProductService>();
            #endregion

            #region ProductType
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            #endregion

            #region ProductTypeGroup
            services.AddTransient<IProductTypeGroupRepository, ProductTypeGroupRepository>();
            services.AddTransient<IProductTypeGroupService, ProductTypeGroupService>();
            #endregion

            #region OrderMessage

            services.AddTransient<IOrderMessageRepository, OrderMessageRepository>();
            services.AddTransient<IOrderMessageService, OrderMessageService>();

            #endregion

            #region Payment
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentAppService, PaymentAppService>();
            #endregion

            #region Deposits
            services.AddTransient<IDepositsRepository, DepositsRepository>();
            services.AddTransient<IDepositsService, DepositsService>();
            #endregion

            #region Freeze
            services.AddTransient<IFreezeRepository, FreezeRepository>();
            services.AddTransient<IFreezeService, FreezeService>();
            #endregion

            #region Withdrawal
            services.AddTransient<IWithdrawalRepository, WithdrawalRepository>();
            services.AddTransient<IWithdrawalService, WithdrawalService>();
            #endregion

            #region CustomerWallet
            services.AddTransient<ICustomerWalletRepository, CustomerWalletRepository>();
            services.AddTransient<ICustomerWalletService, CustomerWalletService>();
            services.AddTransient<ICustomerWalletAppService, CustomerWalletAppService>();
            #endregion

            #region ApiClient

            services.Configure<iChiba.WH.Api.Driver.WhApiConfig>(Configuration.GetSection("WhApi"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<iChiba.WH.Api.Driver.WhApiConfig>>().Value);
            services.AddSingleton<IAuthorizeClient, WhAuthorizeClientImplement>();
            services.AddTransient<iChiba.WH.Api.Driver.ApiWhClient>();

            #endregion

            #region OrderServiceMapping
            services.AddTransient<IOrderServiceMappingRepository, OrderServiceMappingRepository>();
            services.AddTransient<IOrderServiceMappingService, OrderServiceMappingService>();
            #endregion

            #region Package
            services.AddTransient<IPackageRepository, PackageRepository>();
            services.AddTransient<IPackageService, PackageService>();
            #endregion

            #region PackageDetail
            services.AddTransient<IPackageDetailRepository, PackageDetailRepository>();
            services.AddTransient<IPackageDetailService, PackageDetailService>();
            #endregion

            #region PackageDetailQuote
            services.AddTransient<IPackageDetailQuoteRepository, PackageDetailQuoteRepository>();
            services.AddTransient<IPackageDetailQuoteService, PackageDetailQuoteService>();
            services.AddTransient<IPackageDetailQuoteAppService, PackageDetailQuoteAppService>();
            #endregion

            #region Shipment
            services.AddTransient<IShipmentStatusHistoryRepository, ShipmentStatusHistoryRepository>();
            services.AddTransient<IShipmentStatusHistoryService, ShipmentStatusHistoryService>();
            #endregion

            #region Product
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            #endregion

            #region ProductFromUrl
            services.AddTransient<IProductFromUrlAppService, ProductFromUrlAppService>();
            #endregion

            #region Flight
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IFlightService, FlightService>();
            #endregion

            #region SyncData
            services.AddTransient<ISyncDataService, SyncDataService>();
            services.AddTransient<ISyncDataRepository, SyncDataRepository>();
            #endregion

            #region WarehouseApp
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddTransient<IWarehouseAppService, WarehouseAppService>();
            #endregion

            #region OrderPurchaseLog
            services.AddTransient<IOrderPurchaseLogRepository, OrderPurchaseLogRepository>();
            services.AddTransient<IOrderPurchaseLogService, OrderPurchaseLogService>();
            #endregion

            #region OrderPurchase
            services.AddTransient<IOrderPurchaseRepository, OrderPurchaseRepository>();
            services.AddTransient<IOrderPurchaseService, OrderPurchaseService>();
            #endregion

            #region ServiceCharge
            services.AddTransient<IServiceChargeRepository, ServiceChargeRepository>();
            services.AddTransient<IServiceChargeService, ServiceChargeService>();
            services.AddTransient<IServiceChargeAppService, ServiceChargeAppService>();
            #endregion

            #region CustomerProfile
            services.AddTransient<ICustomerProfileRepository, CustomerProfileRepository>();
            services.AddTransient<ICustomerProfileService, CustomerProfileService>();
            #endregion

            #region LevelService
            services.AddTransient<ILevelRepository, LevelRepository>();
            services.AddTransient<ILevelService, LevelService>();
            #endregion

            #region ExchangeratesService
            services.AddTransient<IExchangeratesCache, ExchangeratesCache>();
            services.AddTransient<IExchangeratesService, ExchangeratesService>();
            services.AddTransient<IExchangeratesAppService, ExchangeratesAppService>();
            #endregion

            #region EmployeeAppService
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeAppService, EmployeeAppService>();
            #endregion

            #region ShoppingCartCache
            services.AddTransient<IShoppingCartCache, ShoppingCartCache>();
            #endregion

            #region ExcelService
            services.AddTransient<IExportExcelAppService, ExportExcelAppService>();
            #endregion

            #region UploadFile
            services.AddTransient<IUploadFileAppService, UploadFileAppService>();
            #endregion

            #region config DI to API
            var serviceProvider = services.BuildServiceProvider();
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    var authorizeConfig = serviceProvider.GetRequiredService<IOptions<AuthorizeConfig>>();
                    options.Authority = authorizeConfig.Value.Issuer;
                    options.RequireHttpsMetadata = authorizeConfig.Value.RequireHttpsMetadata;
                    options.ApiName = authorizeConfig.Value.ApiName;
                });

            services.AddSingleton<IResilientHttpClientFactory, ResilientHttpClientFactory>(sp =>
            {
                const int retryCount = 3;
                const int exceptionsAllowedBeforeBreaking = 5;
                //var logger = sp.GetRequiredService<ILogger<ResilientHttpClient>>();

                return new ResilientHttpClientFactory(null, exceptionsAllowedBeforeBreaking, retryCount);
            });
            services.AddSingleton<IHttpClient, ResilientHttpClient>(sp => sp.GetService<IResilientHttpClientFactory>().CreateResilientHttpClient());
            #endregion



            #endregion Add DI
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //var appConfig = Configuration.GetSection("ElasticApm").Get<ElasticApmConfig>();
            //if (appConfig.Active)
            //    app.UseAllElasticApm(Configuration);

            #region Log

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Warning)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Configuration["ElasticConnectionSettings:ClusterUrl"]))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "log-wh-private-api-{0:yyyy.MM.dd}",
                    TemplateName = "serilog-events-template",
                    TypeName = "WHPrivateApiType"
                })
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .WriteTo.RollingFile(@"./logs/log-{Date}.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .CreateLogger();
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }
            app.UseStaticFiles(); // For the wwwroot folder
            //app.UseRequestResponseLogging();
            //app.UseMiddleware<SafeListMiddleware>(Configuration["SafeList"]);
            app.UseCors("CorsPolicy")
                .UseAuthentication()
                .UseRouting()
                .UseStaticFiles()
                .UseAuthorization()
                .UseEndpoints(endpoint =>
                {
                    endpoint.MapControllers();
                })
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PCS portal private api");
                    c.DocumentTitle = "PCS portal private api documents";
                });
            app.UseHealthChecks("/health");
        }
    }
}
