

namespace SGRH.Application.DTOs.Usuarios.RolUsuarioDto
{
    public class CreateRolUsuarioDto
    {
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
