using Inventario.interfaces.IMarca;
using Inventario.models.Categoria;
using Inventario.models.Marca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> getMarcas()
        {
            try
            {
                var marcas = await _marcaService.GetMarca();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet("porempresa")]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> getMarcasByEmpresa()
        {
            try
            {
                var marcas = await _marcaService.GetMarcaByEmpresaId();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> getMarcasActivas()
        {
            try
            {
                var marcas = await _marcaService.GetMarcaActivas();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas/empresa")]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> getMarcasActivasByEmpresaId()
        {
            try
            {
                var marcas = await _marcaService.GetMarcaActivasByEmpresaId();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaDto>> GetMarcasById(string id)
        {
            try
            {
                var marca = await _marcaService.GetMarcaById(id);

                return Ok(marca);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}/empresa")]
        public async Task<ActionResult<MarcaDto>> GetMarcaByIdAndEmpresa(string id)
        {
            try
            {
                var marca = await _marcaService.GetMarcaByIdAndEmpresa(id);

                return Ok(marca);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<MarcaDto>> createMarca(Marca marca)
        {
            try
            {
                var marcaCreate = await _marcaService.PostMarca(marca);

                return Ok(marcaCreate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MarcaDto>> updateMarca(string id, Marca marca)
        {
            try
            {
                var marcaUpdate = await _marcaService.PutMarca(id, marca);

                return Ok(marcaUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
