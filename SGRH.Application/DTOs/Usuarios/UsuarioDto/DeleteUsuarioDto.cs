

namespace SGRH.Application.DTOs.Usuarios.UsuarioDto
{
    public class DeleteUsuarioDto
    {
        public int IdUsuario { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
