using ApiClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        /// <summary>
        /// Método para retornar 1 cliente baseado no cpf
        /// </summary>
        Cliente ObterPorCpf(string cpf);

        /// <summary>
        /// Método para retornar 1 cliente baseado no email
        /// </summary>
        Cliente ObterPorEmail(string email);

        /// <summary>
        /// Método para retornar clientes baseado no nome
        /// </summary>
        List<Cliente> ObterPorNome(string nome);
    }
}
