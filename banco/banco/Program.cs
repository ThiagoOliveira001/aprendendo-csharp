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
            double valor;
            Caixa cx = new Caixa();
            Menu:
            for (;;)
            {
                Console.WriteLine("Opcoes");
                Console.WriteLine("1 - Criar conta corrente");
                Console.WriteLine("2 - Criar conta poupanca");
                Console.WriteLine("3 - Ver contas");
                Console.WriteLine("0 - Encerrar operacao");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1 || opcao == 2)
                {
                    Console.WriteLine("Deposito inicial:");
                    double saldo = Convert.ToDouble(Console.ReadLine());
                    if (opcao == 1)
                    {
                        Console.WriteLine("Numero da conta: {0}", cx.criarContaCorrente(saldo));
                        continue;
                    }
                    else if (opcao == 2)
                    {
                        Console.WriteLine("Numero da conta: {0}", cx.criarContaPoupanca(saldo));
                        continue;
                    }
                }
                else if (opcao == 3) 
                {
                    Console.WriteLine("Selecione a conta desejada: " + "\n" + cx.getContas());
                    int conta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(cx.setConta(conta));
                }
                else if (opcao == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opcao invalida!");
                    break;
                }

                MenuConta:
                for (; ; )
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
                            cx.depositar(valor);
                            goto MenuConta;
                        case 2:
                            Console.WriteLine("Valor do saque:");
                            valor = Convert.ToDouble(Console.ReadLine());
                            cx.sacar(valor);
                            goto MenuConta;
                        case 3:
                            Console.WriteLine("Saldo: R${0}", cx.getSaldo());
                            goto MenuConta;
                        case 0:
                            goto Menu;
                        default:
                            Console.WriteLine("Opcao invalida!");
                            goto MenuConta;
                    }
                }
            }
        }
    }
}
