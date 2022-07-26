using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Services.Requests
{
    /// <summary>
    /// modelagem da requisição de cadastro de cliente
    /// </summary>
    public class ClientePostRequest
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe o cpf.")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento.")]
        public DateTime DataNascimento { get; set; }
    }
}
