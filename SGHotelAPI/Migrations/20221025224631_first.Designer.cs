﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGHotelAPI.Model;

namespace SGHotelAPI.Migrations
{
    [DbContext(typeof(SGHotelContext))]
    [Migration("20221025224631_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGHotelAPI.Model.Andar", b =>
                {
                    b.Property<int>("idAndar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("idAndar");

                    b.ToTable("Andares");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Conta", b =>
                {
                    b.Property<int>("idConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("idConta");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Quarto", b =>
                {
                    b.Property<int>("idQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AndaridAndar")
                        .HasColumnType("int");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<int>("Numero_Quarto")
                        .HasColumnType("int");

                    b.Property<double>("Val_Diaria")
                        .HasColumnType("float");

                    b.Property<bool>("isLimpo")
                        .HasColumnType("bit");

                    b.HasKey("idQuarto");

                    b.HasIndex("AndaridAndar");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Reserva", b =>
                {
                    b.Property<int>("idReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("QuartoidQuarto")
                        .HasColumnType("int");

                    b.Property<int?>("clienteIdCliente")
                        .HasColumnType("int");

                    b.HasKey("idReserva");

                    b.HasIndex("QuartoidQuarto");

                    b.HasIndex("clienteIdCliente");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Quarto", b =>
                {
                    b.HasOne("SGHotelAPI.Model.Andar", "Andar")
                        .WithMany("Quartos")
                        .HasForeignKey("AndaridAndar");

                    b.Navigation("Andar");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Reserva", b =>
                {
                    b.HasOne("SGHotelAPI.Model.Quarto", null)
                        .WithMany("reservas")
                        .HasForeignKey("QuartoidQuarto");

                    b.HasOne("SGHotelAPI.Model.Cliente", "cliente")
                        .WithMany("reservas")
                        .HasForeignKey("clienteIdCliente");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Andar", b =>
                {
                    b.Navigation("Quartos");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Cliente", b =>
                {
                    b.Navigation("reservas");
                });

            modelBuilder.Entity("SGHotelAPI.Model.Quarto", b =>
                {
                    b.Navigation("reservas");
                });
#pragma warning restore 612, 618
        }
    }
}