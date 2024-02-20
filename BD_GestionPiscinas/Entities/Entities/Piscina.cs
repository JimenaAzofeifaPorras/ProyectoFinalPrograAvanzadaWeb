using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Piscina
{
    public int PiscinaId { get; set; }

    public string? Ubicacion { get; set; }

    public string? Tamano { get; set; }

    public int? Capacidad { get; set; }

    public string? Servicio { get; set; }

    public int? Precio { get; set; }

    public virtual ICollection<PiscinaProducto> PiscinaProductos { get; set; } = new List<PiscinaProducto>();

    public virtual ICollection<PiscinaRepuesto> PiscinaRepuestos { get; set; } = new List<PiscinaRepuesto>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
