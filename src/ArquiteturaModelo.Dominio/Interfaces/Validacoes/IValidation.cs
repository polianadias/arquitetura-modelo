
using ArquiteturaModelo.Dominio.Validacoes;

namespace ArquiteturaModelo.Dominio.Interfaces.Validacoes
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
