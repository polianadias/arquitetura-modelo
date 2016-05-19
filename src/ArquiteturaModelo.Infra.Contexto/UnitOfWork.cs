using ArquiteturaModelo.Infra.Contexto.Interfaces;
using System;
using System.Data;

namespace ArquiteturaModelo.Infra.Contexto
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDapperContexto Context { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IDapperContexto context)
        {
            Context = context;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (Transaction == null)
            {
                Transaction = Context.Connection.BeginTransaction(isolationLevel);
            }

            return Transaction;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }

        }

        public void Rollback()
        {
            Transaction.Rollback();
            Transaction = null;
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
