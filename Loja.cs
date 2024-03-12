using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaLivros
{
    class Loja
    {
        public string Nome {  get; set; }
        public string Morada { get; set; }
        public List<Livro> listaLivros { get; } = new List<Livro>();



        public Loja(string nome, string morada)
        {
            Nome = nome; Morada = morada;
        }

    }
}
