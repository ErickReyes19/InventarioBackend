
using Inventario.models.Usuario;
using Inventario.Models;

namespace Inventario.interfaces.IUsuario
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetUsuarios();
        Task<IEnumerable<UsuarioDto>> GetUsuariosActivos();
        Task<UsuarioDto> GetUsuarioById(string id);
        Task<UsuarioDto> PostUsuario(Usuario usuario);
        Task<UsuarioDto> PutUsuario(string id,Usuario usuario);
    }
}
