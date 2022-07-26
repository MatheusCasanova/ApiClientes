using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Contexts
{
    //classe para configuração do entity no projeto infra.data
    public class SqlServerContext : DbContext
    {
        //construtor para injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        //sobrescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }

        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Cliente> Cliente { get; set; }
    }
}
