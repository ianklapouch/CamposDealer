using System.ComponentModel.DataAnnotations;

namespace CamposDealer.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    [Display(Name = "Nome")]
    public required string NmCliente { get; set; }
    public required string Cidade { get; set; }
}
