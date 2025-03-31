namespace Inventario.interfaces.IMarca
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcas();
        Task<IEnumerable<Marca>> GetMarcasByEmpresaId(string id);
        Task<IEnumerable<Marca>> GetMarcasActivas();
        Task<IEnumerable<Marca>> GetMarcasActivasByEmpresaId(string id);
        Task<Marca> GetMarcasById(string id);
        Task<Marca> GetMarcasByIdAndEmpresa(string id, string idEmpresa);
        Task<Marca> PostMarcas(Marca marca);
        Task<Marca> PutMarcas(Marca marca);
    }
}
