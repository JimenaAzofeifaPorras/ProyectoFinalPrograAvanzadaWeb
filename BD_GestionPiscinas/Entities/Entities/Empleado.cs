using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public virtual ICollection<Piscina> Piscinas { get; set; } = new List<Piscina>();
}
