

using ArquiteturaModelo.Dominio.Validacoes;

namespace ArquiteturaModelo.Dominio.Interfaces.Validacoes
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
