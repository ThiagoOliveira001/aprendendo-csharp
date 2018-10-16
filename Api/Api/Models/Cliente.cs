using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Cliente
    {
        public string nome { get; set; }

        public Cliente(string nome)
        {
            this.nome = nome;    
        }
    }
}