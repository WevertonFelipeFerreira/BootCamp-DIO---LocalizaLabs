using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeSeries.Modelos;
using CadastroDeSeries.Modelos.Interface;

namespace CadastroDeSeries
{
  public  class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
          string inicio = optionUser();
          while (inicio != "X") 
           {
               switch (inicio) 
               {
                   case "1":
                       ListarSeries();
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
                    case "6":
                       InsereEstrela();
                        break;
                    case "C":
                       Console.Clear();
                       break;
                   default:
                       throw new ArgumentOutOfRangeException();
      
               }
               inicio = optionUser();
           }
           Console.Clear();
           Console.WriteLine("Obrigado por utilizar nosso sistema!");
            Console.ReadLine();
        }

        private static void InsereEstrela()
        {
            if (repositorio.Lista().Count == 0)
            {
                Console.WriteLine("\nNão ha series cadastradas.\n");
                return;
            }
            Console.Write("Digite o ID da serie para adicionar estrela: ");
            int indiceID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantas estrelas vãos ser adicionadas: ");
            int estrelas = Convert.ToInt32(Console.ReadLine());
            while (estrelas < 1 || estrelas > 5) 
            {
                Console.WriteLine("\nDigite um numero de 1 a 5!\n");
                Console.Write("Digite novamente: ");
                estrelas = Convert.ToInt32(Console.ReadLine());
            }
            repositorio.InsereEstrela(indiceID,estrelas);
        }

        private static void ExcluirSerie()
        {
            if (repositorio.Lista().Count == 0)
            {
                Console.WriteLine("\nNão ha series cadastradas para mostrar.\n");
                return;
            }
            Console.WriteLine("Excluir serie");
            Console.Write("Qual o ID da serie que deseja excluir: ");
            int indiceID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tem certeza que deseja excluir esta serie? S/ ou N/");
            string opcaoEscolha = Console.ReadLine().ToUpper();
            if (opcaoEscolha == "S")
            {
                repositorio.Exclui(indiceID);
            }
            else return;
        }

        private static void AtualizarSerie()
        {
            if (repositorio.Lista().Count == 0)
            {
                Console.WriteLine("\nNão ha series cadastradas para mostrar.\n");
                return;
            }
            Console.WriteLine("Atualizar Serie");
            Console.Write("Digite o ID da serie que deseja atualizar: ");
            int optionID = Convert.ToInt32(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Insira um genero de acordo com a lista acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira o titulo: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Insira o ano: ");
            Console.Write("Insira a descrição: ");
            string entradaDescricao = Console.ReadLine();
            int entradaAno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira a classificação indicativa: ");
            string entradaClassificacao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: optionID, Genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao,classificacao: entradaClassificacao);
            repositorio.Atualiza(optionID,atualizaSerie);

        }

        private static void VisualizarSerie()
        {
            if (repositorio.Lista().Count == 0) 
            {
                Console.WriteLine("\nNão ha series cadastradas para mostrar.\n");
                return;
            }
            Console.Write("Digite o ID da serie: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(repositorio.RetornaPorId(id));
        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nInserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero), i));
            }
                Console.Write("Insira um genero de acordo com a lista acima: ");
                int entradaGenero = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insira o titulo: ");
                string entradaTitulo = Console.ReadLine();
                Console.Write("Insira o ano: ");
                int entradaAno = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insira a descrição: ");
                string entradaDescricao = Console.ReadLine();
                Console.Write("Insira a classificação indicativa: ");
                string entradaClassificacao = Console.ReadLine();

            Serie newSerie = new Serie(id:repositorio.ProximoId(),Genero:(Genero)entradaGenero,titulo: entradaTitulo,ano:entradaAno,descricao:entradaDescricao,classificacao: entradaClassificacao);
            repositorio.Insere(newSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("\nNenhuma série cadastrada.");
                return;
            }
            Console.WriteLine("\nLista de series");
            
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine($"\nID: {serie.retornaID()} - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")}\n");
            }
        }

        public static string optionUser() 
        {
            Console.WriteLine("Cadastro de Series");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Adicionar estrela");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            string option = Console.ReadLine().ToUpper();
            return option;
        }
    }
}
