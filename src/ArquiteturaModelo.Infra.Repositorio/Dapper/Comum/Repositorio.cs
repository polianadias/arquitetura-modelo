using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Infra.Contexto.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data;
using DapperExtensions;

namespace ArquiteturaModelo.Infra.Repositorio.Dapper.Comum
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable where TEntity : class
    {

        public IDbConnection Conn { get; set; }
        public IDapperContexto Context { get; private set; }

        public Repositorio(IDapperContexto context)
        {
            Context = context;
            Conn = context.Connection;
            InicializaMapperDapper()
        }

        public static void InicializaMapperDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(ProdutoMapper).Assembly });
        }

        public void Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Conn.Insert(entity, transaction, commandTimeout);        
        }

        public void Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Conn.Update(entity, transaction, commandTimeout);
        }

        public void Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Conn.Delete(entity, transaction, commandTimeout);
        }

        public TEntity ObterPorId(int id)
        {
            return Conn.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Conn.GetList<TEntity>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
