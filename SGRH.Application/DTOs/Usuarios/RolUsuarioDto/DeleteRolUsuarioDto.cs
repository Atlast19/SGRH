

namespace SGRH.Application.DTOs.Usuarios.RolUsuarioDto
{
    public class DeleteRolUsuarioDto
    {
        public int IdRolUsuario { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
