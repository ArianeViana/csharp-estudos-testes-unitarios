﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cadastro_livros.Data;

#nullable disable

namespace cadastrolivros.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221123114021_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cadastro_livros.Models.Entities.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nacionalidade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("autores");
                });

            modelBuilder.Entity("cadastro_livros.Models.Entities.Editora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("editoras");
                });

            modelBuilder.Entity("cadastro_livros.Models.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AnoLancamento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ano_lancamento");

                    b.Property<int>("AutorId")
                        .HasColumnType("integer")
                        .HasColumnName("autor_id");

                    b.Property<int>("EditoraId")
                        .HasColumnType("integer")
                        .HasColumnName("editora_id");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("idioma");

                    b.Property<string>("Isbn10")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("isbn-10");

                    b.Property<string>("Isbn13")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("isbn-13");

                    b.Property<int>("NumeroPaginas")
                        .HasColumnType("integer")
                        .HasColumnName("numero_paginas");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditoraId");

                    b.ToTable("livros");
                });

            modelBuilder.Entity("cadastro_livros.Models.Entities.Livro", b =>
                {
                    b.HasOne("cadastro_livros.Models.Entities.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cadastro_livros.Models.Entities.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("cadastro_livros.Models.Entities.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("cadastro_livros.Models.Entities.Editora", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
