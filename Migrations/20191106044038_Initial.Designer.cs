﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaWebApi.Models;

namespace MinhaWebApi.Migrations
{
    [DbContext(typeof(MinhaWebApiContext))]
    [Migration("20191106044038_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MinhaWebApi.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CanalContato")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ObservacaoContato")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TipoContatoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoContatoId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("MinhaWebApi.Models.TipoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoContato");
                });

            modelBuilder.Entity("MinhaWebApi.Models.Contato", b =>
                {
                    b.HasOne("MinhaWebApi.Models.TipoContato", "TipoContato")
                        .WithMany()
                        .HasForeignKey("TipoContatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
