using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using BK.Usuario.Aplicacion.Usuario;
using BK.Usuario.Aplicacion.Rol;
using BK.Usuario.Infraestructura;
using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Usuario>>(x => new CollectionContext<dominio.Usuario>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.Rol>>(x => new CollectionContext<dominio.Rol>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Usuario>>(x => new BaseRepository<dominio.Usuario>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.Rol>>(x => new BaseRepository<dominio.Rol>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRolService, RolService>();

            #endregion

            return services;
        }

    }
}
