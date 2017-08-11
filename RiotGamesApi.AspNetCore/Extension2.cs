using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace RiotGamesApi.AspNetCore
{
    public static class Extension2
    {
        /// <summary>
        /// necessary for using RiotGamesApi.AspNetCore wrapper 
        /// </summary>
        /// <param name="app">
        /// </param>
        /// <returns>
        /// </returns>
        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            IServiceProvider sProvider = app.ApplicationServices;
            sProvider.UseRiotGamesApiServiceProvider();
            return app;
        }
    }
}