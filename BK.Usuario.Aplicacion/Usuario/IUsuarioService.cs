using dominio = BK.Usuario.Dominio.Entidades;

namespace BK.Usuario.Aplicacion.Usuario
{
    public interface IUsuarioService
    {
        dominio.Usuario BuscarPorId(int idUsuario);

        bool Registrar(dominio.Usuario usuario);
        List<dominio.Usuario> ListarUsuario();
        bool Modificar(dominio.Usuario usuario);
        void Eliminar(int idUsuario);

    }
}
