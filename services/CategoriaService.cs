using Inventario.interfaces;
using Inventario.models.Categoria;
using Inventario.Utils;

namespace Inventario.services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAsignaciones _AsinacionesService;

        public CategoriaService (ICategoriaRepository categoriaRepository, IAsignaciones asignacionesService)
        {
            _categoriaRepository = categoriaRepository;
            _AsinacionesService = asignacionesService;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategorias()
        {

            var categorias = await _categoriaRepository.GetCategorias();
            if (categorias == null)
            {
                throw new KeyNotFoundException("Lista de categorias Vacia.");
            }
            var categoriasDto = categorias.Select(e => new CategoriaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return categoriasDto;
        }
        public async Task<IEnumerable<CategoriaDto>> GetCategoriasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var categorias = await _categoriaRepository.GetCategoriasByEmpresaId(empresaId);
            if (categorias == null)
            {
                throw new KeyNotFoundException("Lista de categorias Vacia.");

            }
            var categoriasDto = categorias.Select(e => new CategoriaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return categoriasDto;
        }            
        public async Task<IEnumerable<CategoriaDto>> GetCategoriasActivasByEmpresaId()
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var categorias = await _categoriaRepository.GetCategoriaActivasByEmpresaId(empresaId);
            if (categorias == null)
            {
                throw new KeyNotFoundException("Lista de categorias Vacia.");

            }
            var categoriasDto = categorias.Select(e => new CategoriaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return categoriasDto;
        }          
        public async Task<IEnumerable<CategoriaDto>> GetCategoriasActivas()
        {
            var categorias = await _categoriaRepository.GetCategoriaActivas();
            if (categorias == null)
            {
                throw new KeyNotFoundException("Lista de categorias Vacia.");

            }
            var categoriasDto = categorias.Select(e => new CategoriaDto
            {
                Id = e.Id!,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Activo = e.activo,
                Empresa = e.Empresa?.nombre ?? ""
            });

            return categoriasDto;
        }        
        public async Task<CategoriaDto> GetCategoriaById(string id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var categoriasDto = new CategoriaDto
            {
                Id = categoria.Id!,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Activo = categoria.activo,
                Empresa = categoria.Empresa?.nombre ?? ""
            };

            return categoriasDto;
        }        
        public async Task<CategoriaDto> GetCategoriaByIdAndEmpresa(string id)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            var empresaId = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            var categoria = await _categoriaRepository.GetCategoriaByIdAndEmpresa(id, empresaId);
            if (categoria == null)
            {
                throw new KeyNotFoundException("Categoria No encontrada.");

            }
            var categoriasDto = new CategoriaDto
            {
                Id = categoria.Id!,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Activo = categoria.activo,
                Empresa = categoria.Empresa?.nombre ?? ""
            };

            return categoriasDto;
        }

        public async Task<CategoriaDto> PostCategoria(Categoria categoria)
        {
            var token = _AsinacionesService.GetTokenFromHeader();
            categoria.Id = _AsinacionesService.GenerateNewId();
            categoria.updated_at = _AsinacionesService.GetCurrentDateTime();
            categoria.created_at = _AsinacionesService.GetCurrentDateTime();
            categoria.activo = true;
            categoria.Empresa_id = _AsinacionesService.GetClaimValue(token!, "IdEmpresa") ?? "Sistema";
            categoria.adicionado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            categoria.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";
            await _categoriaRepository.PostCategoria(categoria);

            var categoriaDto = new CategoriaDto
            {
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Id = categoria.Id!,
                Activo = categoria.activo,
                Empresa = categoria.Empresa.nombre
            };
            return categoriaDto;
        }

        public async Task<CategoriaDto> PutCategoria( string id, Categoria categoria)
        {
            var CategoriaFound = await _categoriaRepository.GetCategoriaById(id);

            if (CategoriaFound == null)
            {
                throw new KeyNotFoundException("Categoria no encontrada.");
            }
            var token = _AsinacionesService.GetTokenFromHeader();
            CategoriaFound.ActualizarPropiedades(categoria);
            CategoriaFound.activo = categoria.activo;
            CategoriaFound.updated_at = _AsinacionesService.GetCurrentDateTime();
            CategoriaFound.modificado_por = _AsinacionesService.GetClaimValue(token!, "User") ?? "Sistema";

            await _categoriaRepository.PutCategoria(CategoriaFound);
            return new CategoriaDto
            {
                Id = CategoriaFound.Id!,
                Nombre = CategoriaFound.Nombre,
                Activo = CategoriaFound.activo,
                Descripcion= CategoriaFound.Descripcion,
                Empresa = CategoriaFound.Empresa!.nombre ?? "Sin Empresa",
            };
        }
    }
}
