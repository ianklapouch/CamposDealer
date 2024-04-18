using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CamposDealer.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    [Display(Name = "Nome")]
    [Required]
    public string? NmCliente { get; set; }
    [Required]
    public string? Cidade { get; set; }
}
