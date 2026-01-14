

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Usuarios
{
    public class UsuarioDTO : BaseDTO
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int IdRolUsuario { get; set; }

        public string Clave { get; set; }
    }
}
