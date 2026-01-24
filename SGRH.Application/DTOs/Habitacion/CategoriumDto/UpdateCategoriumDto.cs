

namespace SGRH.Application.DTOs.Habitacion.CategoriumDto
{
    public class UpdateCategoriumDto
    {
        public int IdCategoria { get; set; }

        public string Descripcion { get; set; }

        public int IdServicio { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
