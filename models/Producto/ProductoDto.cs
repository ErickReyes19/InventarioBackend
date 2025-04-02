namespace Inventario.models.Producto
{
    public class ProductoDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sku { get; set; }
        public bool Activo { get; set; }
        public string Empresa { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string UnidadMedida { get; set; }
    }
}
