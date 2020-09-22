using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksTracker.Models
{
    /*
       Book class (Model):
          string “Title”
              This property should be readOnly (getter only, backing variable initialized via constructor)
          DateTime “PublicationDate”
              This property should be readOnly (getter only, backing variable initialized via constructor)
          DateTime “CheckedOutDate”
          DateTime “DueDate”
              This will equal “CheckedOutDate” + 14 days (set in constructor)
              This will update with each extension (via the ExtendDueDateForBookByID() method)
          DateTime “ReturnedDate”
              Default value should be null (set in constructor)
          string “Author”
              This property should be readOnly (getter only, backing variable initialized via constructor)
          int “ID”
              This property should be readOnly (getter only, backing variable initialized via constructor)
              This property will be auto-incremented by the database in tomorrow’s practice
              User will have to add “ID” on Day 1 and the code will have to validate that the “ID” is unique (in the CreateBook() method)
          Constructor accepting the ID, Title, Author, PublicationDate and CheckedOutDate as parameters
              “DueDate” will be set to 14 days after “CheckedOutDate”
              “ReturnedDate” will be set to null
          */
    public class Book
    {
        private int _id;
        public int ID => _id;

        private string _title;
        public string Title => _title;

        private string _author;
        public string Author => _author;
        /*
        {
            get
            {
                return _author;
            }
        }
        */

        private DateTime _publicationDate;
        public DateTime PublicationDate => _publicationDate;

        public DateTime CheckedOutDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime? ReturnedDate { get; set; }


        public Book(int id, string title, string author, DateTime publicationDate, DateTime checkedOutDate)
        {
            _id = id;
            _title = title;
            _author = author;
            _publicationDate = publicationDate;
            CheckedOutDate = checkedOutDate;
            DueDate = CheckedOutDate.AddDays(14);
            ReturnedDate = null;
        }
    }
}

// Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1
// Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/blob/Sep21Practice/MVC_4Point1/Models/Book.cs
