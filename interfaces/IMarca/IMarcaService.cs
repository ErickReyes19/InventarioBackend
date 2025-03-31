using Inventario.models.Categoria;
using Inventario.models.Marca;

namespace Inventario.interfaces.IMarca
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDto>> GetMarca();
        Task<IEnumerable<MarcaDto>> GetMarcaByEmpresaId();
        Task<IEnumerable<MarcaDto>> GetMarcaActivas();
        Task<IEnumerable<MarcaDto>> GetMarcaActivasByEmpresaId();
        Task<MarcaDto> GetMarcaById(string id);
        Task<MarcaDto> GetMarcaByIdAndEmpresa(string id);
        Task<MarcaDto> PostMarca(Marca marca);
        Task<MarcaDto> PutMarca(string id, Marca nmarca);
    }
}
