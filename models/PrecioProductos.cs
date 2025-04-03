using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class PrecioProductos
{
    [Key]
    [StringLength(36)]
    public string? Id { get; set; }
    public string? Producto_id { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public string? adicionado_por { get; set; }
    public string? modificado_por { get; set; }
    [ForeignKey("Producto_id")]
    public Producto? Producto { get; set; }
}
