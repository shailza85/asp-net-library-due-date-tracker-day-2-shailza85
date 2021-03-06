﻿// <auto-generated />
using System;
using BooksTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksTracker.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20200923010200_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BooksTracker.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("author");
                });

            modelBuilder.Entity("BooksTracker.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnName("AuthorID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("book");
                });

            modelBuilder.Entity("BooksTracker.Models.Book", b =>
                {
                    b.HasOne("BooksTracker.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
