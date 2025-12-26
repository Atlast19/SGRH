
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Piso",Schema = "habitacion")]
public sealed class Piso : BaseEntity
{
    [Key]
    public int IdPiso { get; set; }

    public string Descripcion { get; set; }

}