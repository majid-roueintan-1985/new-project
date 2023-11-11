﻿// <auto-generated />
using System;
using Bnpp.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bnpp.DataLayer.Migrations.Transient
{
    [DbContext(typeof(TransientContext))]
    [Migration("20230217212935_create transients table")]
    partial class createtransientstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bnpp.DataLayer.Entities.TransientGroups", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("TransientGroups");
                });

            modelBuilder.Entity("Bnpp.DataLayer.Entities.Transients", b =>
                {
                    b.Property<int>("TransientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("TransientDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransientFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransientTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TransientsId");

                    b.ToTable("Transients");
                });

            modelBuilder.Entity("Bnpp.DataLayer.Entities.TransientGroups", b =>
                {
                    b.HasOne("Bnpp.DataLayer.Entities.TransientGroups", null)
                        .WithMany("GetTransientGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Bnpp.DataLayer.Entities.TransientGroups", b =>
                {
                    b.Navigation("GetTransientGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
