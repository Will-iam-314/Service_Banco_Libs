using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Aplicacion.Rol
{
    public interface IRolService
    {
        List<dominio.Rol> ListarRol();

        dominio.Rol Rol(int idRol);

        bool RegistrarRol(dominio.Rol rol);

        //bool ModificarCategoria(dominio.Categoria categoria);

        void Eliminar(int idRol);
    }
}
