using Edura.API.Middelwares;
using Edura.Model.Support;
using Edura.Socket;
using Edura.Socket.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.API
{
    public static class AppBuilderExtentions
    {

        public static void ConfigureCors(this IApplicationBuilder app,CorsConfig corsConfig)
        {
            app.UseCors(corsConfig.CorsPolicy);
            app.UseCors(builder => builder.WithOrigins(corsConfig.AllowedCorsDomains)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        }

        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,PathString path,WebSocketHandler handler)
        {
            return app.Map(path, x => x.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }

        public static void ConfigureSocket(this IApplicationBuilder app)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
            app.UseWebSockets();
            app.MapWebSocketManager("/version", serviceProvider.GetService<VersionSocketHandler>());
        }

        public static void ConfigureEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
