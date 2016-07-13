using ArquiteturaModelo.Dominio.Entidades.Validacao.Produtos;
using ArquiteturaModelo.Dominio.Validacoes;

namespace ArquiteturaModelo.Dominio.Entidades
{
    /// <summary>
    /// Produto
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Código do Produto
        /// </summary>
        public int ProdutoId { get; set; }
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Validação e consistência da entidade 
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// Retorno da Validação
        /// </summary>
        public bool IsValid
        {
            get
            {
                ValidationResult = new ProdutoEstaConsistenteValidation().Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}

