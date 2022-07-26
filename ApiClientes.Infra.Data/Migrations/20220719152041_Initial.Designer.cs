﻿// <auto-generated />
using System;
using ApiClientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiClientes.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20220719152041_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiClientes.Infra.Data.Entities.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDCLIENTE");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("IdCliente");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CLIENTE", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
