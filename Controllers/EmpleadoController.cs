using Inventario.interfaces.IEmpleado;
using Inventario.Models;
using Inventario.services;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
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

                if (empleados == null || !empleados.Any())
                    return NotFound("No se encontraron empleados.");

                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los empleados: {ex.GetType().Name} - {ex.Message}");
            }
        }           
        
        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleados(Empleado empleado)
        {
            try
            {

                var empleadoCreate = await _empleadoService.PostEmpleados(empleado);

                if (empleadoCreate == null)
                    return NotFound("No se encontraron empleados.");

                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los empleados: {ex.GetType().Name} - {ex.Message}");
            }
        }            
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Empleado>> UpdateEmpleados(Empleado empleado, string id)
        {
            try
            {

                var empleadoCreate = await _empleadoService.PutEmpleados(id,empleado);

                if (empleadoCreate == null)
                    return NotFound("No se encontraron empleados.");

                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los empleados: {ex.GetType().Name} - {ex.Message}");
            }
        }     
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> EmpleadosById(string id)
        {
            try
            {

                var empleadoCreate = await _empleadoService.GetEmpleadoById(id);

                if (empleadoCreate == null)
                    return NotFound("No se encontró el empleado.");

                return Ok(empleadoCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el empleado: {ex.GetType().Name} - {ex.Message}");
            }
        }        
        
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadosActivos()
        {
            try
            {
                var empleados = await _empleadoService.GetEmpleadosActivos();

                if (empleados == null || !empleados.Any())
                    return NotFound("No se encontraron empleados.");

                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los empleados: {ex.GetType().Name} - {ex.Message}");
            }
        }
    }
}
