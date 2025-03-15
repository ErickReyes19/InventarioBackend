using Inventario.interfaces;
using Inventario.interfaces.IEmpleado;
using Inventario.Models;

namespace Inventario.services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IAsignaciones _AsinacionesService;

        public EmpleadoService(IEmpleadoRepository empleadoRepository, IAsignaciones asignacionesService)
        {
            _empleadoRepository = empleadoRepository;
            _AsinacionesService = asignacionesService;  
        }

        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _empleadoRepository.GetEmpleados();
        }        
        public async Task<Empleado> GetEmpleadoById(string id)
        {
            return await _empleadoRepository.GetEmpleadoById(id);
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosActivos()
        {
            return await _empleadoRepository.GetEmpleadosActivos();
        }

        public async Task<Empleado> PostEmpleados(Empleado empleado)
        {
            empleado.id = _AsinacionesService.GenerateNewId();
            empleado.created_at = _AsinacionesService.GetCurrentDateTime();
            empleado.updated_at = _AsinacionesService.GetCurrentDateTime();
            return await _empleadoRepository.PostEmpleados(empleado);
        }

        public async Task<Empleado> PutEmpleados(string id, Empleado empleado)
        {
            var empleadoFound = await _empleadoRepository.GetEmpleadoById(id);

            if (empleadoFound == null)
            {
                return null;
            }

            empleadoFound.nombre = empleado.nombre ?? empleadoFound.nombre;
            empleadoFound.correo = empleado.correo ?? empleadoFound.correo;
            empleadoFound.edad = empleado.edad ?? empleadoFound.edad;
            empleadoFound.apellido = empleado.apellido ?? empleadoFound.apellido;
            empleadoFound.activo = empleado.activo;
            empleadoFound.updated_at = _AsinacionesService.GetCurrentDateTime();

            return await _empleadoRepository.PutEmpleados(id, empleadoFound);
        }

    }
}
