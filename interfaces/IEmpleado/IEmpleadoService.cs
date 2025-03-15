using Inventario.Models;

namespace Inventario.interfaces.IEmpleado
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<IEnumerable<Empleado>> GetEmpleadosActivos();
        Task<Empleado> GetEmpleadoById(string id);
        Task<Empleado> PostEmpleados(Empleado empleado);
        Task<Empleado> PutEmpleados(string id, Empleado empleado);
    }
}
