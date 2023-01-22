using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOFL.Libro.Infraestructura.DBSettings;
using dominio = BOFL.Libro.Dominio.Entidades;

namespace BOFL.Libro.Dominio.Servicios
{
    public class LibroService
    {
        private IMongoCollection<dominio.Libro> _libro;

        public LibroService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _libro = database.GetCollection<dominio.Libro>(dBSettings.Collection);
        }

        public List<dominio.Libro> ListarProductos()
        {
            return _libro.Find(x => true).ToList();
        }
    }
}
