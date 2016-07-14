using ArquiteturaModelo.Dominio.Validacoes;
using System.Collections.Generic;
using System.Data;

namespace ArquiteturaModelo.Dominio.Interfaces.Servicos.Comum
{
    public interface IServico<TEntity> where TEntity : class
    {
        ValidationResult Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        ValidationResult Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        ValidationResult Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(int id, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterPor(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null);
    }
}
