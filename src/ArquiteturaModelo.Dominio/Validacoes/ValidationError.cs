namespace ArquiteturaModelo.Dominio.Validacoes
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
