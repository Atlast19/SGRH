

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Reserva
{
    public class ServicioDTO : BaseDTO
    {
        public int IdServicio { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
