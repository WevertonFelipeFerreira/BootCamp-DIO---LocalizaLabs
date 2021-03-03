using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CadastroDeAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalAlunos = 15;
            Aluno[] alunos = new Aluno[totalAlunos];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X") 
            {
                switch (opcaoUsuario) 
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else throw new ArgumentException("Valor da nota deve ser decimal");
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        Console.Clear();
                        break;
                    case "2":
                        foreach (var alun in alunos) 
                        {
                            if (!string.IsNullOrEmpty(alun.Nome))
                            {
                                Console.WriteLine("ALUNO: {0} - NOTA: {1}", alun.Nome, alun.Nota);
                            }
                }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int nmrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++) 
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome)) 
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nmrAlunos++;
                            }
                        }
                        decimal media = notaTotal / nmrAlunos;
                        var conceitoGeral = new Conceito();
                        if (media < 2)
                        {
                            conceitoGeral = Conceito.E;
                        } 
                        else if (media < 4) 
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (media < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }else if (media < 8) 
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else conceitoGeral = Conceito.A;
                        Console.WriteLine($"A média dos alunos é: {Math.Round(media,1)} - CONCEITO: {conceitoGeral}");
                        break;
                    case "4":
                        for (int i = 0; i < alunos.Length; i++) 
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome)) 
                            {
                            Console.WriteLine($"Aluno {alunos[i].Nome} foi removido");
                            alunos[i].Nome = null;
                            alunos[i].Nota = 0;
                            }
                        }
                        break;
                    case "5":
                        Console.Clear();break;
                    default:
                        throw new ArgumentOutOfRangeException("As opcões só vai ate 3");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }


        }
        public static string ObterOpcaoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine("1- Cadastrar Aluno");
            Console.WriteLine("2- Listar Aluno");
            Console.WriteLine("3- Calcular Média Geral");
            Console.WriteLine("4- Zerar lista de alunos");
            Console.WriteLine("5- Limpar Console");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
