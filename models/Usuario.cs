using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models;

public partial class Usuario
{
    [Key]
    [StringLength(36)]
    [ForeignKey("Empleado")]
    public string id { get; set; }

    [Required]
    [StringLength(50)]
    public string usuario { get; set; }

    [Required]
    public string contrasena { get; set; }

    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }

    public string role_id { get; set; }

    [Required]
    [Column(TypeName = "bit")]
    public bool activo { get; set; } = true;

    public Role Role { get; set; }

    public Empleado Empleado { get; set; }
}
