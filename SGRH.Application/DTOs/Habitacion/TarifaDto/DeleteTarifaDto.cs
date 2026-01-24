

namespace SGRH.Application.DTOs.Habitacion.TarifaDto
{
    public class DeleteTarifaDto
    {
        public int IdTarifa { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
