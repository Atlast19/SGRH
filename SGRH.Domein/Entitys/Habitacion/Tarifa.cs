

using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Tarifas",Schema = "habitacion")]
public sealed class Tarifa : BaseEntity
{
    [Key]
    public int IdTarifa { get; set; }

    public int IdHabitacion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal PrecioPorNoche { get; set; }

    public decimal Descuento { get; set; }

    public string Descripcion { get; set; }



}