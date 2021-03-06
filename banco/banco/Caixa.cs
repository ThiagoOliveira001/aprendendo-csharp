﻿using System;
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
        List<Cliente> clientes = new List<Cliente>();
        
        public int criarContaCorrente(double saldo,Cliente titular)
        {
            contas.Add(new ContaCorrente(contas.Count + 1, saldo, titular));
            return contas[contas.Count - 1].Numero;
        }

        public int criarContaPoupanca(double saldo,Cliente titular)
        {
            contas.Add(new ContaPoupanca(contas.Count + 1, saldo,titular));
            return contas[contas.Count - 1].Numero;
        }

        public int cadastrarCliente(string nome, string cpf)
        {
            foreach (Cliente cl in clientes)
            {
                if (cl.Cpf.Equals(cpf)) return -1;
            }
            clientes.Add(new Cliente(nome, cpf));
            return clientes.Count;
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

        public bool sacar(double valor)
        {
            if (contas[this.Codigo].sacar(valor)) return true;
            return false;
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
                str += " - " + ct.Titular.Nome + "\tTipo:\t" + ct.Info + "\n";
            }
            return str;
        }

        public Conta getConta(int numero)
        {
            return contas[numero - 1];
        }

        public Conta getConta()
        {
            return contas[this.Codigo];
        }

        public string getClientes()
        {
            string str = "";
            foreach (Cliente cl in clientes)
            {
                str += clientes.IndexOf(cl) + 1;
                str += " - " + cl.Nome + "\n";
            }
            return str;
        }

        public Cliente getCliente(int cod)
        {
            return clientes[cod - 1];
        }

        public bool transferir(Conta destino, double valor)
        {
            if (contas[this.Codigo].Numero == destino.Numero) return false;
            if (!contas[this.Codigo].sacar(valor)) return false;
            destino.depositar(valor);
            return true;
        }
    }
}
