﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models;

public partial class Empleado
{
    [Key]
    [StringLength(36)]
    public string? id { get; set; }    

    [StringLength(36)]
    public string? empresa_id { get; set; }

    [Required]
    [StringLength(100)]
    public string nombre { get; set; }

    [Required]
    [StringLength(100)]
    public string apellido { get; set; }

    [Required]
    [EmailAddress]
    public string correo { get; set; }

    public int? edad { get; set; }

    public string genero { get; set; }

    [Required]
    [Column(TypeName = "bit")]
    public bool activo { get; set; } = true;
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }

    public string? adicionado_por { get; set; }
    public string? modificado_por { get; set; }

    [ForeignKey("empresa_id")]
    public Empresa? Empresa { get; set; }

    public Usuario? Usuario { get; set; }

}