using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BK.Gateway.Aplicacion.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace BK.Gateway.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {            
            // Clientes
            services.AddClientes(configuration);

            return services;
        }

        public static IServiceCollection AddClientes(this IServiceCollection services, IConfiguration configuration)
        {
            //CLIENT_SETTINGS
            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente Ms Usuario

            services.AddHttpClient("BKUsuario", client =>
            {
                client.BaseAddress = new Uri(msSettings.UsuarioUrl);
            });

            #endregion

            services.AddTransient<UsuarioClient.IClient, UsuarioClient.Client>();

            return services;
        }
    }
}
