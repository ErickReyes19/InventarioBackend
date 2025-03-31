using Inventario.models.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> getCategorias()
        {
            try
            {
                var categorias = await _categoriaService.GetCategorias();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw;
            }

        }        
        [HttpGet("porempresa")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> getCategoriasByEmpresa()
        {
            try
            {
                var categorias = await _categoriaService.GetCategoriasByEmpresaId();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> getCategoriasActivas()
        {
            try
            {
                var categorias = await _categoriaService.GetCategoriasActivas();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas/empresa")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> getCategoriasActivasByEmpresaId()
        {
            try
            {
                var categorias = await _categoriaService.GetCategoriasActivasByEmpresaId();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaById(string id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaById(id);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                throw;
            }
        }          
        [HttpGet("{id}/empresa")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaByIdAndEmpresa(string id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaByIdAndEmpresa(id);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> createCategoria(Categoria categoria)
        {
            try
            {
                var categorias = await _categoriaService.PostCategoria(categoria);

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaDto>> updateCategoria(string id, Categoria categoria)
        {
            try
            {
                var categoriaUpdate = await _categoriaService.PutCategoria(id, categoria);

                return Ok(categoriaUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
