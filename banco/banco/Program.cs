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
            int opcao;
            Caixa cx = new Caixa();
            Simulador sm = new Simulador();
            Cliente clienteLogado = new Cliente();
        MenuCliente:
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Entrar (Digite seu codigo para acessar)");
            Console.WriteLine("3 - Listar Clientes");
            Console.WriteLine("0 - Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Nome:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("CPF:");
                    string cpf = Console.ReadLine();
                    int cod = cx.cadastrarCliente(nome, cpf);
                    if (cod >= 0)
                    {
                        Console.WriteLine("Codigo: {0}", cod);
                    } else
                    {
                        Console.WriteLine("CPF já cadastrado.");
                    }
                    goto MenuCliente;
                case 2:
                    Console.WriteLine("Codigo:");
                    clienteLogado = cx.getCliente(Convert.ToInt32(Console.ReadLine()));
                    goto Menu;
                case 3:
                    Console.WriteLine("Clientes: \n" + cx.getClientes());
                    goto MenuCliente;
                case 0:
                    goto Finish;
                default:
                    Console.WriteLine("Opção inválida!");
                    goto MenuCliente;
            }
        
        Menu:
            for (;;)
            {
                Console.WriteLine("Opções");
                Console.WriteLine("1 - Criar conta corrente");
                Console.WriteLine("2 - Criar conta poupanca");
                Console.WriteLine("3 - Utilizar conta");
                Console.WriteLine("4 - Simular investimento");
                Console.WriteLine("0 - Encerrar operacao");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1 || opcao == 2)
                {
                    Console.WriteLine("Deposito inicial:");
                    double saldo = Convert.ToDouble(Console.ReadLine());
                    if (opcao == 1)
                    {
                        Console.WriteLine("Numero da conta: {0}", cx.criarContaCorrente(saldo, clienteLogado));
                        continue;
                    }
                    else if (opcao == 2)
                    {
                        Console.WriteLine("Numero da conta: {0}", cx.criarContaPoupanca(saldo, clienteLogado));
                        continue;
                    }
                }
                else if (opcao == 3) 
                {
                    Console.WriteLine("Selecione a conta desejada: " + "\n" + cx.getContas());
                    int conta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(cx.setConta(conta));
                }
                else if (opcao == 4)
                {
                    goto MenuSimulador;
                }
                else if (opcao == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    break;
                }

                MenuConta:
                for (; ; )
                {
                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Saldo");
                    Console.WriteLine("4 - Cartao");
                    Console.WriteLine("5 - Transferir");
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
                            if (!cx.sacar(valor))
                            {
                                Console.WriteLine("Saldo insuficiente!");
                            }
                            goto MenuConta;
                        case 3:
                            Console.WriteLine("Saldo: R${0}", cx.getSaldo());
                            goto MenuConta;
                        case 4:
                            goto MenuCartao;
                        case 5:
                            Console.WriteLine("Valor:");
                            valor = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Conta de destino: \n {0}", cx.getContas());
                            opcao = Convert.ToInt32(Console.ReadLine());
                            if (!cx.transferir(cx.getConta(opcao),valor))
                            {
                                Console.WriteLine("Não é possivel efetuar a transferência!");
                            }
                            else
                            {
                                Console.WriteLine("Transferência realizada.");
                            }
                            goto MenuConta;
                        case 0:
                            goto Menu;
                        default:
                            Console.WriteLine("Opcao invalida!");
                            goto MenuConta;
                    }
                }
            MenuSimulador:
                Console.WriteLine("1 - Investimento Tesouro");
                Console.WriteLine("2 - Investimento na bolsa com expectativa de crescimento");
                Console.WriteLine("3 - Investimento na bolsa com a media de crescimento do ultimos meses");
                Console.WriteLine("0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
                if (opcao == 0)
                {
                    goto Menu;
                }
                Console.WriteLine("Digite o valor que será investido:");
                valor = Convert.ToDouble(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quantos meses para retirar o investimento:");
                        int meses = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Valor final R${0}", sm.calculaInvestimentoTesouro(valor,meses));
                        goto MenuSimulador;
                    case 2:
                        Console.WriteLine("Expectatativa de crescimento em %:");
                        double expectativa = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Valor final R${0}", sm.calculaInvestimentoBolsa(valor, expectativa));
                        goto MenuSimulador;
                    case 3:
                        Console.WriteLine("Digite os percentuais dos ultimos meses separados por [,]:");
                        String str = Console.ReadLine();
                        double[] porcentagens;
                        str.Trim();
                        try
                        {
                            porcentagens = Array.ConvertAll(str.Split(','), Double.Parse);
                            Console.WriteLine("Valor final R${0}", sm.calculaInvestimentoBolsa(valor, porcentagens));
                        }
                        catch (InvalidCastException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto MenuSimulador;
                    case 4:
                        goto MenuCartao;
                    default:
                        Console.WriteLine("Opção invalida");
                        goto MenuSimulador;  
                }

            MenuCartao:
                Console.WriteLine("1 - Gerar Cartao Credito");
                Console.WriteLine("2 - Gerar Cartao Debito");
                Console.WriteLine("3 - Comprar com cartao");
                Console.WriteLine("0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
                Random rn = new Random();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Limite:");
                        int limite = Convert.ToInt32(Console.ReadLine());
                        if (clienteLogado.addCartaoCredito(new CartaoCredito(rn.Next(1, 213512123), cx.getConta(), limite)))
                        {
                            Console.WriteLine("Cartão liberado");
                        }
                        else
                        {
                            Console.WriteLine("Voce ja possui o cartao");
                        };
                        goto MenuCartao;
                    case 2:
                        if (clienteLogado.addCartaoDebito(new CartaoDebito(rn.Next(1, 213512123), cx.getConta())))
                        {
                            Console.WriteLine("Cartão liberado");
                        }
                        else
                        {
                            Console.WriteLine("Voce ja possui o cartao");
                        };
                        goto MenuCartao;
                    case 3:
                        Console.WriteLine("1 - Credito");
                        Console.WriteLine("2 - Debito");
                        opcao = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Valor:");
                        valor = Convert.ToDouble(Console.ReadLine());
                        if (opcao == 1)
                        {
                            if (clienteLogado.CartaoCr.comprar(valor))
                            {
                                Console.WriteLine("Transação aprovada.");
                            }
                            else
                            {
                                Console.WriteLine("Transação negada.");
                            }
                        }
                        else if (opcao == 2)
                        {
                            if (clienteLogado.CartaoDb.comprar(valor))
                            {
                                Console.WriteLine("Transação aprovada.");
                            }
                            else
                            {
                                Console.WriteLine("Transação negada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opção invalida!");
                        }
                        goto MenuCartao;
                    case 0:
                        goto MenuConta;
                    default:
                        Console.WriteLine("Opção invalida!");
                        goto MenuCartao;

                }

            }
        Finish:
            Console.WriteLine("Bye");
        }
    }
}
