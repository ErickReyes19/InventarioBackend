using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Producto
{
    [Key]
    [StringLength(36)]
    public string? Id { get; set; }
    [StringLength(36)]
    public string? Empresa_id { get; set; }

    [StringLength(36)]
    public string? Marca_id { get; set; }

    [StringLength(36)]
    public string? Categoria_id { get; set; }
    [StringLength(36)]
    public string? UnidadMedida_id { get; set; }
    public string Nombre { get; set; }
    public string Sku { get; set; }
    public string Descripcion { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool activo { get; set; } = true;
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }

    public string? adicionado_por { get; set; }
    public string? modificado_por { get; set; }
    [ForeignKey("Empresa_id")]
    public Empresa? Empresa { get; set; }    

    [ForeignKey("Marca_id")]
    public Marca? Marca { get; set; }

    [ForeignKey("Categoria_id")]
    public Categoria? Categoria { get; set; }
    
    [ForeignKey("UnidadMedida_id")]
    public UnidadDeMedida? UnidadMedida { get; set; }

}
