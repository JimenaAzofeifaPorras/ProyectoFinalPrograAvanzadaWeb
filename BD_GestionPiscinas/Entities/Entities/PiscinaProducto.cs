using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class PiscinaProducto
{
    public int PiscinaId { get; set; }

    public int ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Piscina Piscina { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
