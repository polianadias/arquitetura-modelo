using System;
using System.Data;

namespace ArquiteturaModelo.Infra.Contexto.Interfaces
{
    public interface IDapperContexto : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
