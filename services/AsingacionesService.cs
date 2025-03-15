using Inventario.interfaces;

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
    }

}
