using ArquiteturaModelo.Dominio.Interfaces.Especificacoes;
using ArquiteturaModelo.Dominio.Interfaces.Validacoes;

namespace ArquiteturaModelo.Dominio.Validacoes
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string ErrorMessage { get; private set; }
        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }

        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }
    }
}
