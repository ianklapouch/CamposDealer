using CamposDealer.Data;
using CamposDealer.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Security.Policy;

namespace CamposDealer.Models;

public static class SeedData
{
    private static readonly string CLIENTE_URL = "https://camposdealer.dev/Sites/TesteAPI/cliente";
    private static readonly string PRODUTO_URL = "https://camposdealer.dev/Sites/TesteAPI/produto";
    private static readonly string VENDA_URL = "https://camposdealer.dev/Sites/TesteAPI/venda";
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {

        using var context = new CamposDealerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CamposDealerContext>>());

        using HttpClient httpClient = new();



        if (!context.Cliente.Any())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(CLIENTE_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = TratamentosJson(jsonString);

                    List<ClienteDTO>? clienteDTOs = JsonConvert.DeserializeObject<List<ClienteDTO>>(jsonString);
                    if (clienteDTOs is not null)
                    {
                        List<Cliente> clientes = ConversorDeDTO.ConverteLista(clienteDTOs);

                        if (clientes is not null && clientes.Count != 0)
                        {
                            context.Cliente.AddRange(clientes.AsEnumerable());
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Falha na requisição HTTP, Endpoint: {CLIENTE_URL}, Código do Error: ${response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        if (!context.Produto.Any())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(PRODUTO_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = TratamentosJson(jsonString);

                    List<ProdutoDTO>? produtoDTOs = JsonConvert.DeserializeObject<List<ProdutoDTO>>(jsonString);
                    if (produtoDTOs is not null)
                    {
                        List<Produto> produtos = ConversorDeDTO.ConverteLista(produtoDTOs);

                        if (produtos is not null && produtos.Count != 0)
                        {
                            context.Produto.AddRange(produtos.AsEnumerable());
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Falha na requisição HTTP, Endpoint: {PRODUTO_URL}, Código do Error: ${response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        if (!context.Venda.Any())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(VENDA_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = TratamentosJson(jsonString);

                    List<VendaDTO>? vendaDTOs = JsonConvert.DeserializeObject<List<VendaDTO>>(jsonString);
                    if (vendaDTOs is not null)
                    {
                        List<Venda> vendas = ConversorDeDTO.ConverteLista(vendaDTOs);

                        if (vendas is not null && vendas.Count != 0)
                        {
                            context.Venda.AddRange(vendas.AsEnumerable());
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Falha na requisição HTTP, Endpoint: {VENDA_URL}, Código do Error: ${response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }


    }
    private static string TratamentosJson(string jsonString)
    {
        //Tratamentos que foram necessários adicionar para conseguir converter as respostas da API externa para os Models da aplicação
        if (string.IsNullOrEmpty(jsonString))
        {
            return jsonString;
        }

        jsonString = jsonString.Replace("\\", "");
        jsonString = jsonString[1..^1];

        return jsonString;
    }
}
