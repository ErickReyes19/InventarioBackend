using Inventario.Models;

namespace Inventario.interfaces.IEmpleado
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<IEnumerable<Empleado>> GetEmpleadosActivos();
        Task<Empleado> PostEmpleados(Empleado empleado);
        Task<Empleado> PutEmpleados(string id, Empleado empleado);
    }
}
