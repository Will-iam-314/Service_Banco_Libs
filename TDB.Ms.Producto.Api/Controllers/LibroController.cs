using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BOFL.Libro.Api.Routes;
using BOFL.Libro.Aplicacion.Producto.Read;
using BOFL.Libro.Dominio.Servicios;
using static BOFL.Libro.Api.Routes.ApiRoutes;
using dominio = BOFL.Libro.Dominio.Entidades;

namespace BOFL.Libro.Api.Controllers
{
    [ApiController]
    public class LibroController : ControllerBase
    {
        private LibroQueryAll db = new LibroQueryAll();

        [HttpGet(RouteLibro.GetAll)]
        public IEnumerable<dominio.Libro> ListarProductos()
        {
            //#region Conexión a base de datos
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("TDB_productos");
            //var collection = database.GetCollection<dominio.Producto>("producto");
            //#endregion

            //var listaProducto = collection.Find(x => true).ToList();

            var listaProducto = db.ListarProductos();
            return listaProducto;
        }
       
        [HttpGet(RouteLibro.GetById)]
        public dominio.Libro BuscarProducto(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BancoLibros");
            var collection = database.GetCollection<dominio.Libro>("Libro");
            #endregion

            var objProducto = collection.Find(x => x.idLibro == id).FirstOrDefault();

            return objProducto;
        }

        [HttpPost(RouteLibro.Create)]
        public ActionResult<dominio.Libro> CrearProducto(dominio.Libro libro)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BancoLibros");
            var collection = database.GetCollection<dominio.Libro>("Libro");
            #endregion

            libro._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(libro);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return Ok();
        }
        
        [HttpPut(RouteLibro.Update )]
        public ActionResult<dominio.Libro> ModificarProducto(dominio.Libro libro)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BancoLibros");
            var collection = database.GetCollection<dominio.Libro>("Libro");
            #endregion

            collection.FindOneAndReplace(x => x._id == libro._id, libro);

            


            var oldLibro = collection.Find(x => x.idLibro == libro.idLibro).FirstOrDefault();
            oldLibro.isbn = libro.isbn;
            oldLibro.lib_volumen = libro.lib_volumen;
            oldLibro.lib_stock = libro.lib_stock;
            oldLibro.lib_titulo = libro.lib_titulo;
            oldLibro.idEditorial = libro.idEditorial;
            oldLibro.idAutor = libro.idAutor;


            dominio.Libro libroModificado = ListarProductos().Single(x => x.idLibro == libro.idLibro);
            libroModificado.isbn = libro.isbn;
            libroModificado.lib_volumen = libro.lib_volumen;
            libroModificado.lib_stock = libro.lib_stock;
            libroModificado.lib_titulo = libro.lib_titulo;
            libroModificado.idEditorial = libro.idEditorial;
            libroModificado.idAutor = libro.idAutor;
            CreatedAtAction("ModificarProducto", libroModificado);


            
            return Ok();
        }

        [HttpDelete(RouteLibro.Delete)]
        public ActionResult<dominio.Libro> EliminarProducto(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BancoLibros");
            var collection = database.GetCollection<dominio.Libro>("Libro");
            #endregion

            collection.FindOneAndDelete(x => x.idLibro == id);
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}
