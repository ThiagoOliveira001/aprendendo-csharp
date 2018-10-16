using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class Caixa
    {
        private int codigo { get; set; }

        public Caixa()
        {

        }

        List<Conta> contas = new List<Conta>();
        
        public int criarContaCorrente(double saldo)
        {
            contas.Add(new ContaCorrente(contas.Count + 1, saldo));
            return contas[contas.Count - 1].numero;
        }

        public int criarContaPoupanca(double saldo)
        {
            contas.Add(new ContaPoupanca(contas.Count + 1, saldo));
            return contas[contas.Count - 1].numero;
        }

        public string setConta(int numero)
        {
            if (contas.Exists(x => x.numero == numero))
            {
                this.codigo = contas.FindIndex(x => x.numero == numero);
                return "Conta encontrada com sucesso.";
            }
            else
            {
                return "Não existe uma conta com este numero.";
            }
        }

        public double getSaldo()
        {
            return contas[this.codigo].saldo;
        }

        public void sacar(double valor)
        {
            contas[this.codigo].sacar(valor);
        }

        public void depositar(double valor)
        {
            contas[this.codigo].depositar(valor);
        }

        public string getContas()
        {
            string str = "";
            foreach (Conta ct in contas)
            {
                str += ct.numero;
                str += "\n";
            }
            return str;
        }
    }
}
