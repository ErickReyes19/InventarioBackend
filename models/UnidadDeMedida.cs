
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UnidadDeMedida
{
    [Key]
    [StringLength(36)]
    public string? Id { get; set; }
    [StringLength(36)]
    public string? Empresa_id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Abreviatura { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool activo { get; set; } = true;
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }

    public string? adicionado_por { get; set; }
    public string? modificado_por { get; set; }
    [ForeignKey("Empresa_id")]
    public Empresa? Empresa { get; set; }
}