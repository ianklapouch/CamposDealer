using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealer.Models;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }
    [Display(Name = "Nome")]
    public required string DscProduto { get; set; }
    [Display(Name = "Valor Unitário")]
    [Column(TypeName = "decimal(18, 2)")]
    public required decimal VlrUnitario { get; set; }
}
