using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CamposDealer.Models
{
    public class ClienteDTO
    {
        [JsonProperty("nmCliente")]
        public string? NmCliente { get; set; }
        [JsonProperty(nameof(Cidade))]
        public string? Cidade { get; set; }
    }
}
