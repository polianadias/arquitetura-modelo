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
        
        public Repositorio(IDapperContexto context)
        {
            Conn = context.Connection;
            InicializaMapperDapper()
        }

        public static void InicializaMapperDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(ProdutoMapper).Assembly });
        }

       public dynamic Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity == null ? null : Conn.Insert(entity, transaction, commandTimeout);
        }

        public bool Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity != null && Conn.Update(entity, transaction, commandTimeout);
        }

        public bool Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity != null && Conn.Delete(entity, transaction, commandTimeout);
        }

        public TEntity ObterPorId(int id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.Get<TEntity>(id, transaction, commandTimeout);
        }

        public IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.GetList<TEntity>(null, null, transaction, commandTimeout);
        }

        public IEnumerable<TEntity> ObterPor(object @where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.GetList<TEntity>(@where);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
