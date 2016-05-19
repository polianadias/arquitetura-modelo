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
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}
