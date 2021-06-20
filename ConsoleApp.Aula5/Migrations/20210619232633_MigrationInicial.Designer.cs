﻿// <auto-generated />
using System;
using ConsoleApp.Aula5;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.Aula5.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210619232633_MigrationInicial")]
    partial class MigrationInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("ConsoleApp.Aula5.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("WebUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("AutorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("ConsoleApp.Aula5.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("PublicadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("LivroId");

                    b.HasIndex("AutorId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("ConsoleApp.Aula5.Livro", b =>
                {
                    b.HasOne("ConsoleApp.Aula5.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });
#pragma warning restore 612, 618
        }
    }
}