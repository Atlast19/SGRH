
namespace SGRH.Application.DTOs.Usuarios.ClienteDto
{
    public class CreateClienteDto
    {
        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public bool? Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
