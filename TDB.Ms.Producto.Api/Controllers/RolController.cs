using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BK.Usuario.Aplicacion.Rol;
using static BK.Usuario.Api.Routes.ApiRoutes;
using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Api.Controllers
{
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly IRolService _service;

        public RolController(IRolService service)
        {
            _service = service;
        }

        [HttpGet(RouteRol.GetAll)]
        public IEnumerable<dominio.Rol> ListarRol()
        {

            var listaRol = _service.ListarRol();
            return listaRol;
        }

        [HttpGet(RouteRol.GetById)]
        public dominio.Rol BuscarRol(int id)
        {
            var objRol = _service.Rol(id);

            return objRol;
        }

        [HttpPost(RouteRol.Create)]
        public ActionResult<dominio.Rol> CrearRol([FromBody] dominio.Rol rol)
        {
            _service.RegistrarRol(rol);

            return Ok();
        }

        //[HttpPut(RouteCategoria.Update)]
        //public ActionResult<dominio.Categoria> ModificarCategoria(dominio.Categoria producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Categoria>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldCategoria = collection.Find(x => x.IdCategoria == producto.IdCategoria).FirstOrDefault();
        //    //oldCategoria.Nombre = producto.Nombre;
        //    //oldCategoria.Precio = producto.Precio;
        //    //oldCategoria.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCategoria == oldCategoria.IdCategoria, oldCategoria);


        //    //Categoria productoModificado = listaCategoria.Single(x => x.IdCategoria == producto.IdCategoria);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarCategoria", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteRol.Delete)]
        public ActionResult<dominio.Rol> EliminarRol(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
