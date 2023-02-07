using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BK.Gateway.Api.Routes.ApiRoutes;
using Productos = BK.Gateway.Aplicacion.UsuarioClient;
//para next microservice
using BK.Gateway.Aplicacion.Usuario.Request;

namespace BK.Gateway.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly Productos.IClient _productosClient;
        //private readonly Clientes.IClient _clientesClient;

        public UsuarioController(Productos.IClient productosClient)
        {
            _productosClient = productosClient;
        }

        //public ProductoController(Productos.IClient productosClient, Clientes.IClient clientesClient)
        //{
        //    _productosClient = productosClient;
        //    _clientesClient = clientesClient;
        //}

        [HttpGet(RouteUsuario.GetAll)]
        public ICollection<Productos.Usuario> ListarProductos()
        {
            var listaProducto = _productosClient.ApiV1UsuarioAllAsync().Result;
            return listaProducto;
        }

        [HttpPost(RoutePedido.RegistrarPedido)]
        public async void RegistrarPedido(RegistrarPedidoRequest request)
        {
            
            //var cliente = _clientesClient.ApiV1ClienteAsync(request.idCliente);
            var producto = await _productosClient.ApiV1UsuarioAsync(request.idProducto);

            // Llamar a PedidosClient para crear el pedido
            // Llamar a PedidosClient para crear el detalle del pedido

            var pedido = _productosClient.ApiV1UsuarioUpdateStockAsync(producto);


        }
    }
}
