

namespace SGRH.Application.DTOs.Usuarios.ClienteDto
{
    public class UpdateClienteDto
    {
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int? UsuarioActualizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
