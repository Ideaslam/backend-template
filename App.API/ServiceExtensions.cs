using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Edura.Data;
using Edura.Model.Support;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Identity;
using Edura.Repository.Identity.Contracts;
using Edura.Repository.Identity;
using Edura.Orchestrator.Identity.Contracts;
using Edura.Orchestrator.Identity;
using Edura.Socket;
using Edura.Socket.Handlers;
using Microsoft.AspNetCore.Identity;
using Edura.Services;
using Edura.Services.Notification;
using Edura.Services.Email;
using Edura.Services.Branch;
using Edura.Services.Sms;
using Edura.Services.OneSignal;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Edura.Orchestrator.Common.Contract;
using Edura.Orchestrator.Common;
using Edura.Repository.Common.Contract;
using Edura.Repository.Common;

namespace Edura.API
{
    public  static class ServiceExtensions
    {
       
        public static AppConfig ConfigureAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfigSection = configuration.GetSection("AppConfig");
            services.Configure<AppConfig>(appConfigSection);
            var appConfig = appConfigSection.Get<AppConfig>();
            return appConfig;
        }

        public static void ConfigureCors(this IServiceCollection services, CorsConfig corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsConfig.CorsPolicy,
                    builder => builder.WithOrigins(corsConfig.AllowedCorsDomains)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }


        public static void ConfigureJsonSerializer(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => { }).AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddUserManager<ApplicationUserManager>()
            .AddDefaultTokenProviders();

            services.Configure<ApplicationUserIdentityOptions>(options =>
            {
                options.Tokens.ChangePhoneNumberTokenProvider = TokenOptions.DefaultPhoneProvider;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, JwtConfig jwtSettings)
        {
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            #region context and unit of work
            services.AddTransient<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork<ApplicationDbContext>, UnitOfWork<ApplicationDbContext>>();
            #endregion

            #region common
            services.AddScoped<IDetailCodeRepository, DetailCodeRepository>();
            services.AddScoped<IAppResourceRepository,  AppResourceRepository>();

            #endregion

            #region identity
            services.AddTransient<ApplicationUserManager>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationRoleRepository, ApplicationRoleRepository>();
            services.AddScoped<IApplicationRoleClaimRepository, ApplicationRoleClaimRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationUserClaimRepository, ApplicationUserClaimRepository>();
            services.AddScoped<IApplicationUserLoginRepository, ApplicationUserLoginRepository>();
            services.AddScoped<IApplicationUserRoleRepository, ApplicationUserRoleRepository>();
            services.AddScoped<IApplicationUserTokenRepository, ApplicationUserTokenRepository>();
            #endregion
        }
        public static void ConfigureService(this IServiceCollection services)
        {

            BaseService.InitializeClient();

            services.AddTransient<SendGridService>();
            services.AddTransient<FcmService>();
            services.AddTransient<BranchService>();
            services.AddTransient<InfobipServie>();
            services.AddTransient<OneSignalService>();

        }
        public static void ConfigureOrchestrator(this IServiceCollection services)
        {
            #region common
            services.AddScoped<IDetailCodeOrch, DetailCodeOrch>();
            services.AddScoped<IAppResourceOrch,  AppResourceOrch>();

            #endregion

            #region Identity
            services.AddScoped<IApplicationUserOrch, ApplicationUserOrch>();
            services.AddScoped<IApplicationRoleOrch, ApplicationRoleOrch>();
            services.AddScoped<IApplicationUserRoleOrch, ApplicationUserRoleOrch>();
            #endregion

        }

        public static void ConfigureSocket(this IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();
            services.AddTransient<VersionSocketHandler>();
        }
        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:EduraConnection"];
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString));
           
        }

       
    }
}
