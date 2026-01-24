

namespace SGRH.Application.DTOs.Usuarios.ClienteDto
{
    public class ReadClienteDto
    {
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }
    }
}
