
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<IEnumerable<Categoria>> GetCategoriasByEmpresaId(string id);
        Task<IEnumerable<Categoria>> GetCategoriaActivas();
        Task<IEnumerable<Categoria>> GetCategoriaActivasByEmpresaId(string id);
        Task<Categoria> GetCategoriaById(string id);
        Task<Categoria> GetCategoriaByIdAndEmpresa(string id, string idEmpresa);
        Task<Categoria> PostCategoria(Categoria categoria);
        Task<Categoria> PutCategoria(Categoria categoria);
    }