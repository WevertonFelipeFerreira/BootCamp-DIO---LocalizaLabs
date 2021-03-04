using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoTransferenciaBancaria.Modelos;

namespace AplicacaoTransferenciaBancaria
{
    class Program
    {
        static List<ContaBancaria> contas = new List<ContaBancaria>();
        static void Main(string[] args)
        {
            Inicio();
            Console.WriteLine("Obrigado por utilizar nosso sistema!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            if (contas.Count > 1) {
            Console.Write("Digite o numero da conta que deseja realizar a transferência: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Agora digite o numero da conta que deseja transferir: ");
            int indiceConta2 = int.Parse(Console.ReadLine());
            Console.Write($"De: {contas[indiceConta].Nome}\nPara: {contas[indiceConta2].Nome}\nDigite o valor para transferir: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            contas[indiceConta].Transfira(valorTransferencia,contas[indiceConta2]);
            }else Console.WriteLine("\nNão ha contas suficientes cadastradas para relizar transferência!\n");
        }
        private static void Inicio() 
        {
            string option = OpcaoUsuario();
            while (option.ToUpper() != "X")
            {
                switch (option)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "6":
                        ApagarConta();
                        break;
                    case "7":
                        ProcurarCliente();
                        break;
                    default:
                        break;

                }
                if (option.ToUpper() == "C")
                {
                    Console.Clear();
                }

                option = OpcaoUsuario();
            }
        }
        private static void Depositar()
        {
            if (contas.Count > 0)
            {
                Console.Write("Digite o numero da conta que deseja realizar o deposito: ");
                int indiceConta = int.Parse(Console.ReadLine());
                Console.Write($"Conta de {contas[indiceConta].Nome} foi selecionado.\nDigite o valor para deposito: ");
                double valorDeposito = double.Parse(Console.ReadLine());
                contas[indiceConta].Depositar(valorDeposito);
            }
            else Console.WriteLine("\nNão ha contas cadastradas para depositar!\n");
        }

        private static void Sacar()
        {
            if (contas.Count > 0)
            {
                Console.Write("Digite o numero da conta que deseja realizar o saque: ");
                int indiceConta = int.Parse(Console.ReadLine());
                Console.Write($"Conta de {contas[indiceConta].Nome} foi selecionado.\nDigite o valor para saque: ");
                double valorSaque = double.Parse(Console.ReadLine());
                contas[indiceConta].Sacar(valorSaque);
            }
            else Console.WriteLine("\nNão ha contas cadastradas para sacar!\n");
        }

        private static void ProcurarCliente()
        {
            if (contas.Count > 0)
            {
                Console.Write("Digite o nome do cliente: ");
                string nome = Console.ReadLine();
                for (int i = 0; i < contas.Count; i++)
                {
                    if (nome == contas[i].Nome)
                    {
                        Console.WriteLine($"Dados do cliente {nome} - {contas[i]}");
                    }else Console.WriteLine("Cliente não encontrado!");
                }
                
            }
            else Console.WriteLine("\nNão há clientes cadastrados no sistema!\n");
        }

        private static void ApagarConta()
        {
            if (contas.Count > 0)
            {
                ListarContas();
                Console.Write("Digite o numero a frente a # para excluir a conta: ");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nConta do cliente {contas[numero].ExibeNome()} e portador do cpf {contas[numero].ExibeCPF()} Foi removido do sistema!\n");
                contas.RemoveAt(numero);
            }
            else Console.WriteLine("\nNão há conta para excluir!\n");
        }

        private static void ListarContas()
        {
            if (contas.Count > 0)
            {
                for (int i = 0; i < contas.Count; i++)
                {
                    Console.WriteLine($"#Conta {i} - {contas[i]}");
                }
            }
            else Console.WriteLine("\nNenhuma conta cadastrada!\n");
        }

        private static void InserirContas()
        {
            Console.Write("Inserir contas foi selecionado!\n");
            Console.Write("Qual o tipo de conta: ");
            int tipoDaConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do titular: ");
            string nomeTitular = Console.ReadLine();
            Console.Write("Digite o CPF: ");
            string cpfTit = Console.ReadLine();
            Console.Write("Saldo: ");
            double saldoTit = double.Parse(Console.ReadLine());
            Console.Write("Credito: ");
            double creditoTit = double.Parse(Console.ReadLine());
            ContaBancaria contaNova = new ContaBancaria(tipoconta: (TipoConta)tipoDaConta,
                                 nome: nomeTitular, cpf: cpfTit, saldo: 
                                 saldoTit,credito: creditoTit);
            contas.Add(contaNova);
        }

        public static string OpcaoUsuario() 
        {
            Console.WriteLine("Bem Vindos ao BootBank!");
            Console.WriteLine("Informe a opção desejada: \n");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Depositar");
            Console.WriteLine("5- Transferir");
            Console.WriteLine("6- Apagar conta do sistema");
            Console.WriteLine("7- Procurar dados do cliente pelo nome");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

    }
}
