using Inventario.interfaces;
using Inventario.interfaces.UnidadMedida;
using Inventario.models.Categoria;
using Inventario.models.UnidadDeMedida;
using Inventario.repositories;
using Inventario.Utils;

namespace Inventario.services
{
    public class UnidadMedidaService :IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;
        private readonly IAsignaciones _AsinacionesService;
        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository, IAsignaciones asignacionesService)
        {
            _unidadMedidaRepository = unidadMedidaRepository;
            _AsinacionesService = asignacionesService;
        }

        public async Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidas()
        {

            var unidadMedida = await _unidadMedidaRepository.GetUnidadesMedida();
            if (unidadMedida == null)
            {
                throw new KeyNotFoundException("Lista de unidad de medidas Vacia.");
            }
            var unidadMedidaDto = unidadMedida.Select(e => new UnidaDeMedidaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Abreviatura = e.Abreviatura,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return unidadMedidaDto;
        }

        public async Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var unidadesMedida = await _unidadMedidaRepository.GetUnidadesMedidaByEmpresaId(empresaId);
            if (unidadesMedida == null)
            {
                throw new KeyNotFoundException("Lista de unidades de medida Vacia.");

            }
            var categoriasDto = unidadesMedida.Select(e => new UnidaDeMedidaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Abreviatura = e.Abreviatura,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return categoriasDto;
        }

        public async Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasActivasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var unidadesMedida = await _unidadMedidaRepository.GetUnidadesMedidaActivasByEmpresaId(empresaId);
            if (unidadesMedida == null)
            {
                throw new KeyNotFoundException("Lista de unidades de medida Vacia.");

            }
            var unidadMedidaDto = unidadesMedida.Select(e => new UnidaDeMedidaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Abreviatura = e.Abreviatura,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return unidadMedidaDto;
        }
        public async Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasActivas()
        {
            var unidadesMedida = await _unidadMedidaRepository.GetUnidadesMedidaActivas();
            if (unidadesMedida == null)
            {
                throw new KeyNotFoundException("Lista de unidades de medida Vacia.");

            }
            var unidadMedidaDto = unidadesMedida.Select(e => new UnidaDeMedidaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Abreviatura =e.Abreviatura,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return unidadMedidaDto;
        }
        public async Task<UnidaDeMedidaDto> GetUnidadMedidasById(string id)
        {
            var unidadMedida = await _unidadMedidaRepository.GetUnidadesMedidaById(id);
            if (unidadMedida == null)
            {
                throw new KeyNotFoundException("Unidad de medida No encontrada.");

            }
            var unidadMedidaDto = new UnidaDeMedidaDto
            {
                Id = unidadMedida.Id!,
                Nombre = unidadMedida.Nombre,
                Abreviatura =unidadMedida.Abreviatura,
                Descripcion = unidadMedida.Descripcion,
                Activo = unidadMedida.activo,
                Empresa = unidadMedida.Empresa?.nombre ?? ""
            };

            return unidadMedidaDto;
        }

        public async Task<UnidaDeMedidaDto> GetUnidadMedidasByIdAndEmpresa(string id)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var unidadMedida = await _unidadMedidaRepository.GetUnidadesMedidaByIdAndEmpresa(id, empresaId);
            if (unidadMedida == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var unidadMedidaDto = new UnidaDeMedidaDto
            {
                Id = unidadMedida.Id!,
                Abreviatura =unidadMedida.Abreviatura,
                Nombre = unidadMedida.Nombre,
                Descripcion = unidadMedida.Descripcion,
                Activo = unidadMedida.activo,
                Empresa = unidadMedida.Empresa?.nombre ?? ""
            };

            return unidadMedidaDto;
        }
        public async Task<UnidaDeMedidaDto> PostUnidadMedidas(UnidadDeMedida unidadMedida)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            unidadMedida.Id = _AsinacionesService.GenerateNewId();
            unidadMedida.updated_at = _AsinacionesService.GetCurrentDateTime();
            unidadMedida.created_at = _AsinacionesService.GetCurrentDateTime();
            unidadMedida.activo = true;
            unidadMedida.Empresa_id = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            unidadMedida.adicionado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            unidadMedida.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            await _unidadMedidaRepository.PostUnidadesMedida(unidadMedida);

            var unidadMedidaDto = new UnidaDeMedidaDto
            {
                Nombre = unidadMedida.Nombre,
                Descripcion = unidadMedida.Descripcion,
                Id = unidadMedida.Id!,
                Abreviatura = unidadMedida.Abreviatura,
                Activo = unidadMedida.activo,
                Empresa = unidadMedida.Empresa.nombre
            };
            return unidadMedidaDto;
        }
        public async Task<UnidaDeMedidaDto> PutUnidadMedidas(string id, UnidadDeMedida unidadMedida)
        {
            var unidadMedidaFound = await _unidadMedidaRepository.GetUnidadesMedidaById(id);

            if (unidadMedidaFound == null)
            {
                throw new KeyNotFoundException("Unidad de medida no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            unidadMedidaFound.ActualizarPropiedades(unidadMedida);
            unidadMedidaFound.activo = unidadMedida.activo;
            unidadMedidaFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            unidadMedidaFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _unidadMedidaRepository.PutUnidadesMedida(unidadMedidaFound);
            return new UnidaDeMedidaDto
            {
                Id = unidadMedidaFound.Id!,
                Nombre = unidadMedidaFound.Nombre,
                Activo = unidadMedidaFound.activo,
                Abreviatura = unidadMedidaFound.Abreviatura,
                Descripcion = unidadMedidaFound.Descripcion,
                Empresa = unidadMedidaFound.Empresa!.nombre ?? "Sin Empresa",
            };
        }
    }
}
