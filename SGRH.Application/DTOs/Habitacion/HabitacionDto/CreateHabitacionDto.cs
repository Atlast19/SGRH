
namespace SGRH.Application.DTOs.Habitacion.HabitacionDto
{
    public class CreateHabitacionDto
    {
        public string Numero { get; set; }

        public string Detalle { get; set; }

        public decimal Precio { get; set; }

        public int IdEstadoHabitacion { get; set; }

        public int IdPiso { get; set; }

        public int IdCategoria { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
