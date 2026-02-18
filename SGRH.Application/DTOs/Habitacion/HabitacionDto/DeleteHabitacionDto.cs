

namespace SGRH.Application.DTOs.Habitacion.HabitacionDto
{
    public class DeleteHabitacionDto
    {
        public int IdHabitacion { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
