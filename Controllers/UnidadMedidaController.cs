using Inventario.interfaces.UnidadMedida;
using Inventario.models.Categoria;
using Inventario.models.UnidadDeMedida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IUnidadMedidaService _unidadMedidaService;
        public UnidadMedidaController(IUnidadMedidaService unidadMedidaService)
        {
            _unidadMedidaService = unidadMedidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidaDeMedidaDto>>> getUnidadMedidas()
        {
            try
            {
                var unidadMedidas = await _unidadMedidaService.GetUnidadMedidas();

                return Ok(unidadMedidas);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet("porempresa")]
        public async Task<ActionResult<IEnumerable<UnidaDeMedidaDto>>> getUnidadMedidasByEmpresa()
        {
            try
            {
                var unidadesMedidas = await _unidadMedidaService.GetUnidadMedidasByEmpresaId();

                return Ok(unidadesMedidas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<UnidaDeMedidaDto>>> getUnidadMedidasActivas()
        {
            try
            {
                var unidadMedidas = await _unidadMedidaService.GetUnidadMedidasActivas();

                return Ok(unidadMedidas);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("activas/empresa")]
        public async Task<ActionResult<IEnumerable<UnidaDeMedidaDto>>> getUnidadMedidasActivasByEmpresaId()
        {
            try
            {
                var unidadMedida = await _unidadMedidaService.GetUnidadMedidasActivasByEmpresaId();

                return Ok(unidadMedida);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetUnidadMedidaById(string id)
        {
            try
            {
                var unidadMedida = await _unidadMedidaService.GetUnidadMedidasById(id);

                return Ok(unidadMedida);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}/empresa")]
        public async Task<ActionResult<CategoriaDto>> GetUnidadMedidaByIdAndEmpresa(string id)
        {
            try
            {
                var unidadMedida = await _unidadMedidaService.GetUnidadMedidasByIdAndEmpresa(id);

                return Ok(unidadMedida);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<UnidaDeMedidaDto>> createUnidadMedida(UnidadDeMedida unidadMedida)
        {
            try
            {
                var unidadMedidaCreate = await _unidadMedidaService.PostUnidadMedidas(unidadMedida);

                return Ok(unidadMedidaCreate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UnidaDeMedidaDto>> updateUnidadMedida(string id, UnidadDeMedida unidadMedida)
        {
            try
            {
                var unidadMedidaUpdate = await _unidadMedidaService.PutUnidadMedidas(id, unidadMedida);

                return base.Ok((object)unidadMedidaUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
