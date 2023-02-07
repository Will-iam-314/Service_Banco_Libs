using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = BK.Prestamo.Dominio.Entidades;

namespace BK.Prestamo.Aplicacion.Prestamo
{
    public class PrestamoService : IPrestamoService
    {
        private readonly ICollectionContext<dominio.Prestamo> _prestamo;
        private readonly IBaseRepository<dominio.Prestamo> _prestamoR;

        public PrestamoService(ICollectionContext<dominio.Prestamo> prestamo,
                                IBaseRepository<dominio.Prestamo> prestamoR)
        {
            _prestamo = prestamo;
            _prestamoR = prestamoR;
        }

        public List<dominio.Cliente> ListarClientes()
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
            var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registracliente(dominio.Cliente cliente)
        {
            cliente.esEliminado = false;
            cliente.fechaCreacion = DateTime.Now;
            cliente.esActivo = true;

            // _cliente.Context().InsertOne(cliente);                       

            var p = _clienteR.InsertOne(cliente);

            return true;
        }

        public dominio.Cliente Cliente(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.idCliente == idCliente;
            var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.idCliente == idCliente;
            var item = (_cliente.Context().FindOneAndDelete(filter, null));

        }
    }
}
