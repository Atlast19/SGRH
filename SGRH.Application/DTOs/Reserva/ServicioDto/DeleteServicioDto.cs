

namespace SGRH.Application.DTOs.Reserva.ServicioDto
{
    public class DeleteServicioDto
    {
        public int IdServicio { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
