using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace apostilaCaelum6._9
{
    class Cliente
    {
        public string nome;
        public string rg;
        public string cpf;
        public string endereco;
        public int idade { get; private set; }
        private string dtNascimento;
        Regex ER = new Regex(@"\d{2}\/\d{2}\/\d{4}",RegexOptions.None);

        public Cliente(string nome, string rg, string cpf, string endereco)
        {
            this.nome = nome;
            this.rg = rg;
            this.cpf = cpf;
            this.endereco = endereco;
        }

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public bool setDtNascimento(string data)
        {
            if (ER.IsMatch(data))
            {
                this.dtNascimento = data;
                int[] dtNascimento = Array.ConvertAll(this.dtNascimento.Split('/'), Int32.Parse);
                DateTime dtN = new DateTime(dtNascimento[2],dtNascimento[1],dtNascimento[0]);
                DateTime today = DateTime.UtcNow.Date;
                int idade = (today.Year - dtN.Year) - 1;
                if (dtN.Month <= today.Month && dtN.Day <= today.Day) {
                    this.idade = idade + 1;
                }
                return true;
            } else
            {
                return false;
            }

            this.dtNascimento = data;
        }
    }
}
