using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksTracker.Models;


namespace BooksTracker.Models
{
    public partial class LibraryContext : DbContext
    {
        /**
         * All requisite methods and properties to function as a context.
            Database connection string to a database called "mvc_library".
            Seed the database with:
            5 "Authors" of your choice.
            3 "Books" by the same Author.
            All three books must have a "CheckoutDate" equal to December 25, 2019.
            One book must be returned on-time with no extension.
            One book must be returned on-time with one extension.
            One book must not have been returned at all!
            Add migrations and update the database once this and the models are completed.
         */
        public LibraryContext()
        {
        }
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=mvc_library", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                   entity.HasData(
                new Author()
                    {
                        ID = -1,
                        Name = "Nora Roberts"
                    },
                   new Author()
                   {
                       ID = -2,
                       Name = "Stephen King"
                   }, new Author()
                   {
                       ID = -3,
                       Name = "Jane Austen"
                   }, new Author()
                   {
                       ID = -4,
                       Name = "Zadie Smith"
                   }, new Author()
                   {
                       ID = -5,
                       Name = "George Orewell"
                   }, new Author()
                   {
                       ID = -6,
                       Name = "Jess Kidd"
                   }
                );
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.AuthorID)
                    .HasName("FK_" + nameof(Book) + "_" + nameof(Author));
                entity.Property(e => e.Title)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
                /** entity.Property(e => e.PublicationDate)
                     .HasColumnType("date")
                     .HasCollation("utf8mb4_general_ci");
                 entity.Property(e => e.CheckedOutDate)
                      .HasColumnType("date")
                     .HasCollation("utf8mb4_general_ci");
                 entity.Property(e => e.DueDate)
                      .HasColumnType("date")
                     .HasCollation("utf8mb4_general_ci");*/
                entity.HasOne(Child => Child.Author)
                    .WithMany(Parent => Parent.Books)
                    .HasForeignKey(Child => Child.AuthorID)
                    // When we delete a record, we can modify the behaviour of the case where there are child records.
                    // Restrict: Throw an exception if we try to orphan a child record.
                    // Cascade: Remove any child records that would be orphaned by a removed parent.
                    // SetNull: Set the foreign key field to null on any orphaned child records.
                    // NoAction: Don't commit any deletions of parents which would orphan a child.
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_" + nameof(Book) + "_" + nameof(Author));

                entity.HasData(
                         new Book()
                         {
                             ID = -1,
                             Title = "Key of Light",
                             PublicationDate = new DateTime(2013,11,01),
                             CheckedOutDate= new DateTime(2019,12,25),
                             DueDate = new DateTime(2019,12,25).AddDays(14),
                             ReturnedDate=null,
                             AuthorID = -1
                         },
                         new Book()
                         {
                             ID = -2,
                             Title = "Once Upon a Rose",
                             PublicationDate = new DateTime(2001,10,01),
                             CheckedOutDate = new DateTime(2019,12,25),
                             DueDate = new DateTime(2019,12,25).AddDays(14),
                             ReturnedDate = null,
                             AuthorID = -2
                         },
                         new Book()
                         {
                             ID = -3,
                             Title = "Blue Smoke",
                             PublicationDate = new DateTime(2005,10,01),
                             CheckedOutDate = new DateTime(2019,12,25),
                             DueDate = new DateTime(2019,12,25).AddDays(14),
                             ReturnedDate = null,
                             AuthorID = -3
                         },
                         new Book()
                         {
                             ID = -4,
                             Title = "The Shining",
                             PublicationDate = new DateTime(1977,11,01),
                             CheckedOutDate = new DateTime(2020,08,01),
                             DueDate = new DateTime(2020,08,01).AddDays(14),
                             ReturnedDate = null,
                             AuthorID = -4
                         },
                         new Book()
                         {
                             ID = -5,
                             Title = "Doctor Sleep",
                             PublicationDate = new DateTime(2013,09,01),
                             CheckedOutDate = new DateTime(2020,07,01),
                             DueDate = new DateTime(2020,07,01).AddDays(14),
                             ReturnedDate = null,
                             AuthorID = -5
                         }
                     );
            });



            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
