

namespace SGRH.Application.DTOs.Habitacion.TarifaDto
{
    public class UpdateTarifaDto
    {
        public int IdTarifa { get; set; }

        public int IdHabitacion { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public decimal PrecioPorNoche { get; set; }

        public decimal Descuento { get; set; }

        public string Descripcion { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
