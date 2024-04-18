using Newtonsoft.Json;

namespace CamposDealer.Models;

public class ProdutoDTO
{
    [JsonProperty("dscProduto")]
    public string? DscProduto { get; set; }
    [JsonProperty("vlrUnitario")]
    public string? VlrUnitario { get; set; }
}
