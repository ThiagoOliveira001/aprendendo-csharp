using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace apostilaCaelum6._9
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente mia = new Cliente("Mia Pereira")
            {
                cpf = "52416542",
                rg = "23846237858723",
                endereco = "Rua das palmeiras"
            };
            Conta ct = new Conta(mia, 1);

            Console.WriteLine("Titular {0}", ct.Titular.nome);

            ct.Titular.rg = "55679487";
            ct.Numero = 2;
            if(mia.setDtNascimento("07/03/1997"))
            {
                Console.WriteLine("Idade {0} N Conta: {1}", mia.idade,ct.Numero);
            } else
            {
                Console.WriteLine("Data inválida");
            }
            
        }
    }
}
