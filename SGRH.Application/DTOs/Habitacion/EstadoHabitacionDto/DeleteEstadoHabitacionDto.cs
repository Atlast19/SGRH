

namespace SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto
{
    public class DeleteEstadoHabitacionDto
    {
        public int IdEstadoHabitacion { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
