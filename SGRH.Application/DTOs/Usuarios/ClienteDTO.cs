

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Usuarios
{
    public class ClienteDTO : BaseDTO
    {
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }
    }
}
