using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic ct = new ContaCorrente(0,0);
            double valor;

            Console.WriteLine("Opcoes");
            Console.WriteLine("1 - Criar conta corrente");
            Console.WriteLine("2 - Criar conta poupanca");
            int opcao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Numero:");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deposito inicial:");
            double saldo = Convert.ToDouble(Console.ReadLine());
           
           if (opcao == 1)
           {
                ct = new ContaCorrente(numero, saldo);
           }
           else if (opcao == 2)
           {
                ct = new ContaPoupanca(numero, saldo);
           }
           else
           {
                Console.WriteLine("Opcao invalida!");
                opcao = -1;
           }

           while (opcao != 0)
           {
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Saldo");
                Console.WriteLine("0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine()); 
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Valor do deposito:");
                        valor = Convert.ToDouble(Console.ReadLine());
                        ct.depositar(valor);
                        break;
                    case 2:
                        Console.WriteLine("Valor do saque:");
                        valor = Convert.ToDouble(Console.ReadLine());
                        ct.sacar(valor);
                        break;
                    case 3:
                        Console.WriteLine("Saldo: R$" + ct.getSaldo());
                        break;
                    case 0:
                        Console.WriteLine("Tchau!");
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
           }

        }
    }
}
