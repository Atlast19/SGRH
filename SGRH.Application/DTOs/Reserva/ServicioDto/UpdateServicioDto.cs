

namespace SGRH.Application.DTOs.Reserva.ServicioDto
{
    public class UpdateServicioDto
    {
        public int IdServicio { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
