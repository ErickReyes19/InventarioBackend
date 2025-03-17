using Inventario.interfaces;
using Inventario.Models;

namespace Inventario.services

{
    public class AsingacionesService: IAsignaciones
    {
        public string GenerateNewId()
        {
            return Guid.NewGuid().ToString();
        }        
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
        public string EncriptPassword(string password)
        {
            var encriptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return encriptPassword;
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }

}
