namespace Inventario.interfaces.IPrecioProducto
{
    public interface IPrecioProductoRepository
    {
        Task<IEnumerable<PrecioProductos>> GetAllPrecioProductoByIdProducto(string id);
        Task<PrecioProductos> GetActualPrecioProductoByIdProducto(string id);
        Task<PrecioProductos> GetPrecioProductoByIdProductoById(string id);
        Task<PrecioProductos> UpdatePrecioProducto(PrecioProductos precioProducto);
        Task<PrecioProductos> PostPrecioProducto( PrecioProductos precioProducto);
        Task<PrecioProductos> PutPrecioProducto(PrecioProductos precioProducto);
    }
}
