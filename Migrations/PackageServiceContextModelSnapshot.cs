﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PakketService.Database.Contexts;

namespace PakketService.Migrations
{
    [DbContext(typeof(PackageServiceContext))]
    partial class PackageServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PakketService.Database.Datamodels.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RouteFinished")
                        .HasColumnType("bit");

                    b.Property<string>("Sender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TrackAndTraceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("PakketService.Database.Datamodels.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("float");

                    b.Property<string>("CreatedByPCN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FinishedAt")
                        .HasColumnType("float");

                    b.Property<string>("FinishedByPCN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("NextTicketId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketAction")
                        .HasColumnType("int");

                    b.Property<string>("ToDoLocationId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("PakketService.Database.Datamodels.Ticket", b =>
                {
                    b.HasOne("PakketService.Database.Datamodels.Package", null)
                        .WithMany("Tickets")
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("PakketService.Database.Datamodels.Package", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
