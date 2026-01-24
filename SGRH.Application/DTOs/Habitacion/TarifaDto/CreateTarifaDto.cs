

namespace SGRH.Application.DTOs.Habitacion.TarifaDto
{
    public class CreateTarifaDto
    {
        public int IdHabitacion { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public decimal PrecioPorNoche { get; set; }

        public decimal Descuento { get; set; }

        public string Descripcion { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
