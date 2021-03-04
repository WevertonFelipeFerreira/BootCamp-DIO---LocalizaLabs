using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AumentoDeSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            double salario, reajuste, novoSalario;
            salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            if (salario >= 0.00 && salario <= 400)
            {
                int percentual = 15;
                reajuste = salario * percentual / 100.00;
                novoSalario = reajuste + salario;
                Console.WriteLine("Novo salario: " + novoSalario.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reajuste ganho: " + reajuste.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Em percentual: " + percentual + " %");
            }
            else if (salario >= 400.01 && salario <= 800.00)
            {
                int percentual = 12;
                reajuste = salario * percentual / 100.00;
                novoSalario = reajuste + salario;
                Console.WriteLine("Novo salario: " + novoSalario.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reajuste ganho: " + reajuste.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Em percentual: " + percentual + " %");
            }
            else if (salario >= 800.01 && salario <= 1200.00)
            {
                int percentual = 10;
                reajuste = salario * percentual / 100.00;
                novoSalario = reajuste + salario;
                Console.WriteLine("Novo salario: " + novoSalario.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reajuste ganho: " + reajuste.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Em percentual: " + percentual + " %");
            }
            else if (salario > 1200.01 && salario <= 2000.00)
            {
                int percentual = 7;
                reajuste = salario * percentual / 100.00;
                novoSalario = reajuste + salario;
                Console.WriteLine("Novo salario: " + novoSalario.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reajuste ganho: " + reajuste.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Em percentual: " + percentual + " %");
            }
            else if (salario > 2000.00)
            {
                int percentual = 4;
                reajuste = salario * percentual / 100.00;
                novoSalario = reajuste + salario;
                Console.WriteLine("Novo salario: " + novoSalario.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reajuste ganho: " + reajuste.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Em percentual: " + percentual + " %");
            }
            Console.ReadLine();
        }
    }
}
