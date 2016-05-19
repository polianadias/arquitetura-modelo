using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArquiteturaModelo.Servicos.REST.ModeloAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppServico _appServico;

        public ProdutoController(IProdutoAppServico appServico)
        {
            _appServico = appServico;
        }

        // GET api/<controller>
        public IEnumerable<Produto> Get()
        {
            return _appServico.ObterTodos();
        }

        // GET api/<controller>/5
        public Produto Get(int id)
        {
            return _appServico.ObterPorId(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}