﻿
namespace Inventario.Models;

public partial class Empleado
{
    public string id { get; set; }

    public string nombre { get; set; }

    public string apellido { get; set; }

    public string correo { get; set; }

    public int? edad { get; set; }

    public string genero { get; set; }

    public bool? activo { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();


}