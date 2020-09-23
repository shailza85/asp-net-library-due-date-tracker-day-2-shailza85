using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BooksTracker.Models;

namespace BooksTracker.Models
{

    [Table("author")]
    public partial class Author
    {
        /**
         * Add a code-first Author class (Model):
            int "ID" - int(10) (prmary key)
            string "Name" - varchar(30)
            Requisite virtual property and constructor for foreign key.
         */
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        [Column("id", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }


        // InverseProperty links the two virtual properties together.
        [InverseProperty(nameof(Models.Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}