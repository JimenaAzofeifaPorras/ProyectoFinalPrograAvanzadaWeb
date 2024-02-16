using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Repuesto
{
    public int RepuestoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<PiscinaRepuesto> PiscinaRepuestos { get; set; } = new List<PiscinaRepuesto>();
}
