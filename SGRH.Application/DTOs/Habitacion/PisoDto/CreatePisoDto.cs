

namespace SGRH.Application.DTOs.Habitacion.PisoDto
{
    public class CreatePisoDto
    {
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
