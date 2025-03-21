using Inventario.Models;

namespace Inventario.interfaces.IEmpleado
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDTO>> GetEmpleados();
        Task<IEnumerable<EmpleadoDTO>> GetEmpleadosActivos();
        Task<EmpleadoDTO> GetEmpleadoById(string id);
        Task<EmpleadoDTO> PostEmpleados(Empleado empleado);
        Task<EmpleadoDTO> PutEmpleados(string id, Empleado empleado);
    }
}
