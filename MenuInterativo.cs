using System;

namespace TreinamentoAutomacaoONS
{
    class MenuInterativo
    {
        static void Main()
        {
            Biblioteca biblioteca = new Biblioteca();
            int contadorID = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gerenciamento de Biblioteca");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Adicionar Revista");
                Console.WriteLine("3. Listar Itens");
                Console.WriteLine("4. Buscar por Título");
                Console.WriteLine("5. Buscar por Autor");
                Console.WriteLine("6. Emprestar Livro");
                Console.WriteLine("7. Devolver Livro");
                Console.WriteLine("8. Sair\n");
                int opcao = ValidacaoNumerica("Escolha uma opção: ");

                switch (opcao)
                {
                    case (int)OpcoesMenu.AdicionarLivro:
                        contadorID = AdicionarLivro(biblioteca, contadorID);
                        break;

                    case (int)OpcoesMenu.AdicionarRevista:
                        contadorID = AdicionarRevista(biblioteca, contadorID);
                        break;

                    case (int)OpcoesMenu.ListarItens:
                        ListarItens(biblioteca);
                        break;

                    case (int)OpcoesMenu.BuscarPorTitulo:
                        BuscarPorTitulo(biblioteca);
                        break;

                    case (int)OpcoesMenu.BuscarPorAutor:
                        BuscarPorAutor(biblioteca);
                        break;

                    case (int)OpcoesMenu.EmprestarLivro:
                        EmprestarLivro(biblioteca);
                        break;

                    case (int)OpcoesMenu.DevolverLivro:
                        DevolverLivro(biblioteca);
                        break;

                    case (int)OpcoesMenu.Sair:
                        Sair();
                        return;

                    default:
                        Console.Write("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static int AdicionarLivro(Biblioteca biblioteca, int contadorID)
        {
            Console.Clear();
            Console.WriteLine("1. Adicionar Livro\n");
            Console.Write("Título do Livro: ");
            string tituloLivro = Console.ReadLine();
            Console.Write("Autor do Livro: ");
            string autorLivro = Console.ReadLine();
            int anoPublicacaoLivro = ValidacaoNumerica("Ano de Publicação do Livro: ");

            Livro livro = new Livro
            {
                Id = contadorID++,
                Titulo = tituloLivro,
                Autor = autorLivro,
                AnoPublicacao = anoPublicacaoLivro,
                Disponivel = true
            };
            biblioteca.AdicionarItem(livro);
            Console.WriteLine("\nO livro '{0}' foi adicionado na biblioteca.", tituloLivro);
            Continuar();
            return contadorID;
        }
        private static int AdicionarRevista(Biblioteca biblioteca, int contadorID)
        {
            Console.Clear();
            Console.WriteLine("2. Adicionar Revista\n");
            Console.Write("\nTítulo da Revista: ");
            string tituloRevista = Console.ReadLine();
            Console.Write("Autor da Revista: ");
            string autorRevista = Console.ReadLine();
            int anoPublicacaoRevista = ValidacaoNumerica("Ano de Publicação da Revista: ");
            int edicaoRevista = ValidacaoNumerica("Edição da Revista: ");

            Revista revista = new Revista
            {
                Id = contadorID++,
                Titulo = tituloRevista,
                Autor = autorRevista,
                AnoPublicacao = anoPublicacaoRevista,
                Edicao = edicaoRevista
            };
            biblioteca.AdicionarItem(revista);
            Console.WriteLine("\nA revista '{0}' foi adicionado na biblioteca.", tituloRevista);
            Continuar();
            return contadorID;
        }
        private static void ListarItens(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("3. Listar Itens");
            biblioteca.ListarItens();
            Continuar();
        }
        private static void BuscarPorTitulo(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("4. Buscar por Título\n");
            Console.Write("Digite o título do livro ou da revista: ");
            string tituloBusca = Console.ReadLine();
            biblioteca.BuscarPorTitulo(tituloBusca);
            Continuar();
        }
        private static void BuscarPorAutor(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("5. Buscar por Autor\n");
            Console.Write("Digite o autor do livro ou da revista: ");
            string autorBusca = Console.ReadLine();
            biblioteca.BuscarPorAutor(autorBusca);
            Continuar();
        }
        private static void EmprestarLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("6. Emprestar Livro\n");
            int idLivroEmprestar = ValidacaoNumerica("Digite o ID do livro para emprestar: ");
            Livro livroEmprestar = biblioteca.Itens.Find(item => item is Livro && item.Id == idLivroEmprestar) as Livro;

            if (livroEmprestar != null)
            {
                livroEmprestar.EmprestarLivro();
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado ou não é um livro.");
            }
            Continuar();
        }
        private static void DevolverLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("7. Devolver Livro\n");
            int idLivroDevolver = ValidacaoNumerica("Digite o ID do livro para devolver: ");
            Livro livroDevolver = biblioteca.Itens.Find(item => item is Livro && item.Id == idLivroDevolver) as Livro;

            if (livroDevolver != null)
            {
                livroDevolver.DevolverLivro();
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado ou não é um livro.");
            }
            Continuar();
        }
        private static void Sair()
        {
            Console.Clear();
            Console.WriteLine("8. Sair\n");
            Console.Write("Tenha um ótimo dia =)\n");
        }
        public static int ValidacaoNumerica(string textoExibicao)
        {
            int numeroValidado;
            bool validador;

            do
            {
                Console.Write(textoExibicao);

                if (int.TryParse(Console.ReadLine(), out numeroValidado) && numeroValidado > 0)
                {
                    validador = true;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número inteiro positivo.");
                    validador = false;
                }
            } while (!validador);

            return numeroValidado;
        }
        public static void Continuar()
        {
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        enum OpcoesMenu
        {
            AdicionarLivro = 1,
            AdicionarRevista = 2,
            ListarItens = 3,
            BuscarPorTitulo = 4,
            BuscarPorAutor = 5,
            EmprestarLivro = 6,
            DevolverLivro = 7,
            Sair = 8
        }
    }
}