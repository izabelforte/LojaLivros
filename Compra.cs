using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaLivros
{
    internal class Compra
    {
        public string Data { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }

        public List<Livro> livrosComprados { get; } = new List<Livro>();
        public Compra(string data, Cliente cliente, double valortotal)
        {
            Data = data;
            Cliente = cliente;
            ValorTotal = valortotal;
        }

        public void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (var livro in livrosComprados)
            {
                ValorTotal += livro.Preco;
            }
        }

        public string ObterDetalhesCompra()
        {
            string detalhes = $"Data: {Data}\nCliente: {Cliente.Nif}\nLivros comprados:\n";
            foreach (var livro in livrosComprados)
            {
                detalhes += $"{livro.Titulo} - {livro.Preco:C2}\n";
            }
            detalhes += $"Valor total: {ValorTotal:C2}";
            return detalhes;
        }
        
    }
}
