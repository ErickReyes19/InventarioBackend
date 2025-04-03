namespace Inventario.models.PrecioProducto
{
    public class PrecioProductoDto
    {
        public string? Id { get; set; }
        public string? Producto_id { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Producto {  get; set; }
    }
}
