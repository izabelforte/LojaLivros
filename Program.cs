using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LojaLivros
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Loja> listaLoja = new List<Loja>();
            Loja loja1 = new Loja("Livros&cia", "Rua das flores,2");
            listaLoja.Add(loja1 );
            
            Livro livro1 = new Livro("Fundamentos de Csharp","Igor Lima",20.0,5);
            Livro livro2 = new Livro("Fundamentos de Java para WEB", "Rui Monteiro", 25.0, 3);
            Livro livro3 = new Livro("Fundamentos de SQL", "Luis Reis", 15.0, 10);
            Livro livro4 = new Livro("Fundamentos de C++", "Renato ", 21.0, 10);

            loja1.listaLivros.Add(livro1);
            loja1.listaLivros.Add(livro2);
            loja1.listaLivros.Add(livro3);
            loja1.listaLivros.Add(livro4);

            //----------------------------------------------------

            //List<Cliente> listaCliente = new List<Cliente>();
            Dictionary<int, Cliente> listaClientes = new Dictionary<int, Cliente>();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Bem-vindo(a) à Biblioteca:");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Registar novo cliente");
                Console.WriteLine("2 - Realizar compra");
                Console.WriteLine("0 - Sair");

                int resposta = Convert.ToInt32(Console.ReadLine());



                switch (resposta)
                {
                    case 1:
                        //Registo do Cliente

                        /*Pedir para o utilizador incluir os seus dados (serão inseridos na lista cliente)
                         * criar um objeto Cliente com os dados fornecidos
                         * Adicionar Cliente a lista de clientes */
                        Console.WriteLine("Digite os dados:");
                        Console.WriteLine("Nif:");
                        int nif = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nome:");
                        string nome = Console.ReadLine();

                        // Criando o objeto Cliente e adicionando-o ao dicionario
                        
                        Cliente cliente = new Cliente(nif, nome);
                        listaClientes.Add(nif, cliente);
                        break;
               
                    case 2:
                        //procurar por nif
                        Console.WriteLine("Digite o NIF do cliente:");
                        int nifClienteCompra = Convert.ToInt32(Console.ReadLine());
                        //array para guardar os indices dos livros (ex: livro1, livro2...)
                        string[] livroIndices;
                        //lista criada para armazenar os livros selecionados pelo cliente
                        List<Livro> livrosSelecionados = new List<Livro>();

                        // Verificar se o cliente existe no dicionário
                        if (listaClientes.ContainsKey(nifClienteCompra))
                        {
                            Cliente clienteCompra = listaClientes[nifClienteCompra];

                            //mostra todos os livros da lista
                            Console.WriteLine("Livros disponíveis:");
                            for (int i = 0; i < loja1.listaLivros.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {loja1.listaLivros[i].Titulo} - {loja1.listaLivros[i].Preco:C2}");
                            }
                            //selecionar o livro pelo numero
                            Console.WriteLine("Digite o número do(s) livro(s) que deseja comprar (separados por vírgula):");
                            string inputLivros = Console.ReadLine();
                            livroIndices = inputLivros.Split(',');
                            
                            foreach (string indice in livroIndices)
                            {
                                //convertendo indice da matrix e o -1 é para identificar a posição real do elemento 
                                int livroIndex = int.Parse(indice) - 1;
                                if (livroIndex >= 0 && livroIndex < loja1.listaLivros.Count)
                                {
                                    livrosSelecionados.Add(loja1.listaLivros[livroIndex]);
                                }
                            }
                            //datetime.now converte a data atual para string = parametro do construtor da classe Compra
                            Compra compra = new Compra(DateTime.Now.ToString("yyyy-MM-dd"), clienteCompra, 0);
                            //adiciona os livrosSelecionados a lista "livrosComprados" da classe Compra. (AddRange - adiciona tudo de uma vez)
                            compra.livrosComprados.AddRange(livrosSelecionados);
                            compra.CalcularValorTotal();

                            //adiciona a compra a "listaCompras" da classe Cliente.
                            clienteCompra.listaCompras.Add(compra);
                            Console.WriteLine("Compra realizada com sucesso.");

                            //------código para imprimir a compra na tela------
                            Console.WriteLine("Imprimir? 1-sim / 2 - não");
                            int respostaimprimir = Convert.ToInt32(Console.ReadLine());
                            if (respostaimprimir == 1)
                            {
                                
                                string nomeArquivo = $"compra_{DateTime.Now:yyyyMMddHHmmss}.txt";
                                using (StreamWriter writer = new StreamWriter(nomeArquivo))
                                {
                                    writer.WriteLine("** Compra **");
                                    writer.WriteLine($"Data: {compra.Data}");
                                    writer.WriteLine("Cliente:");
                                    writer.WriteLine($"NIF: {clienteCompra.Nif}");
                                    writer.WriteLine($"Nome: {clienteCompra.Nome}");
                                    writer.WriteLine("Livros:");
                                    foreach (Livro livro in livrosSelecionados)
                                    {
                                        writer.WriteLine($"{livro.Titulo} - {livro.Preco:C2}");
                                    }
                                    writer.WriteLine($"Valor Total: {compra.ValorTotal:C2}");
                                }

                                using (StreamReader leitor = new StreamReader(nomeArquivo))
                                {
                                    string linha;
                                    //loop para imprimir cada linha de arquivo até que não haja mais linhas para ler
                                    while ((linha = leitor.ReadLine()) != null)
                                    {
                                        Console.WriteLine(linha);
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Obrigada por comprar connosco!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                        break;

                    case 0:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }


            }

        }

    }   
}
