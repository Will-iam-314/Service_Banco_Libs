using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = BK.Prestamo.Dominio.Entidades;

namespace BK.Prestamo.Aplicacion.Prestamo
{
    public interface IPrestamoService
    {
        List<dominio.Prestamo> ListarPrestamos();
        bool Registracliente(dominio.Prestamo prestamo);
        dominio.Prestamo Cliente(int idPrestamo);
        void Eliminar(int idPrestamo);
    }
}
