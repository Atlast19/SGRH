

namespace SGRH.Application.DTOs.Habitacion.HabitacionDto
{
    public class UpdateHabitacionDto
    {
        public int IdHabitacion { get; set; }

        public string Numero { get; set; }

        public string Detalle { get; set; }

        public decimal Precio { get; set; }

        public int IdEstadoHabitacion { get; set; }

        public int IdPiso { get; set; }

        public int IdCategoria { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
