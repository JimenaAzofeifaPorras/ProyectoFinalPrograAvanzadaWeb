using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int? ClienteId { get; set; }

    public int? PiscinaId { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Piscina? Piscina { get; set; }
}
