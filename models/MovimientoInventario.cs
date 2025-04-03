using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum TipoMovimiento
{
    Entrada,
    Salida
}

public class MovimientoInventario
{
    [Key]
    [StringLength(36)]
    public string? Id { get; set; }

    public string? Producto_id { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public TipoMovimiento Tipo { get; set; }  

    public DateTime Fecha { get; set; }

    public DateTime? Created_at { get; set; }

    public DateTime? Updated_at { get; set; }

    public string? Adicionado_por { get; set; }

    public string? Modificado_por { get; set; }

    [ForeignKey("Producto_id")]
    public Producto? Producto { get; set; }
}
