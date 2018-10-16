using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();

        [HttpGet]
        public List<Cliente> selecionar()
        {
            return clientes;
        }

        [HttpPost]
        public void inserir([FromBody]Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.nome))
            {
                clientes.Add(new Cliente(cliente.nome));
            }
        }


    }
}
