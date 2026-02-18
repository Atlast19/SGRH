

namespace SGRH.Application.DTOs.Reserva.ServicioDto
{
    public class CreateServicioDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
