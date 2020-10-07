using AutoMapper;
using Edura.Model.DTOMappers;
using Edura.Model.Support;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphiQl;
using System;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Edura.Graph.Schemas.Common;
using Edura.Graph.Queries.Common;
using GraphQL.Conversion;

namespace Edura.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public IConfiguration configuration { get; }

        public Startup(IConfiguration _configuration , IWebHostEnvironment _hostingEnvironment)
        {
            configuration = _configuration;
            hostingEnvironment = _hostingEnvironment;

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        
        private AppConfig appConfig;
        public void ConfigureServices(IServiceCollection services)
        {
            appConfig = services.ConfigureAppConfig(configuration);

            services.ConfigureCors(appConfig.Cors);

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddAutoMapper(c=>c.AddProfile<AutoMapperConfig>(), typeof(Startup));

            services.ConfigureJsonSerializer();

            services.AddHttpContextAccessor();

            services.ConfigureIdentity();

            services.ConfigureRepository();

            services.ConfigureService();

            services.ConfigureOrchestrator();

            services.ConfigureSocket();

            services.ConfigureSQLContext(configuration);

            services.ConfigureJwtAuthentication(appConfig.Jwt);

            //services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            //services.AddSingleton<IDocumentWriter, DocumentWriter>();
            //services.AddSingleton<CountryType>();
            //services.AddScoped<CountryQuery>();


           services.AddSingleton<DetailCodeSchema>();
            services.AddSingleton<AppResourceSchema>();

            services.AddGraphQL(options =>
             {
                 options.EnableMetrics = hostingEnvironment.IsDevelopment();
                 options.ExposeExceptions = hostingEnvironment.IsDevelopment();
                 options.FieldNameConverter = new DefaultFieldNameConverter();

             })
                .AddSystemTextJson()
                .AddGraphTypes(typeof(DetailCodeQuery).Assembly, ServiceLifetime.Singleton)
                  .AddGraphTypes(typeof(AppResourceQuery).Assembly, ServiceLifetime.Singleton)

                .AddUserContextBuilder((httpContext => new GraphQLUserContext { User = httpContext.User }))
                .AddWebSockets() 
                .AddDataLoader();

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            app.ConfigureCors(appConfig.Cors);

            app.UseAuthentication();

            app.ConfigureSocket();


            app.UseStaticFiles();

           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseRouting();

            app.UseAuthorization();
            app.ConfigureEndPoints();
            app.UseGraphiQl("/graphiql", "/graphql");

             app.UseGraphQLWebSockets<DetailCodeSchema>("/detail-code/graphql");
             app.UseGraphQL<DetailCodeSchema>("/detail-code/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                GraphQLEndPoint= "/detail-code/graphql",
                Path = "/ui/detail-code/playground"
            });




            app.UseGraphQLWebSockets<AppResourceSchema>("/app-resource/graphql");
            app.UseGraphQL<AppResourceSchema>("/app-resource/graphql");
 
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                GraphQLEndPoint = "/app-resource/graphql",
                Path = "/ui/app-resource/playground"
            }); 
          



        }
    }
}
