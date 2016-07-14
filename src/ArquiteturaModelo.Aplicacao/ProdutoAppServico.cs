using ArquiteturaModelo.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Validacoes;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;

namespace ArquiteturaModelo.Aplicacao
{
    public class ProdutoAppServico : AppServico, IProdutoAppServico
    {
        private readonly IProdutoServico _servico;
        private readonly IUnitOfWork _uow;

        public ProdutoAppServico(IProdutoServico servico)
        {
            _servico = servico;

        }

        public ValidationResult Adicionar(Produto produto)
        {
            ValidationResult.Add(_servico.Adicionar(produto, _uow.BeginTransaction()));
            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;

        }

        public ValidationResult Atualizar(Produto produto)
        {
            ValidationResult.Add(_servico.Atualizar(produto, _uow.BeginTransaction()));
            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;
        }

        public ValidationResult Deletar(Produto produto)
        {
            ValidationResult.Add(_servico.Deletar(produto, _uow.BeginTransaction()));
            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Produto ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _servico.ObterTodos();
        }
        
          public IEnumerable<Produto> ObterPor(object @where = null, object order = null)
        {
            return _servico.ObterPor(@where);
        }
        
    }
}
