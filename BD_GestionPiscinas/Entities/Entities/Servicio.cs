using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Piscina> Piscinas { get; set; } = new List<Piscina>();
}
