

namespace SGRH.Application.DTOs.Habitacion.PisoDto
{
    public class UpdatePisoDto
    {
        public int IdPiso { get; set; }

        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
