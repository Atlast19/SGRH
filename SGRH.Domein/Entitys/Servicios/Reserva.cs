
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Reserva", Schema = "reserva")]
public sealed class Reserva : BaseEntity
{
    [Key]
    public int IdReserva { get; set; }

    public int IdCliente { get; set; }

    public int IdHabitacion { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public DateTime FechaSalidaConfirmacion { get; set; }

    public decimal PrecioInicial { get; set; }

    public decimal Adelanto { get; set; }

    public decimal PrecioRestante { get; set; }

    public decimal TotalPagado { get; set; }

    public decimal CostoPenalidad { get; set; }

    public string Observacion { get; set; }

}