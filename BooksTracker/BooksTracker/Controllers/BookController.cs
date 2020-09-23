using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksTracker.Controllers;
using BooksTracker.Models;
using Microsoft.VisualBasic;


namespace BooksTracker.Controllers
{
    public class BookController : Controller
    {
        /*BookController (Controller) class modified:
            Remove the “Books” property (static list of Books).
            Modify “ExtendDueDateForBookByID()” to update a book in the database using Entity Framework.
            Modify “DeleteBookByID()” to delete a book from the database using Entity Framework.
            Add a “GetBooks()” method to get a list of all books in the database using Entity Framework.
           ** Ensure that the “Author” virtual property is populated before the list is returned (for use on the List view).
            Modify “GetBookByID()” to get a specific book from the database.
           ** Ensure that the “Author” virtual property is populated before the object is returned (for use on the Details view).
            Modify “CreateBook()” to save books to a database using Entity Framework.
            Have “CreateBook()” perform the nulling of “ReturnDate”.
            Have “CreateBook()” perform the setting of “DueDate”.

            */
       // static public List<Book> Books { get; set; } = new List<Book>();

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult Create(string title, string publicationDate, string checkedOutDate,string name)
        {
            if (Request.Query.Count > 0)
            {
                try
                {
                    if (title != null && publicationDate != null && checkedOutDate != null && name != null)
                    {

                        Book newBook = new Book()
                        {
                            Title = title,
                            PublicationDate = DateTime.Parse(publicationDate),
                            CheckedOutDate = DateTime.Parse(checkedOutDate),
                           ReturnedDate=null,
                        };

                        Author newAuthor = new Author()
                        {
                            Name = name
                        };

                        using (LibraryContext context = new LibraryContext())
                        {
                            context.Books.Add(newBook);
                            context.Authors.Add(newAuthor);
                            context.SaveChanges();
                        }
                        ViewBag.Success = "Successfully added the book to the list.";

                    }
                    else
                    {
                        throw new Exception("Not all fields provided for book creation.");
                    }
                }
                catch (Exception e)
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Error = $"Unable to check out book: {e.Message}";

                    // Store our data to re-add to the form.
                   
                    ViewBag.BookTitle = title;                    
                    ViewBag.PublicationDate = publicationDate;
                    ViewBag.CheckedOutDate = checkedOutDate;
                }
            }
            // else
            // No request, so this will be our inital state.

            return View();
        }
        public IActionResult List()
        {
            // Just like with Create() all we have to do is translate our logic from List to Context.
            using (LibraryContext context = new LibraryContext())
            {
                ViewBag.Books = context.Books.ToList();
            }
            return View();
        }

        public IActionResult Details(string id, string delete, string extend)
        {
            IActionResult result;
            using (LibraryContext context = new LibraryContext())
            {
                // If ID wasn't provided, or if it won't parse to an int, or the ID doesn't exist.
                if (id == null || !int.TryParse(id, out int temp) || context.Books.Where(x => x.ID == int.Parse(id)).Count() < 1)
                {
                    ViewBag.Error = "No book selected.";
                    result = View();
                }
                else
                {
                    if (delete != null)
                    {
                        DeleteBookByID(int.Parse(id));
                        result = RedirectToAction("List");
                    }
                    else
                    {
                        if (extend != null)
                        {
                            ExtendDueDateForBookByID(int.Parse(id));
                        }
                        ViewBag.Book = GetBookByID(int.Parse(id));
                        result = View();
                    }
                }
                return result;
            }
        }
        public Book CreateBook(int id, string title, DateTime publicationDate, DateTime checkedOutDate)
        {
            /*
            Accepts the same parameters as the “Book” constructor.
            Creates and adds a “Book” to the “Books” list.
            Ensures the provided ID is unique in the list.
            Throw an exception if the ID already exists.
            */

            using (LibraryContext context = new LibraryContext())
            {

                if (context.Books.Where(x => x.ID == id).Count() > 0)
                {
                    throw new Exception("That ID already exists.");
                }

                Book newBook1 = new Book()
                {
                    Title = title,
                    PublicationDate = publicationDate,
                    CheckedOutDate = checkedOutDate,
                    ReturnedDate = null,
                    DueDate = checkedOutDate.AddDays(14),
                };
                context.Books.Add(newBook1);
                return newBook1;
            }
        }
        public Author GetBookByID(int id)
        {

            //Modify “GetBookByID()” to get a specific book from the database.

            //Ensure that the “Author” virtual property is populated before the object is returned(for use on the Details view).

            Author target;
            List<Book> books;

            using (LibraryContext context = new LibraryContext())
            {

                target = context.Authors.Where(x => x.ID == id).Single();
                books = context.Books.Where(x => x.ID == target.ID).ToList();
                target.Books = books;
                return target;
            }

        }
        public void ExtendDueDateForBookByID(int id)
        {
            //Modify “ExtendDueDateForBookByID()” to update a book in the database using Entity Framework.
           
            using (LibraryContext context = new LibraryContext())
            {

                context.Books.Where(x => x.DueDate == DateTime.Now.AddDays(7));

            }
        }

        //Add a “GetBooks()” method to get a list of all books in the database using Entity Framework.
        public Author GetBooks(int id)
        {
            //Ensure that the “Author” virtual property is populated before the list is returned (for use on the List view).
            Author target;         
            List<Book> books;
            using (LibraryContext context = new LibraryContext())
            {
                
                target = context.Authors.Where(x => x.ID == id).Single();
                books = context.Books.Where(x => x.ID == target.ID).ToList();
                target.Books = books;
                return target;

            }
           
        }
        public void DeleteBookByID(int id)
        {
            // Modify “DeleteBookByID()” to delete a book from the database using Entity Framework.
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Remove(context.Books.Where(x => x.ID == id).Single());
                context.SaveChanges();
            }
        }
    }
}

// Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1

