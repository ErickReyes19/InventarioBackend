using Inventario.interfaces.IProducto;
using Inventario.models.Producto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> getProductos()
        {
            try
            {
                var productos = await _productoService.GetProductos();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet("porempresa")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> getProductosByEmpresa()
        {
            try
            {
                var productos = await _productoService.GetProductosByEmpresaId();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> getProductosActivas()
        {
            try
            {
                var productos = await _productoService.GetProductosActivas();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas/empresa")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> getProductosActivasByEmpresaId()
        {
            try
            {
                var productos = await _productoService.GetProductosActivasByEmpresaId();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductosById(string id)
        {
            try
            {
                var producto = await _productoService.GetProductosById(id);

                return Ok(producto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}/empresa")]
        public async Task<ActionResult<ProductoDto>> GetProductosByIdAndEmpresa(string id)
        {
            try
            {
                var producto = await _productoService.GetProductosByIdAndEmpresa(id);

                return Ok(producto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<ProductoDto>> createProductos(Producto producto)
        {
            try
            {
                var productos = await _productoService.PostProductos(producto);

                return Ok(productos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDto>> updateProductos(string id, Producto producto)
        {
            try
            {
                var productoUpdate = await _productoService.PutProductos(id, producto);

                return Ok(productoUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
