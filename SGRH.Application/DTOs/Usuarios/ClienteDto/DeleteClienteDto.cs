

namespace SGRH.Application.DTOs.Usuarios.ClienteDto
{
    public class DeleteClienteDto
    {
        public int IdCliente { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public bool? Estado { get; set; }

        public bool Borrado { get; set; }
    }
}
