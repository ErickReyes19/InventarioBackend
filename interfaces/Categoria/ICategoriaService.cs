using Inventario.models.Categoria;
using Inventario.models.Empresa;


    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetCategorias();
        Task<IEnumerable<CategoriaDto>> GetCategoriasByEmpresaId();
        Task<IEnumerable<CategoriaDto>> GetCategoriasActivas();
        Task<IEnumerable<CategoriaDto>> GetCategoriasActivasByEmpresaId();
        Task<CategoriaDto> GetCategoriaById(string id);
        Task<CategoriaDto> GetCategoriaByIdAndEmpresa(string id);
        Task<CategoriaDto> PostCategoria(Categoria categoria);
        Task<CategoriaDto> PutCategoria( string id, Categoria categoria);
    }
