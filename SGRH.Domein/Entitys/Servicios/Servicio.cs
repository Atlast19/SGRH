

using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Servicios",Schema ="servicio")]
public sealed class Servicio : BaseEntity
{
    [Key]
    public int IdServicio { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }


}