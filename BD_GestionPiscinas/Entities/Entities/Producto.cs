using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<PiscinaProducto> PiscinaProductos { get; set; } = new List<PiscinaProducto>();
}
