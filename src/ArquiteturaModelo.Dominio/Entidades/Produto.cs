namespace ArquiteturaModelo.Dominio.Entidades
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        
        public ValidationResult ValidationResult { get; private set; }

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
