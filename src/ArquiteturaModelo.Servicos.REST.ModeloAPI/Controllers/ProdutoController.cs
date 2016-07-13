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

        /// <summary>
        /// Obter todos os produtos 
        /// </summary>
        /// <remarks>
        /// Obtem a lista de todos os produtos
        /// </remarks>
        /// <returns></returns>
        /// <response code ="200"></response>
        public IEnumerable<Produto> Get()
        {
            return _appServico.ObterTodos();
        }

        /// <summary>
        /// Obter produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produto Get(int id)
        {
            return _appServico.ObterPorId(id);
        }

        /// <summary>
        /// Adicionar produto
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletar produto
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
