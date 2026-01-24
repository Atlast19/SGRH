

namespace SGRH.Application.DTOs.Usuarios.UsuarioDto
{
    public class UpdateUsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int IdRolUsuario { get; set; }

        public string Clave { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
