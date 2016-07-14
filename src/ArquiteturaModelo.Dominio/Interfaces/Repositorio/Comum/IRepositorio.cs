using System.Collections.Generic;
using System.Data;

namespace ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        dynamic Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(int id, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterPor(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null);
        
    }
}
