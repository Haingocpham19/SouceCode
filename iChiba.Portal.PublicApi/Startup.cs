using AutoMapper;
using Core.Cache.Redis.Implement;
using Core.Cache.Redis.Interface;
using Core.Common;
using Core.CQRS.Bus.Implements.RabitMq;
using Core.Elasticsearch;
using Core.Resilience.Http;
using iChiba.Portal.Common;
using Ichiba.Cdn.Client.Implement;
using Ichiba.Cdn.Client.Implement.Configs;
using Ichiba.Cdn.Client.Interface;
using iChibaShopping.Core.AppService.Implement;
using iChibaShopping.Core.AppService.Interface;
using iChiba.Portal.PublicApi.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.Index.Elasticsearch.Implement;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.PublicApi.AppService.Implement;
using iChiba.Portal.Cache.Redis.Implement;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Index.Interface;
using Core.CQRS.Service.Implements;
using Core.CQRS.Service.Interfaces;
using Core.CQRS.Bus.Interfaces;
using System;
using Core.CQRS.Bus.Interfaces.RabitMq;
using RabbitMQ.Client;
using iChiba.Portal.PublicApi.Controllers;
using System.Net.Http;
using Elastic.Apm.NetCoreAll;
using iChiba.Portal.Common.Configuration;
using iChiba.Portal.Common.Helpers;
using iChiba.Portal.PublicApi.AppService.Implement.Common;
using iChiba.Portal.PublicApi.Driver;
using iChiba.Portal.Service.Implement;
using iChiba.Portal.Service.Interface;
using iChiba.Portal.PublicApi.Driver.Interface;
using iChiba.Portal.PublicApi.Driver.Implement;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace iChiba.Portal.PublicApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;

            LoadConfig();

            Spire.License.LicenseProvider.SetLicenseKey(SpireHelper.LicenseKey);
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
            services.AddHttpContextAccessor();
            services.AddOptions();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddMemoryCache();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddControllersAsServices();

            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "iChiba web public api",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            });

            services.AddAutoMapper();

            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;

                cfg.AddProfile<AdapterProfile>();
            });

            #region Add DI

            # region config
            services.Configure<AuthorizeConfig>(Configuration.GetSection("Authorize"));
            services.Configure<FileUploadConfig>(Configuration.GetSection("FileStorage"));
            services.Configure<NewsElasticConnectionSetting>(Configuration.GetSection("ElasticConnectionSettings:News"));
            services.Configure<RabbitMqConnectionConfig>(Configuration.GetSection("RabbitMq:Connection"));

            services.Configure<CustomerConfig>(Configuration.GetSection("Api:CustomerConfig"));
            services.Configure<CS.PublicApi.Driver.CustomerConfig>(Configuration.GetSection("Api:CustomerConfig"));
            services.Configure<CustomerAddressConfig>(Configuration.GetSection("Api:CustomerAddressConfig"));
            services.Configure<BankinfoConfig>(Configuration.GetSection("Api:BankinfoConfig"));
            services.Configure<CustomerBankinfoConfig>(Configuration.GetSection("Api:CustomerBankinfoConfig"));
            services.Configure<CustomerWarehouseConfig>(Configuration.GetSection("Api:CustomerWarehouseConfig"));
            services.Configure<OrderTransportConfig>(Configuration.GetSection("Api:OrderTransportConfig"));
            services.Configure<WarehouseConfig>(Configuration.GetSection("Api:WarehouseConfig"));
            services.Configure<AccountConfig>(Configuration.GetSection("Api:AccountConfig"));
            services.Configure<BankicConfig>(Configuration.GetSection("Api:BankIc:BankicConfig"));
            services.Configure<AppConfig>(Configuration.GetSection("App"));
            services.Configure<NotifyApiUriConfig>(Configuration.GetSection("Api:Notify:Uris"));
            services.Configure<FcmCustomerConfig>(Configuration.GetSection("Fcm:Customer"));
            services.Configure<DdimportConfig>(Configuration.GetSection("Api:DdimportConfig"));
            services.Configure<OrderServiceConfig>(Configuration.GetSection("Api:OrderServiceConfig"));
            services.Configure<OrderConfig>(Configuration.GetSection("Api:OrderConfig"));
            services.Configure<CS.PublicApi.Driver.OrderConfig>(Configuration.GetSection("Api:OrderConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<CS.PublicApi.Driver.OrderConfig>>().Value);
            services.Configure<DepositConfig>(Configuration.GetSection("Api:DepositConfig"));
            services.Configure<WithDrawalConfig>(Configuration.GetSection("Api:WithDrawalConfig"));
            services.Configure<FreezeCsConfig>(Configuration.GetSection("Api:FreezeCsConfig"));
            services.Configure<OrderDeliverybillConfig>(Configuration.GetSection("Api:OrderDeliverybillConfig"));
            services.Configure<PaymentConfig>(Configuration.GetSection("Api:PaymentConfig"));
            services.Configure<TrackingOrderConfig>(Configuration.GetSection("Api:TrackingOrderConfig"));
            services.Configure<LevelTransportGroupConfig>(Configuration.GetSection("Api:LevelTransportGroupConfig"));
            services.Configure<TrackConfig>(Configuration.GetSection("Api:TrackConfig"));

            #region BuyFeeDiscount

            services.Configure<BuyFeeDiscountConfig>(Configuration.GetSection("BuyFeeDiscountConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<BuyFeeDiscountConfig>>().Value);

            #endregion BuyFeeDiscount
            #endregion config

            services.AddSingleton<IResilientHttpClientFactory, ResilientHttpClientFactory>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<ResilientHttpClient>>();
                var retryCount = 0;
                var exceptionsAllowedBeforeBreaking = 5;

                return new ResilientHttpClientFactory(logger, exceptionsAllowedBeforeBreaking, retryCount);
            });
            services.AddSingleton<IHttpClient, ResilientHttpClient>(sp => sp.GetService<IResilientHttpClientFactory>().CreateResilientHttpClient());
            //services.AddDataProtection()
            //    .SetApplicationName("DataProtectionRedisKey")
            //    .PersistKeysToStackExchangeRedis(RedisConnection.Current.GetWriteConnection, "DataProtectionRedisKey");
            services.AddSingleton<HttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentContext, CurrentContext>();
            services.AddTransient<IFileAppService, FileAppService>();
            services.AddTransient<IFileStorage, FileStorage>();
            services.AddSingleton<ElasticClientProvider<ElasticConnectionSetting>>();
            services.AddTransient<ElasticIndexer<ElasticConnectionSetting>>();
            services.AddTransient<ElasticIndexer<NewsElasticConnectionSetting>>();
            services.AddTransient<ElasticClientProvider<NewsElasticConnectionSetting>>();
            services.AddTransient<IRedisStorage, RedisStorage>();


            services.AddTransient<CS.PublicApi.Driver.IAuthorizeClient, AuthorizeCSPrivateClientImplement>();
            services.AddTransient<CS.PublicApi.Driver.OrderClient>();
            services.AddTransient<CS.PublicApi.Driver.CustomerClient>();
            services.AddTransient<CS.PublicApi.Driver.ProofPaymentClient>();

            #region notify
            services.Configure<CS.PublicApi.Driver.NotifyConfigUrl>(Configuration.GetSection("Api:Notify"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<CS.PublicApi.Driver.NotifyConfigUrl>>().Value);
            services.AddTransient<CS.PublicApi.Driver.NotifyClient>();
            services.AddTransient<INotifyAppService, NotifyAppService>();
            #endregion notify

            //Authorize
            services.AddTransient<AuthorizeClient, AuthorizeClientImplement>();

            services.AddTransient<IWebLinkGroupService, WebLinkGroupService>();
            services.AddTransient<IWebLinkGroupAppService, WebLinkGroupAppService>();
            services.AddTransient<IWebLinkService, WebLinkService>();
            services.AddTransient<IWebLinkCache, WebLinkCache>();
            services.AddTransient<IWebLinkGroupCache, WebLinkGroupCache>();

            services.AddTransient<IAdvBannerCache, AdvBannerCache>();
            services.AddTransient<IAdvBannerService, AdvBannerService>();
            services.AddTransient<IAdvBannerAppService, AdvBannerAppService>();

            services.AddTransient<IAboutCache, AboutCache>();
            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IAboutAppService, AboutAppService>();

            services.AddTransient<ICategoryNewsCache, CategoryNewsCache>();
            services.AddTransient<ICategoryNewsService, CategoryNewsService>();
            services.AddTransient<ICategoryNewsAppService, CategoryNewsAppService>();

            services.AddTransient<IGuidelinesCache, GuidelinesCache>();
            services.AddTransient<IGuidelinesService, GuidelinesService>();
            services.AddTransient<IGuidelinesAppService, GuidelinesAppService>();

            services.AddTransient<IPolicyCache, PolicyCache>();
            services.AddTransient<IPolicyService, PolicyService>();
            services.AddTransient<IPolicyAppService, PolicyAppService>();

            services.AddTransient<IRecruitmentCache, RecruitmentCache>();
            services.AddTransient<IRecruitmentService, RecruitmentService>();
            services.AddTransient<IRecruitmentAppService, RecruitmentAppService>();

            services.AddTransient<INewsIndex, NewsIndex>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsAppService, NewsAppService>();

            services.AddTransient<IGroupGuidelinesCache, GroupGuidelinesCache>();
            services.AddTransient<IGroupGuidelinesService, GroupGuidelinesService>();
            services.AddTransient<IGroupGuidelinesAppService, GroupGuidelinesAppService>();

            services.AddTransient<ICategoryServiceCache, CategoryServiceCache>();
            services.AddTransient<ICategoryServiceService, CategoryServiceService>();
            services.AddTransient<ICategoryServiceAppService, CategoryServiceAppService>();

            services.AddTransient<INavigationCache, NavigationCache>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddTransient<INavigationAppService, NavigationAppService>();

            services.AddTransient<IServiceCache, ServiceCache>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceAppService, ServiceAppService>();

            services.AddTransient<IAdvisoryAppService, AdvisoryAppService>();

            services.AddTransient<IExchangeratesCache, ExchangeratesCache>();
            services.AddTransient<IExchangeratesService, ExchangeratesService>();
            services.AddTransient<IExchangeratesAppService, ExchangeratesAppService>();
            services.AddTransient<ExchangeRate>();

            services.AddTransient<IContactAppService, ContactAppService>();

            services.AddTransient<ICategoryAboutCache, CategoryAboutCache>();
            services.AddTransient<ICategoryAboutService, CategoryAboutService>();
            services.AddTransient<ICategoryAboutAppService, CategoryAboutAppService>();

            services.AddTransient<IMetaconfigCache, MetaconfigCache>();
            services.AddTransient<IMetaconfigService, MetaconfigService>();
            services.AddTransient<IMetaconfigAppService, MetaconfigAppService>();

            services.AddTransient<ITagsCache, TagsCache>();
            services.AddTransient<ITagsService, TagsService>();
            services.AddTransient<ITagsAppService, TagsAppService>();

            services.AddTransient<IWarehouseAppService, WarehouseAppService>();
            services.AddTransient<ICustomerAddressAppService, CustomerAddressAppService>();
            services.AddTransient<ICustomerAppService, CustomerAppService>();

            services.AddTransient<ILocationCache, LocationCache>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILocationAppService, LocationAppService>();

            services.AddTransient<ILocationNodeCache, LocationNodeCache>();
            services.AddTransient<ILocationNodeService, LocationNodeService>();

            services.AddTransient<ILocationParentNodeCache, LocationParentNodeCache>();
            services.AddTransient<ILocationParentNodeService, LocationParentNodeService>();

            services.AddTransient<IOrderTransportAppService, OrderTransportAppService>();
            services.AddTransient<IAccountAppService, AccountAppService>();

            services.AddTransient<IBankinfoAppService, BankinfoAppService>();
            services.AddTransient<ICustomerBankinfoAppService, CustomerBankinfoAppService>();
            services.AddTransient<ILevelTransportGroupAppService, LevelTransportGroupAppService>();

            services.AddTransient<ICustomerWarehouseAppService, CustomerWarehouseAppService>();

            services.AddTransient<ISettingCache, SettingCache>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<ISettingAppService, SettingAppService>();

            services.AddTransient<IShoppingCartAppService, ShoppingCartAppService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IShoppingCartCache, ShoppingCartCache>();

            services.AddTransient<IHelpAppService, HelpAppService>();

            services.AddTransient<INotifyClient, NotifyClient>();
            services.AddTransient<IBankicAppService, BankicAppService>();
            services.AddTransient<IDdimportAppService, DdimportAppService>();
            services.AddTransient<IOrderServiceAppService, OrderServiceAppService>();
            services.AddTransient<IOrderAppService, OrderAppService>();

            services.AddTransient<IDepositAppService, DepositAppService>();
            services.AddTransient<IWithDrawalAppService, WithDrawalAppService>();
            services.AddTransient<IFreezeAppService, FreezeAppService>();
            services.AddTransient<IOrderDeliverybillAppService, OrderDeliverybillAppService>();
            services.AddTransient<IPaymentAppService, PaymentAppService>();
            services.AddTransient<IPackageTrackingAppService, PackageTrackingAppService>();

            services.AddTransient<ITrackAppService, TrackAppService>();

            #region ProductFromUrl

            services.AddTransient<IProductFromUrlAppService, ProductFromUrlAppService>();

            #endregion ProductFromUrl

            #region Ichiba.Partner.Api.Driver

            services.Configure<Ichiba.Partner.Api.Driver.ProductFromUrlConfig>(Configuration.GetSection("PartnerApi:ProductFromUrlConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<Ichiba.Partner.Api.Driver.ProductFromUrlConfig>>().Value);
            services.AddSingleton<Ichiba.Partner.Api.Driver.IAuthorizeClient, AuthorizeCSPrivateClientImplement>();
            services.AddSingleton<Ichiba.Partner.Api.Driver.ProductFromUrlClient>();

            #endregion Ichiba.Partner.Api.Driver

            #region Rabbit

            services.Configure<RabbitMqConnectionConfig>(Configuration.GetSection("RabbitMq:Connection"));

            services.AddSingleton<IRabbitMqPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMqPersistentConnection>>();
                var connectionConfig = sp.GetRequiredService<IOptions<RabbitMqConnectionConfig>>().Value;
                var factory = new ConnectionFactory()
                {
                    HostName = connectionConfig.HostName,
                    UserName = connectionConfig.UserName,
                    Password = connectionConfig.Password
                };

                return new DefaultRabbitMqPersistentConnection(factory, logger);
            });

            #endregion Rabbit

            #region Portal Command

            services.Configure<PortalCommandRabbitMqConfig>(Configuration.GetSection("RabbitMq:Command:Portal"));

            services.AddSingleton(sp =>
            {
                var rabbitMqConfig = sp.GetRequiredService<IOptions<PortalCommandRabbitMqConfig>>().Value;

                return new PortalCommandRabbitMqConfig()
                {
                    Environment = rabbitMqConfig.Environment,
                    BrokerName = rabbitMqConfig.BrokerName,
                    RoutingKey = rabbitMqConfig.RoutingKey,
                    QueueName = rabbitMqConfig.QueueName,
                    InstanceName = rabbitMqConfig.InstanceName,
                    ReceiveCommandTimeout = rabbitMqConfig.ReceiveCommandTimeout
                };
            });

            services.AddTransient<PortalCommandAppService>();
            services.AddTransient<ICommandSender<PortalCommandRabbitMqConfig>, CommandSender<PortalCommandRabbitMqConfig>>();
            services.AddSingleton<ICommandBus<PortalCommandRabbitMqConfig>, CommandBusRabbitMq<PortalCommandRabbitMqConfig>>();

            #endregion Portal Command

            #endregion Add DI

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<BaseController>>();
            services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger), logger);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    var authorizeConfig = serviceProvider.GetRequiredService<IOptions<AuthorizeConfig>>();

                    options.Authority = authorizeConfig.Value.Issuer;
                    options.RequireHttpsMetadata = authorizeConfig.Value.RequireHttpsMetadata;
                    options.ApiName = authorizeConfig.Value.ApiName;
                });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            var appConfig = Configuration.GetSection("App").Get<AppConfig>();
            if (appConfig.UseElasticApm)
                app.UseAllElasticApm(Configuration);

            loggerFactory.AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .WriteTo.RollingFile(@"./logs/log-{Date}.txt", outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "iChiba web portal public api");
                    c.DocumentTitle = "iChiba web portal public api documents";
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();

                endpoints.MapHealthChecks("/health");
            });

            //AppStart(app.ApplicationServices);
        }

        //private void AppStart(IServiceProvider provider)
        //{
        //    provider.GetService<ICommandBus<PortalCommandRabbitMqConfig>>().CreateConsumerResultChannel();
        //}
    }
}
