using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Aplicacion.Rol
{
    public class RolService : IRolService
    {
        private readonly ICollectionContext<dominio.Rol> _rol;
        private readonly IBaseRepository<dominio.Rol> _rolR;

        public RolService(ICollectionContext<dominio.Rol> rol, 
                                IBaseRepository<dominio.Rol> rolR)
        {
            _rol = rol;
            _rolR = rolR;
        }

        public dominio.Rol Rol(int idRol)
        {
            Expression<Func<dominio.Rol, bool>> filter = s => s.esEliminado == false && s.idRol == idRol;
            var item = (_rol.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idRol)
        {
            Expression<Func<dominio.Rol, bool>> filter = s => s.esEliminado == false && s.idRol == idRol;
            var item = (_rol.Context().FindOneAndDelete(filter, null));
        }

        public List<dominio.Rol> ListarRol()
        {
            Expression<Func<dominio.Rol, bool>> filter = s => s.esEliminado == false;
            var items = (_rol.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool ModificarRol(dominio.Rol rol)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarRol(dominio.Rol rol)
        {
            rol.esEliminado = false;
            rol.fechaCreacion = DateTime.Now;
            rol.esActivo = true;

            var p = _rolR.InsertOne(rol);

            return true;
        }
    }
}
