﻿// <auto-generated />
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
    [Migration("20241115160115_Apagando_bibliotecas")]
    partial class Apagando_bibliotecas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("LeitorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LeitorId");

                    b.ToTable("Biblioteca");
                });

            modelBuilder.Entity("BiblioTechA.Models.Leitor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leitores");
                });

            modelBuilder.Entity("BiblioTechA.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeitorCpf")
                        .HasColumnType("int");

                    b.Property<string>("LeitorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaId")
                        .IsUnique();

                    b.HasIndex("LeitorId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("BiblioTechA.Models.Biblioteca", b =>
                {
                    b.HasOne("BiblioTechA.Models.Leitor", "Leitor")
                        .WithMany()
                        .HasForeignKey("LeitorId");

                    b.Navigation("Leitor");
                });

            modelBuilder.Entity("BiblioTechA.Models.Livro", b =>
                {
                    b.HasOne("BiblioTechA.Models.Biblioteca", "Biblioteca")
                        .WithOne("Livro")
                        .HasForeignKey("BiblioTechA.Models.Livro", "BibliotecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiblioTechA.Models.Leitor", "Leitor")
                        .WithMany("Livros")
                        .HasForeignKey("LeitorId");

                    b.Navigation("Biblioteca");

                    b.Navigation("Leitor");
                });

            modelBuilder.Entity("BiblioTechA.Models.Biblioteca", b =>
                {
                    b.Navigation("Livro");
                });

            modelBuilder.Entity("BiblioTechA.Models.Leitor", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
