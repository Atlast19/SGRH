

namespace SGRH.Application.DTOs.Habitacion.PisoDto
{
    public class DeletePisoDto
    {
        public int IdPiso { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
