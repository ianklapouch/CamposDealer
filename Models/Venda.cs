using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CamposDealer.Models;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }
    public required int IdCliente { get; set; }
    public required int IdProduto { get; set; }
    [Display(Name = "Quantidade do produto")]
    public required int QtdVenda { get; set; }
    [Display(Name = "Valor Unitário")]
    [Column(TypeName = "decimal(18, 2)")]
    public required decimal VlrUnitarioVenda { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Data Venda")]
    public required DateTime DthVenda { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Valor da Venda")]
    public required decimal VlrTotalVenda { get; set; }
    public Cliente? Cliente { get; set; }
    public Produto? Produto { get; set; }
}
