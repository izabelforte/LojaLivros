using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaLivros
{
    internal class Cliente
    {
        public int Nif { get; set; }
        public string Nome { get; set; }

        public List<Compra> listaCompras { get; } = new List<Compra>();
        
        public Cliente (int nif, string nome)
        {
            Nif = nif;
            Nome = nome;

        }
    }
}
