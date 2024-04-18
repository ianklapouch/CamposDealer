using CamposDealer.Models;
using System.Reflection;

namespace CamposDealer.Utils
{
    public static class ConversorDeDTO
    {
        public static List<Venda> ConverteLista(List<VendaDTO> vendaDTOs)
        {
            List<Venda> vendas = [];

            foreach (VendaDTO vendaDTO in vendaDTOs)
            {
                var venda = ConverteDto(vendaDTO);
                if (venda is not null)
                {
                    vendas.Add(venda);
                }
            }

            return vendas;
        }
        public static List<Produto> ConverteLista(List<ProdutoDTO> produtoDTOs)
        {
            List<Produto> produtos = [];

            foreach (ProdutoDTO produtoDTO in produtoDTOs)
            {
                var produto = ConverteDto(produtoDTO);
                if (produto is not null)
                {
                    produtos.Add(produto);
                }
            }

            return produtos;
        }
        public static List<Cliente> ConverteLista(List<ClienteDTO> clienteDTOs)
        {
            List<Cliente> clientes = [];

            foreach (ClienteDTO clienteDTO in clienteDTOs)
            {
                var cliente = ConverteDto(clienteDTO);
                if (cliente is not null)
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }
        private static Cliente? ConverteDto(ClienteDTO clienteDTO)
        {
            if (clienteDTO is null)
            {
                return null;
            }

            if (PossuiTodasAsPropriedades(clienteDTO))
            {
                Cliente cliente = new()
                {
                    NmCliente = clienteDTO.NmCliente,
                    Cidade = clienteDTO.Cidade
                };

                return cliente;
            }

            return null;
        }
        private static Produto? ConverteDto(ProdutoDTO produtoDTO)
        {
            if (produtoDTO is null)
            {
                return null;
            }

            if (PossuiTodasAsPropriedades(produtoDTO))
            {
                Produto produto = new()
                {
                    DscProduto = produtoDTO.DscProduto,
                    VlrUnitario = decimal.Parse(produtoDTO.VlrUnitario)
                };

                return produto;
            }

            return null;
        }
        private static Venda? ConverteDto(VendaDTO vendaDTO)
        {
            if (vendaDTO is null)
            {
                return null;
            }

            if (PossuiTodasAsPropriedades(vendaDTO))
            {
                int qtdVenda = int.Parse(vendaDTO.QtdVenda);
                decimal vlrUnitarioVenda = decimal.Parse(vendaDTO.VlrUnitarioVenda);

                Venda venda = new(qtdVenda, vlrUnitarioVenda)
                {
                    IdCliente = int.Parse(vendaDTO.IdCliente),
                    IdProduto = int.Parse(vendaDTO.IdProduto),
                    DthVenda = vendaDTO.DthVenda
                };

                return venda;
            }

            return null;
        }

        private static bool PossuiTodasAsPropriedades(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);

                if (value == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
