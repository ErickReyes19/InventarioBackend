using Inventario.models.Categoria;
using Inventario.models.UnidadDeMedida;

namespace Inventario.interfaces.UnidadMedida
{
    public interface IUnidadMedidaService
    {
        Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidas();
        Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasByEmpresaId();
        Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasActivas();
        Task<IEnumerable<UnidaDeMedidaDto>> GetUnidadMedidasActivasByEmpresaId();
        Task<UnidaDeMedidaDto> GetUnidadMedidasById(string id);
        Task<UnidaDeMedidaDto> GetUnidadMedidasByIdAndEmpresa(string id);
        Task<UnidaDeMedidaDto> PostUnidadMedidas(UnidadDeMedida unidadMedida);
        Task<UnidaDeMedidaDto> PutUnidadMedidas(string id, UnidadDeMedida unidadMedida);
    }
}
