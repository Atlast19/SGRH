
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Cliente", Schema = "usuario")]
public sealed class Cliente : BaseEntity
{
    [Key]
    public int IdCliente { get; set; }

    public string TipoDocumento { get; set; }

    public string Documento { get; set; }

    public string NombreCompleto { get; set; }

    public string Correo { get; set; }


}