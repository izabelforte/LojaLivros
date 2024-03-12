using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaLivros
{
    
        public class Livro 
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public double Preco { get; set; }
            public int Stock { get; set; }

        

        public Livro(string titulo, string autor, double preco, int stock)
            {
                Titulo = titulo;
                Autor = autor;
                Preco = preco;
                Stock = stock;
            }
        }
}
