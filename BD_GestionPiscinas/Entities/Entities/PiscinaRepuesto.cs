using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class PiscinaRepuesto
{
    public int PiscinaId { get; set; }

    public int RepuestoId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Piscina Piscina { get; set; } = null!;

    public virtual Repuesto Repuesto { get; set; } = null!;
}
