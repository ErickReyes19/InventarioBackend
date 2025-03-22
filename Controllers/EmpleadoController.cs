using Inventario.interfaces.IEmpleado;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            try
            {
                var empleados = await _empleadoService.GetEmpleados();

                return Ok(empleados);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleados(Empleado empleado)
        {
            try
            {
                var empleadoCreate = await _empleadoService.PostEmpleados(empleado);
                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Empleado>> UpdateEmpleados(Empleado empleado, string id)
        {
            try
            {
                var empleadoCreate = await _empleadoService.PutEmpleados(id, empleado);

                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> EmpleadosById(string id)
        {

            try
            {
                var empleadoCreate = await _empleadoService.GetEmpleadoById(id);
                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadosActivos()
        {
            try
            {
                var empleados = await _empleadoService.GetEmpleadosActivos();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
