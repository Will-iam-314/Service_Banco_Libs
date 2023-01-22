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
        public IEnumerable<dominio.Libro> ListarLibros()
        {
            var listaProducto = db.ListarLibros();
            return listaProducto;
        }
       
        [HttpGet(RouteLibro.GetById)]
        public dominio.Libro BuscarLibro(int id)
        {
            var objProducto = db.BuscarLibro(id);
            return objProducto;
        }

    

        [HttpPost(RouteLibro.Create)]
        public ActionResult<dominio.Libro> CrearLibro(dominio.Libro libro)
        {
            db.CrearLibro(libro);
            return Ok();
        }
        
        [HttpPut(RouteLibro.Update )]
        public ActionResult<dominio.Libro> ModificarLibro(dominio.Libro libro)
        {
                 
            CreatedAtAction("ModificarProducto", db.ModificarLibro(libro));        
            return Ok();
        }

        [HttpDelete(RouteLibro.Delete)]
        public ActionResult<dominio.Libro> EliminarLibro(int id)
        {          
            db.EliminarLibro(id);         
            return Ok(id);
        }
    }
}
