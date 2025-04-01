namespace Inventario.interfaces.UnidadMedida
{
    public interface IUnidadMedidaRepository
    {
        Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedida();
        Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaByEmpresaId(string id);
        Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaActivas();
        Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaActivasByEmpresaId(string id);
        Task<UnidadDeMedida> GetUnidadesMedidaById(string id);
        Task<UnidadDeMedida> GetUnidadesMedidaByIdAndEmpresa(string id, string idEmpresa);
        Task<UnidadDeMedida> PostUnidadesMedida(UnidadDeMedida unidadMedida);
        Task<UnidadDeMedida> PutUnidadesMedida(UnidadDeMedida unidadMedida);
    }
}
