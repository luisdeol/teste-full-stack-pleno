﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteFullStackPleno.Infrastructure.Persistence;

namespace TesteFullStackPleno.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(TesteContext))]
    [Migration("20190906011326_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteFullStackPleno.Core.Entities.Comportamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Browser");

                    b.Property<string>("Ip");

                    b.Property<string>("Nome");

                    b.Property<string>("Parametros");

                    b.HasKey("Id");

                    b.ToTable("db_Comportamento");
                });
#pragma warning restore 612, 618
        }
    }
}
