
using Inventario.models.Producto;

namespace Inventario.interfaces.IProducto
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetProductos();
        Task<IEnumerable<ProductoDto>> GetProductosByEmpresaId();
        Task<IEnumerable<ProductoDto>> GetProductosActivas();
        Task<IEnumerable<ProductoDto>> GetProductosActivasByEmpresaId();
        Task<ProductoDto> GetProductosById(string id);
        Task<ProductoDto> GetProductosByIdAndEmpresa(string id);
        Task<ProductoDto> PostProductos(Producto categoria);
        Task<ProductoDto> PutProductos(string id, Producto categoria);
    }
}
