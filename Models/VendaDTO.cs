using Newtonsoft.Json;

namespace CamposDealer.Models
{
    public class VendaDTO
    {
        [JsonProperty("dthVenda")]
        public DateTime DthVenda { get; set; }
        [JsonProperty("idCliente")]
        public string? IdCliente { get; set; }
        [JsonProperty("idProduto")]
        public string? IdProduto { get; set; }
        [JsonProperty("qtdVenda")]
        public string? QtdVenda { get; set; }
        [JsonProperty("vlrUnitarioVenda")]
        public string? VlrUnitarioVenda { get; set; }
    }
}
