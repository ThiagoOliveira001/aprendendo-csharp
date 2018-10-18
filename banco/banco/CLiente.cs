using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public CartaoCredito CartaoCr { get; private set; }
        public CartaoDebito CartaoDb { get; private set; }

        public Cliente()
        {
                
        }

        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }
        
        public bool addCartaoCredito(CartaoCredito cartao)
        {
            if (CartaoCr == null)
            {
                CartaoCr = cartao;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addCartaoDebito(CartaoDebito cartao)
        {
            if (CartaoDb == null)
            {
                CartaoDb = cartao;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
