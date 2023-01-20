﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TDB.Ms.Producto.Api.Routes;
using TDB.Ms.Producto.Aplicacion.Producto.Read;
using TDB.Ms.Producto.Dominio.Servicios;
using static TDB.Ms.Producto.Api.Routes.ApiRoutes;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoQueryAll db = new ProductoQueryAll();

        [HttpGet(RouteProducto.GetAll)]
        public IEnumerable<dominio.Producto> ListarProductos()
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
       
        [HttpGet(RouteProducto.GetById)]
        public dominio.Producto BuscarProducto(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var collection = database.GetCollection<dominio.Producto>("Producto");
            #endregion

            var objProducto = collection.Find(x => x.IdProducto == id).FirstOrDefault();

            /*Dominio.Entidades.Producto product = new Dominio.Entidades.Producto();  
            product.IdProducto = 2;
            product.Precio = 4;
            product.Cantidad = 30;
            product.Nombre = "gas";*/

            return objProducto;
        }

        [HttpPost(RouteProducto.Create)]
        public ActionResult<dominio.Producto> CrearProducto(dominio.Producto producto)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var collection = database.GetCollection<dominio.Producto>("Producto");
            #endregion

            producto._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(producto);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return Ok();
        }
        
        [HttpPut(RouteProducto.Update )]
        public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var collection = database.GetCollection<dominio.Producto>("producto");
            #endregion

            collection.FindOneAndReplace(x => x._id == producto._id, producto);

            //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
            //oldProducto.Nombre = producto.Nombre;
            //oldProducto.Precio = producto.Precio;
            //oldProducto.Cantidad = producto.Cantidad;
            //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


            //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            //productoModificado.Nombre = producto.Nombre;
            //productoModificado.Cantidad = producto.Cantidad;
            //productoModificado.Precio= producto.Precio;
            //return CreatedAtAction("ModificarProducto", productoModificado);
            return Ok();
        }

        [HttpDelete(RouteProducto.Delete)]
        public ActionResult<dominio.Producto> EliminarProducto(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TDB_productos");
            var collection = database.GetCollection<dominio.Producto>("producto");
            #endregion

            collection.FindOneAndDelete(x => x.IdProducto == id);
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}