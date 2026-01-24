

namespace SGRH.Application.DTOs.Usuarios.UsuarioDto
{
    public class ReadUsuarioDto
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int IdRolUsuario { get; set; }

        public string Clave { get; set; }
    }
}
