using Inventario.Models;

namespace Inventario.interfaces.ILogin
{
    public interface ILoginRepository
    {
        Task<Usuario> GetUserByUsername(string username);
        Task<List<string>> GetUserPermissions(string userId);
    }
}
