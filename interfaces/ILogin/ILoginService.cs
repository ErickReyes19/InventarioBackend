namespace Inventario.interfaces.ILogin
{
    public interface ILoginService
    {
        Task<string> Login(string username, string password);
    }
}
