

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Habitacion
{
    public class TarifaDTO : BaseDTO
    {
        public int IdTarifa { get; set; }

        public int IdHabitacion { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public decimal PrecioPorNoche { get; set; }

        public decimal Descuento { get; set; }

        public string Descripcion { get; set; }
    }
}
