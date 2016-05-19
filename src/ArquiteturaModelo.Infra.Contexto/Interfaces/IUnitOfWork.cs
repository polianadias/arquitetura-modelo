using System;
using System.Data;

namespace ArquiteturaModelo.Infra.Contexto.Interfaces
{
    public interface IUnitOfWork 
    {
        IDapperContexto Context { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
        void Commit();
        void Rollback();
    }
}
