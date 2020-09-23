using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BooksTracker.Models;

namespace BooksTracker.Models
{
   
    [Table("book")]
    public partial class Book
    {
        /**
         * Book class (Model) modified to serve as a database code-first class:
            int "ID" - int(10) (primary key)
            string "Title" - varchar(30)
            DateTime "PublicationDate" - date
            DateTime "CheckedOutDate" - date
            DateTime "DueDate" - date
            DateTime "ReturnedDate" - date (nullable)
            int "AuthorID" - int(10) (foreign key)
            Requisite virtual property for foriegn key.
         */
        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime PublicationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CheckedOutDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReturnedDate { get; set; }
        [Column("AuthorID", TypeName = "int(10)")]
        public int AuthorID { get; set; }
        [ForeignKey(nameof(AuthorID))]
        [InverseProperty(nameof(Models.Author.Books))]
        public virtual Author Author { get; set; }
    }
}


