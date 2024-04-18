using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealer.Models;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }
    [Display(Name = "Nome")]
    [Required]
    public string? DscProduto { get; set; }
    [Display(Name = "Valor Unitário")]
    [Column(TypeName = "decimal(18, 2)")]
    [Required]
    public decimal VlrUnitario { get; set; }
}
