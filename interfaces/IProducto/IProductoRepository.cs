namespace Inventario.interfaces.IProducto
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<IEnumerable<Producto>> GetProductosByEmpresaId(string id);
        Task<IEnumerable<Producto>> GetProductosActivas();
        Task<IEnumerable<Producto>> GetProductosActivasByEmpresaId(string id);
        Task<Producto> GetProductosById(string id);
        Task<Producto> GetProductosByIdAndEmpresa(string id, string idEmpresa);
        Task<Producto> PostProductos(Producto producto);
        Task<Producto> PutProductos(Producto producto);
    }
}
