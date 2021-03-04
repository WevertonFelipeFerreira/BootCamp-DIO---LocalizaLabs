using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoTransferenciaBancaria.Modelos
{
    public class ContaBancaria
    {
        public ContaBancaria(TipoConta tipoconta, string nome, string cpf, double saldo, double credito)
        {
            TipoConta = tipoconta;
            Nome = nome;
            Cpf = cpf;
            Saldo = saldo;
            Credito = credito;
        }
        private TipoConta TipoConta { get; set; }
        public string Nome { get; private set; }
        private string Cpf { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < Credito*-1) 
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta: {Saldo}\n");
            return true;
        }
        public void Depositar(double ValorDeposito) 
        {
            Saldo += ValorDeposito;
            Console.WriteLine($"Saldo atual da conta: {Saldo}\n");
        }
        public void Transfira(double valorTransf, ContaBancaria contadestino) 
        {
            if (Sacar(valorTransf)) 
            {
                contadestino.Depositar(valorTransf);
            }
        }
        public override string ToString()
        {
            string retorno = "Tipo de conta: " + TipoConta + " | Nome do titular: " + Nome + " | CPF: " + Cpf + " | Saldo: "+Saldo+" | Credito: "+Credito+"\n";
            
            return retorno;
        }
        public  string ExibeNome() 
        {
            return Nome;
        }
        public string ExibeCPF()
        {
            return Cpf;
        }
    }
}
