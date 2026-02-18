

namespace SGRH.Application.DTOs.Reserva.ReservaDto
{
    public class DeleteReservaDto
    {
        public int IdReserva { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
