using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class Caixa
    {
        private int Codigo { get; set; }

        public Caixa()
        {

        }

        List<Conta> contas = new List<Conta>();
        
        public int criarContaCorrente(double saldo)
        {
            contas.Add(new ContaCorrente(contas.Count + 1, saldo));
            return contas[contas.Count - 1].Numero;
        }

        public int criarContaPoupanca(double saldo)
        {
            contas.Add(new ContaPoupanca(contas.Count + 1, saldo));
            return contas[contas.Count - 1].Numero;
        }

        public string setConta(int numero)
        {
            if (contas.Exists(x => x.Numero == numero))
            {
                this.Codigo = contas.FindIndex(x => x.Numero == numero);
                return "Conta encontrada com sucesso.";
            }
            else
            {
                return "Não existe uma conta com este numero.";
            }
        }

        public double getSaldo()
        {
            return contas[this.Codigo].Saldo;
        }

        public void sacar(double valor)
        {
            contas[this.Codigo].sacar(valor);
        }

        public void depositar(double valor)
        {
            contas[this.Codigo].depositar(valor);
        }

        public string getContas()
        {
            string str = "";
            foreach (Conta ct in contas)
            {
                str += ct.Numero;
                str += "\n";
            }
            return str;
        }
    }
}
