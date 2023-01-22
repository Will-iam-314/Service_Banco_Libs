using MongoDB.Driver;
using MongoDB.Bson;
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

        public IEnumerable<dominio.Libro> ListarLibros()
        {
            return _libro.Find(x => true).ToList();
        }

        public dominio.Libro BuscarLibro(int id)
        {
            return _libro.Find(x => x.idLibro == id).FirstOrDefault();
        }

        public void CrearLibro(dominio.Libro libro)
        {
            libro._id = ObjectId.GenerateNewId().ToString();
            _libro.InsertOne(libro);

        }

        public dominio.Libro ModificarLibro(dominio.Libro libro)
        {
            _libro.FindOneAndReplace(x => x._id == libro._id, libro);

            var oldLibro = _libro.Find(x => x.idLibro == libro.idLibro).FirstOrDefault();
            oldLibro.isbn = libro.isbn;
            oldLibro.lib_volumen = libro.lib_volumen;
            oldLibro.lib_stock = libro.lib_stock;
            oldLibro.lib_titulo = libro.lib_titulo;
            oldLibro.idEditorial = libro.idEditorial;
            oldLibro.idAutor = libro.idAutor;

            dominio.Libro libroModificado = ListarLibros().Single(x => x.idLibro == libro.idLibro);
            libroModificado.isbn = libro.isbn;
            libroModificado.lib_volumen = libro.lib_volumen;
            libroModificado.lib_stock = libro.lib_stock;
            libroModificado.lib_titulo = libro.lib_titulo;
            libroModificado.idEditorial = libro.idEditorial;
            libroModificado.idAutor = libro.idAutor;

            return libroModificado;
          
        }

        public void EliminarLibro(int id)
        {
            _libro.FindOneAndDelete(x => x.idLibro == id);
        }




    }
}
