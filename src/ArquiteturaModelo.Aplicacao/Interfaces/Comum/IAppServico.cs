using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Aplicacao.Interfaces
{
   public interface IAppServico<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterPor(object @where = null, object order = null);
        ValidationResult Adicionar(TEntity entity);
        ValidationResult Atualizar(TEntity entity);
        ValidationResult Deletar(TEntity entity);
    }
}
