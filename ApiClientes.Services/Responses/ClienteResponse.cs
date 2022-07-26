namespace ApiClientes.Services.Responses
{
    /// <summary>
    /// modelagem de dados de retorno de cliente na API
    /// </summary>
    public class ClienteResponse
    {
        public Guid IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
