

namespace SGRH.Application.DTOs.Habitacion.CategoriumDto
{
    public class CreateCategoriumDto
    {
        public string Descripcion { get; set; }

        public int IdServicio { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
