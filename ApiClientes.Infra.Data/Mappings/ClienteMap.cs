using ApiClientes.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Mappings
{
    //classe de mapeamento ORM para a entidade cliente
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        //Método para fazer o mapeamento da entidade
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("CLIENTE");

            //chave primária
            builder.HasKey(c => c.IdCliente);

            //mapeando os campos da tabela
            builder.Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .HasColumnType("date")
                .IsRequired();

            #region Mapeamento de campos únicos

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.HasIndex(c => c.Cpf)
                .IsUnique();

            #endregion
        }
    }
}
