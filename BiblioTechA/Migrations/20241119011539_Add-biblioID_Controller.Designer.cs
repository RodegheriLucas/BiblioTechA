﻿// <auto-generated />
using System;
using BiblioTechA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiblioTechA.Migrations
{
    [DbContext(typeof(BiblioTechAContext))]
    [Migration("20241119011539_Add-biblioID_Controller")]
    partial class AddbiblioID_Controller
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiblioTechA.Models.Acervo", b =>
                {
                    b.Property<int>("LivroAcervoId")
                        .HasColumnType("int");

                    b.Property<int>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<int?>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("LivroAcervoId", "BibliotecaId");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("LivroId");

                    b.ToTable("Acervo");
                });

            modelBuilder.Entity("BiblioTechA.Models.Biblioteca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BiblioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Biblioteca");
                });

            modelBuilder.Entity("BiblioTechA.Models.Leitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Nascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Leitores");
                });

            modelBuilder.Entity("BiblioTechA.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BiblioId")
                        .HasColumnType("int");

                    b.Property<int>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeitorId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("LeitorId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("BiblioTechA.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Devolve")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Empresta")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeitorId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeitorId");

                    b.HasIndex("LivroId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("BiblioTechA.Models.Acervo", b =>
                {
                    b.HasOne("BiblioTechA.Models.Biblioteca", "Biblioteca")
                        .WithMany("LivroNoAcervo")
                        .HasForeignKey("BibliotecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiblioTechA.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId");

                    b.Navigation("Biblioteca");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("BiblioTechA.Models.Livro", b =>
                {
                    b.HasOne("BiblioTechA.Models.Biblioteca", "Biblioteca")
                        .WithMany()
                        .HasForeignKey("BibliotecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiblioTechA.Models.Leitor", null)
                        .WithMany("Livros")
                        .HasForeignKey("LeitorId");

                    b.Navigation("Biblioteca");
                });

            modelBuilder.Entity("BiblioTechA.Models.Pedido", b =>
                {
                    b.HasOne("BiblioTechA.Models.Leitor", "Leitor")
                        .WithMany()
                        .HasForeignKey("LeitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiblioTechA.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leitor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("BiblioTechA.Models.Biblioteca", b =>
                {
                    b.Navigation("LivroNoAcervo");
                });

            modelBuilder.Entity("BiblioTechA.Models.Leitor", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}