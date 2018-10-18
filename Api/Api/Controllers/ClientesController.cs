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
        
        [HttpGet]
        public Cliente buscar([FromUri] int id)
        {
            return clientes[id];
        }

        [HttpPost]
        public void inserir([FromBody]Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.nome))
            {
                clientes.Add(new Cliente(cliente.nome,clientes.Count));
            }
        }
        

        [HttpPut]
        public void alterar([FromBody] Cliente cli, [FromUri] int id)
        {
            foreach (Cliente cl in clientes)
            {
                if (cl.id == id)
                {
                    cl.nome = cli.nome;
                }
            }
        }

        [HttpDelete]
        public void deletar([FromUri] int id)
        {
            clientes.RemoveAt(id);
            foreach (Cliente cl in clientes)
            {
                cl.id = clientes.IndexOf(cl);
            }
        }
        
        [HttpDelete]
        public void deletarTodos()
        {
            clientes.Clear();
        }
    }
}
