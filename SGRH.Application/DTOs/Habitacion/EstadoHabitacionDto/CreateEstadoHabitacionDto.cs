

namespace SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto
{
    public class CreateEstadoHabitacionDto
    {
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
