using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using BOFL.Libro.Infraestructura.DBRepository;
using BOFL.Libro.Infraestructura.DBSettings;
using dominio = BOFL.Libro.Dominio.Entidades;

namespace BOFL.Libro.Aplicacion.Producto.Read
{
    public class LibroQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Libro> _libro;

        public LibroQueryAll()
        {
            _libro = _repository.db.GetCollection<dominio.Libro>("Libro");
        }

        public IEnumerable<dominio.Libro> ListarProductos()
        {
            return _libro.Find(x => true).ToList();
        }
    }
}
