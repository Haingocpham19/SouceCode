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
using Elastic.Apm.NetCoreAll;
using iChiba.IS4.Api.Driver;
using iChiba.OM.DbContext;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Redis.Implement;
using iChiba.Portal.Common.Configuration;
using iChiba.Portal.ExtensionApi.AppService.Implement;
using iChiba.Portal.ExtensionApi.AppService.Implement.IS4;
using iChiba.Portal.ExtensionApi.AppService.Interface;
using iChiba.Portal.ExtensionApi.Configs;
using iChiba.Portal.ExtensionApi.Driver;
using iChiba.WH.DbContext;
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
using System.Collections.Generic;
using System.Linq;

namespace iChiba.Portal.ExtensionApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LoadConfig();
        }

        private void LoadConfig()
        {
            ConfigurationRoot configurationRoot = (ConfigurationRoot)Configuration;
            IEnumerable<Microsoft.Extensions.Configuration.IConfigurationProvider> configurationProviders = configurationRoot
                .Providers
                .Where(p => p.GetType() == typeof(JsonConfigurationProvider)
                    && ((JsonConfigurationProvider)p).Source.Path.StartsWith("appsettings"));

            foreach (Microsoft.Extensions.Configuration.IConfigurationProvider item in configurationProviders)
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

                //cfg.AddProfile<AdapterProfile>();
            });


            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            })
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "iChiba so private api",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
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
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppConfig>>()?.Value);

            services.Configure<AuthorizeConfig>(Configuration.GetSection("Authorize"));
            services.Configure<FileUploadConfig>(Configuration.GetSection("FileStorage"));
            services.Configure<RabbitMqConnectionConfig>(Configuration.GetSection("RabbitMq:Connection"));


            services.AddSingleton<IRabbitMqPersistentConnection>(sp =>
            {
                ILogger<DefaultRabbitMqPersistentConnection> logger = sp.GetRequiredService<ILogger<DefaultRabbitMqPersistentConnection>>();
                RabbitMqConnectionConfig connectionConfig = sp.GetRequiredService<IOptions<RabbitMqConnectionConfig>>().Value;
                ConnectionFactory factory = new ConnectionFactory()
                {
                    HostName = connectionConfig.HostName,
                    UserName = connectionConfig.UserName,
                    Password = connectionConfig.Password
                };

                return new DefaultRabbitMqPersistentConnection(factory, logger);
            });

            services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(ConfigSettingDefine.DbiChibaCustomerConnectionString.GetConfig()));
            services.AddScoped<IUnitOfWork, UnitOfWork<CustomerDBContext>>();

            services.AddDbContext<WarehouseDBContext>(options => options.UseSqlServer(ConfigSettingDefine.DbWarehouseConnectionString.GetConfig()));
            services.AddScoped<IUnitOfWorkGeneric<WarehouseDBContext>, UnitOfWork<WarehouseDBContext>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentContext, CurrentContext>();
            services.AddTransient<IFileStorage, FileStorage>();
            services.AddSingleton<ElasticClientProvider<ElasticConnectionSetting>>();
            services.AddTransient<ElasticIndexer<ElasticConnectionSetting>>();
            services.AddTransient<IRedisStorage, RedisStorage>();

            #region AspNetUserCache
            services.AddTransient<IAspNetUserCache, AspNetUserCache>();
            services.AddSingleton<IAuthorizeClient, AuthorizeClientImplement>();
            //services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion
            #region ShoppingCard
            services.AddTransient<IShoppingCartCache, ShoppingCartCache>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            #endregion
            #region Exchangerates
            services.AddTransient<IExchangeratesCache, ExchangeratesCache>();
            services.AddTransient<IExchangeratesService, ExchangeratesService>();
            #endregion
            #region Access

            services.Configure<AccessConfig>(Configuration.GetSection("IS4:AccessConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<AccessConfig>>().Value);
            services.AddTransient<IAccessAppService, AccessAppService>();
            services.AddSingleton<IS4.Api.Driver.IAuthorizeClient, AuthorizeClientImplement>();
            services.AddTransient<AccessClient>();

            #endregion

            // config DI to API
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    IOptions<AuthorizeConfig> authorizeConfig = serviceProvider.GetRequiredService<IOptions<AuthorizeConfig>>();

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

            //services.AddHostedService<SyncProcessedFeedbackFailService>();

            #endregion Add DI
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime applicationLifetime)
        {
            var appConfig = Configuration.GetSection("ElasticApm").Get<ElasticApmConfig>();
            if (appConfig.Active)
                app.UseAllElasticApm(Configuration);

            loggerFactory.AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .WriteTo.RollingFile(@"./logs/log-{Date}.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}]{NewLine}{Message:lj}{NewLine}{NewLine}{Exception}{NewLine}{NewLine}")
                .CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "iChiba so private api");
                    c.DocumentTitle = "iChiba so private api documents";
                });

            //app.SubscribeMessageHandlers();
            app.UseHealthChecks("/health");

        }
    }
}
