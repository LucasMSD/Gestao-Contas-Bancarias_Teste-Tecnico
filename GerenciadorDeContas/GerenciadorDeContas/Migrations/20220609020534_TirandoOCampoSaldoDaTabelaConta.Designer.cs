﻿// <auto-generated />
using System;
using GerenciadorDeContas.ContasBancarias.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorDeContas.ContasBancarias.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220609020534_TirandoOCampoSaldoDaTabelaConta")]
    partial class TirandoOCampoSaldoDaTabelaConta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Agencia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AgenciaId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Movimentacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("ContaDestinoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ContaDestinoNumero")
                        .HasColumnType("bigint");

                    b.Property<long?>("ContaOrigemId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ContaOrigemNumero")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TipoMovimentacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ContaDestinoId");

                    b.HasIndex("ContaOrigemId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Agencia", b =>
                {
                    b.HasOne("GerenciadorDeContas.ContasBancarias.Models.Endereco", "Endereco")
                        .WithOne("Agencia")
                        .HasForeignKey("GerenciadorDeContas.ContasBancarias.Models.Agencia", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Conta", b =>
                {
                    b.HasOne("GerenciadorDeContas.ContasBancarias.Models.Agencia", "Agencia")
                        .WithMany("Contas")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciadorDeContas.ContasBancarias.Models.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Movimentacao", b =>
                {
                    b.HasOne("GerenciadorDeContas.ContasBancarias.Models.Conta", "ContaDestino")
                        .WithMany("MovimentacoesEntrada")
                        .HasForeignKey("ContaDestinoId");

                    b.HasOne("GerenciadorDeContas.ContasBancarias.Models.Conta", "ContaOrigem")
                        .WithMany("MovimentacoesSaida")
                        .HasForeignKey("ContaOrigemId");

                    b.Navigation("ContaDestino");

                    b.Navigation("ContaOrigem");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Agencia", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Cliente", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Conta", b =>
                {
                    b.Navigation("MovimentacoesEntrada");

                    b.Navigation("MovimentacoesSaida");
                });

            modelBuilder.Entity("GerenciadorDeContas.ContasBancarias.Models.Endereco", b =>
                {
                    b.Navigation("Agencia")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
