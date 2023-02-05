using MongoDB.Driver;
using TDB.Ms.Clientes.Infraestructura.DBSettings;
using dominio = TDB.Ms.Clientes.Dominio.Entidades;

namespace TDB.Ms.Clientes.Dominio.Servicios
{
   public class ClientesService
    {
        private IMongoCollection<dominio.Cliente> _cliente;

//        public ProductoService(IDBSettings dBSettings)
//        {
//            var cliente = new MongoClient(dBSettings.Server);
//            var database = cliente.GetDatabase(dBSettings.Database);
//            _producto = database.GetCollection<dominio.Producto>(dBSettings.Collection);
//        }

//        public List<dominio.Producto> ListarProductos()
//        {
//            return _producto.Find(x => true).ToList();
//       }
    }
}
