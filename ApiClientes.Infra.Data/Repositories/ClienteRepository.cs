using ApiClientes.Infra.Data.Contexts;
using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência
        public ClienteRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Cliente> Consultar()
        {
            return _context.Cliente
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public Cliente ObterPorId(Guid id)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.IdCliente.Equals(id));
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public Cliente ObterPorEmail(string email)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Email.Equals(email));
        }

        public List<Cliente> ObterPorNome(string nome)
        {
            return _context.Cliente
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.Nome)
                .ToList();          
        }
    }
}
