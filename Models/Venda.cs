using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CamposDealer.Models;

public class Venda()
{
    [Key]
    public int IdVenda { get; set; }
    [Required]
    public int IdCliente { get; set; }
    [Required]
    public int IdProduto { get; set; }
    [Display(Name = "Quantidade do produto")]
    [Required]
    public int QtdVenda { get; set; }

    [Display(Name = "Valor Unitário")]
    [Column(TypeName = "decimal(18, 2)")]
    [Required]
    public decimal VlrUnitarioVenda { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Data Venda")]
    [Required]
    public DateTime DthVenda { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Valor da Venda")]
    public decimal VlrTotalVenda { get; set; }
    public Cliente? Cliente { get; set; }
    public Produto? Produto { get; set; }

    public void CalcularTotalVenda()
    {
        VlrTotalVenda = QtdVenda * VlrUnitarioVenda;
    }
}
