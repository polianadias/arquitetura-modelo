using System;
using System.Collections.Generic;
using System.Data;
using ArquiteturaModelo.Dominio.Interfaces.Servicos.Comum;
using ArquiteturaModelo.Dominio.Validacoes;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Dominio.Interfaces.Validacoes;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;

namespace ArquiteturaModelo.Dominio.Servicos.Comum
{
    public class Servico<TEntity> : IServico<TEntity> where TEntity : class
    {
        private readonly IRepositorio<TEntity> _repositorio;
        private readonly ValidationResult _validationResult;

        public Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        public ValidationResult Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (!_validationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var adicionou = _repositorio.Adicionar(entity);
            if (adicionou == null)
                _validationResult.Add("A Entidade que você está tentando gravar está nula, por favor tente novamente!" + entity, "Adicionar");
            return _validationResult;
        }

        public ValidationResult Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var atualizar = _repositorio.Atualizar(entity);
            if (!atualizar)
                _validationResult.Add("A Entidade que você está tentando atualizar está nula, por favor tente novamente! Nome: " + entity, "Atualizar");
            return _validationResult;
        }

        public ValidationResult Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var deletou = _repositorio.Deletar(entity);
            if (!deletou)
                _validationResult.Add("A Entidade que você está tentando deletar está nula, por favor tente novamente! Nome: " + entity, "Deletar");
            return _validationResult;
        }

         public TEntity ObterPorId(int id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _repositorio.ObterTodos();
        }

        public IEnumerable<TEntity> ObterPor(object @where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _repositorio.ObterPor(@where);
        }
    }
}
