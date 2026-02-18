

namespace SGRH.Application.DTOs.Habitacion.CategoriumDto
{
    public class DeleteCategoriumDto
    {
        public int IdCategoria { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
