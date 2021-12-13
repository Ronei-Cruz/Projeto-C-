using System;
using System.IO;
using Series.Classes;
using Series.Enum;

namespace Series
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

        public static void Main(string[] args) 
        {
            string? opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por ultilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarSerie(){
            Console.WriteLine("Listar séries");

            var listaFilme = repositorioFilme.Lista();
            var lista = repositorio.Lista();
            if((lista.Count == 0) && (listaFilme.Count == 0)){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            else if((lista.Count > 0) || (listaFilme.Count > 0)){
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("Séries");
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
                }
                Console.WriteLine("");
                foreach (var filme in listaFilme)
                {
                    var excluido = filme.retornaExcluido();
                    Console.WriteLine("Filmes");
                    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "Excluido" : ""));
                }
            }
        }

        public static void InserirSerie(){
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.Categoria.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Categoria.GetName(typeof(Categoria), i));
            }
            Console.WriteLine("Selecione a categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Selecione o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string? entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string? entradaDescricao = Console.ReadLine();

            if(entradaCategoria == 1){
                Filmes novoFilme = new Filmes(id: repositorio.ProximoId(),
                                        categoria: (Categoria) entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorioFilme.Isere(novoFilme);
            }
            else if (entradaCategoria == 2)
            {
                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        categoria: (Categoria) entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Isere(novaSerie);
            }    
        }

        private static void AtualizarSerie(){
            Console.Write("Digite o Id da série: ");
            
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Categoria.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Categoria.GetName(typeof(Categoria), i));
            }
            Console.WriteLine("Selecione a categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string? entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string? entradaDescricao = Console.ReadLine();

            if(entradaCategoria == 1){
                Filmes AtualizarFilme = new Filmes(id: repositorio.ProximoId(),
                                        categoria: (Categoria) entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorioFilme.Atualizar(indice, AtualizarFilme);
            }
            else if (entradaCategoria == 2)
            {
                Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
                                        categoria: (Categoria) entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Atualizar(indice, atualizaSerie);
            }
        }

        private static void ExcluirSerie(){
            Console.Write("Digite o id do conteúdo: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Visualizar [1]-Filmes ou [2]-Series ");
            int pergunta = int.Parse(Console.ReadLine());
            Console.Write("Digite o id do conteúdo: ");
            int indice = int.Parse(Console.ReadLine());
            if(pergunta == 1){
                var filme = repositorioFilme.RetornaPorId(indice);
                Console.WriteLine(filme);
            }
            else if (pergunta == 2)
            {
                var serie = repositorio.RetornaPorId(indice);
                Console.WriteLine(serie);  
            }
        }

        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar série\n2 - Inserir nova série\n3 - Atualizar série\n4 - Excluir série\n5 - Visualizar série\nC - Limpar tela\nX - Sair");
            Console.WriteLine();

            string? opcaoUsuario = Console.ReadLine().ToUpper();
                   
            return opcaoUsuario;
        }
    }
}