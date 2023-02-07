using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BK.Usuario.Aplicacion.Usuario;
using static BK.Usuario.Api.Routes.ApiRoutes;
using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IUsuarioService _service;

        public ProductoController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet(RouteUsuario.GetAll)]
        public IEnumerable<dominio.Usuario> ListarUsuario()
        {           

            var listaUsuario =_service.ListarUsuario();
            return listaUsuario;
        }

        [HttpGet(RouteUsuario.GetById)]
        public dominio.Usuario BuscarUsuario(int id)
        {           
            var objUsuario = _service.BuscarPorId(id);

            return objUsuario;
        }

        [HttpPost(RouteUsuario.Create)]
        public ActionResult<dominio.Usuario> CrearUsuario([FromBody] dominio.Usuario usuario)
        {
            _service.Registrar(usuario);
            return Ok();
        }

  

        //[HttpPut(RouteProducto.Update)]
        //public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Producto>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
        //    //oldProducto.Nombre = producto.Nombre;
        //    //oldProducto.Precio = producto.Precio;
        //    //oldProducto.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


        //    //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarProducto", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteUsuario.Delete)]
        public ActionResult<dominio.Usuario> EliminarUsuario(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
