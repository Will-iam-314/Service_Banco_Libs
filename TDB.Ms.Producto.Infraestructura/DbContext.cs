using MongoDB.Driver;
using Release.MongoDB.Repository;

namespace BK.Usuario.Infraestructura
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }
    }
}
