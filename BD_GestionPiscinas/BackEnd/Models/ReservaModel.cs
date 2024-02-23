namespace BackEnd.Models
{
    public class ReservaModel
    {
        public int ReservaId { get; set; }

        public int? ClienteId { get; set; }

        public int? PiscinaId { get; set; }

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }
    }
}
