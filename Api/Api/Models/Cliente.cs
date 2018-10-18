using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Cliente
    {
        public string nome;
        public int id;

        public Cliente(string nome,int id)
        {
            this.nome = nome;
            this.id = id;
        }
    }
}