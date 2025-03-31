using Inventario.interfaces;
using Inventario.interfaces.IMarca;
using Inventario.models.Categoria;
using Inventario.models.Marca;
using Inventario.Utils;

namespace Inventario.services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _categoriaRepository;
        private readonly IAsignaciones _AsinacionesService;

        public MarcaService(IMarcaRepository marcaRepository, IAsignaciones asignacionesService)
        {
            _categoriaRepository = marcaRepository;
            _AsinacionesService = asignacionesService;
        }

        public async Task<IEnumerable<MarcaDto>> GetMarca()
        {

            var marcas = await _categoriaRepository.GetMarcas();
            if (marcas == null)
            {
                throw new KeyNotFoundException("Lista de marcas Vacia.");
            }
            var marcaDto = marcas.Select(e => new MarcaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return marcaDto;
        }
        public async Task<IEnumerable<MarcaDto>> GetMarcaByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var marcas = await _categoriaRepository.GetMarcasByEmpresaId(empresaId);
            if (marcas == null)
            {
                throw new KeyNotFoundException("Lista de marca Vacia.");

            }
            var marcaDto = marcas.Select(e => new MarcaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return marcaDto;
        }
        public async Task<IEnumerable<MarcaDto>> GetMarcaActivasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var marcas = await _categoriaRepository.GetMarcasActivasByEmpresaId(empresaId);
            if (marcas == null)
            {
                throw new KeyNotFoundException("Lista de marcas Vacia.");

            }
            var marcaDto = marcas.Select(e => new MarcaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return marcaDto;
        }
        public async Task<IEnumerable<MarcaDto>> GetMarcaActivas()
        {
            var marcas = await _categoriaRepository.GetMarcasActivas();
            if (marcas == null)
            {
                throw new KeyNotFoundException("Lista de categorias Vacia.");

            }
            var marcaDto = marcas.Select(e => new MarcaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return marcaDto;
        }
        public async Task<MarcaDto> GetMarcaById(string id)
        {
            var marcas = await _categoriaRepository.GetMarcasById(id);
            if (marcas == null)
            {
                throw new KeyNotFoundException("Marca No encontrada.");

            }
            var marcaDto = new MarcaDto
            {
                Id = marcas.Id!,
                Nombre = marcas.Nombre,
                Descripcion = marcas.Descripcion,
                Activo = marcas.activo,
                Empresa = marcas.Empresa?.nombre ?? ""
            };

            return marcaDto;
        }
        public async Task<MarcaDto> GetMarcaByIdAndEmpresa(string id)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var marca = await _categoriaRepository.GetMarcasByIdAndEmpresa(id, empresaId);
            if (marca == null)
            {
                throw new KeyNotFoundException("Marca No encontrada.");

            }
            var marcaDto = new MarcaDto
            {
                Id = marca.Id!,
                Nombre = marca.Nombre,
                Descripcion = marca.Descripcion,
                Activo = marca.activo,
                Empresa = marca.Empresa?.nombre ?? ""
            };

            return marcaDto;
        }

        public async Task<MarcaDto> PostMarca(Marca marca)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            marca.Id = _AsinacionesService.GenerateNewId();
            marca.updated_at = _AsinacionesService.GetCurrentDateTime();
            marca.created_at = _AsinacionesService.GetCurrentDateTime();
            marca.activo = true;
            marca.Empresa_id = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            marca.adicionado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            marca.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            await _categoriaRepository.PostMarcas(marca);

            var marcaDto = new MarcaDto
            {
                Nombre = marca.Nombre,
                Descripcion = marca.Descripcion,
                Id = marca.Id!,
                Activo = marca.activo,
                Empresa = marca.Empresa.nombre
            };
            return marcaDto;
        }

        public async Task<MarcaDto> PutMarca(string id, Marca marca)
        {
            var MarcaFound = await _categoriaRepository.GetMarcasById(id);

            if (MarcaFound == null)
            {
                throw new KeyNotFoundException("Marca no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            MarcaFound.ActualizarPropiedades(marca);
            MarcaFound.activo = marca.activo;
            MarcaFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            MarcaFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _categoriaRepository.PutMarcas(MarcaFound);
            return new MarcaDto
            {
                Id = MarcaFound.Id!,
                Nombre = MarcaFound.Nombre,
                Activo = MarcaFound.activo,
                Descripcion = MarcaFound.Descripcion,
                Empresa = MarcaFound.Empresa!.nombre ?? "Sin Empresa",
            };
        }
    }
}
