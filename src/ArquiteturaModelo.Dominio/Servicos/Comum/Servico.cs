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

            _repositorio.Adicionar(entity, transaction);
            return _validationResult;
        }

        public ValidationResult Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            _repositorio.Atualizar(entity, transaction);
            return _validationResult;
        }

        public ValidationResult Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repositorio.Deletar(entity, transaction);
            return _validationResult;
        }

        public TEntity ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
