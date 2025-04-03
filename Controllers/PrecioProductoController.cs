using Inventario.interfaces.IMarca;
using Inventario.interfaces.IPrecioProducto;
using Inventario.models.Marca;
using Inventario.models.PrecioProducto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioProductoController : ControllerBase
    {
        private readonly IPrecioProductoService _precioProductoService;
        public PrecioProductoController(IPrecioProductoService precioProductoService)
        {
            _precioProductoService = precioProductoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PrecioProductoDto>>> GetAllPrecioProductoByIdProducto(string id)
        {
            try
            {
                var precioProducto = await _precioProductoService.GetAllPrecioProductoByIdProducto(id);

                return Ok(precioProducto);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet("actual/{id}")]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetActualPrecioProductoByIdProducto(string id)
        {
            try
            {
                var marcas = await _precioProductoService.GetActualPrecioProductoByIdProducto(id);

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("precio/{id}")]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetPrecioProductoByIdProductoById(string id)
        {
            try
            {
                var marcas = await _precioProductoService.GetPrecioProductoByIdProductoById(id);

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        [HttpPost]
        public async Task<ActionResult<PrecioProductoDto>> CrearPrecioProducto(PrecioProductos marca)
        {
            try
            {
                var precioProducto = await _precioProductoService.PostPrecioProducto(marca);

                return Ok(precioProducto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PrecioProductoDto>> updatePrecioProducto(string id, PrecioProductos marca)
        {
            try
            {
                var marcaUpdate = await _precioProductoService.UpdatePrecioProducto(id, marca);

                return Ok(marcaUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
