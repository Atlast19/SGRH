

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Habitacion
{
    public class EstadoHabitacionDTO : BaseDTO
    {
        public int IdEstadoHabitacion { get; set; }

        public string Descripcion { get; set; }
    }
}
