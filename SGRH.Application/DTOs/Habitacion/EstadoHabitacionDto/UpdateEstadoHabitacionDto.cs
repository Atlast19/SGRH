

namespace SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto
{
    public class UpdateEstadoHabitacionDto
    {
        public int IdEstadoHabitacion { get; set; }

        public string Descripcion { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
