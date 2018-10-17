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
            Cliente mia = new Cliente("Mia Pereira");
            Conta ct = new Conta(mia, 1);

            Console.WriteLine("Titular {0}", ct.titular.nome);

            ct.titular.rg = "55679487";
            if(mia.setDtNascimento("07/03/1997"))
            {
                Console.WriteLine("Idade {0}", mia.idade);
            } else
            {
                Console.WriteLine("Data inválida");
            }
            

           int s = 1 + 1;
        }
    }
}
