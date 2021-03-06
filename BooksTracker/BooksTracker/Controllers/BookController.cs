﻿using System;
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
        public IActionResult Create(string id, string title, string authorID, string publicationDate, string checkedOutDate)
        {
            ViewBag.Authors = GetAuthors();

            if (Request.Query.Count > 0)
            {
                try
                {
                    if (title != null && authorID != null && publicationDate != null && checkedOutDate != null)
                    {
                        // Get parameters come in as a string, so we have to convert those to the data types required.
                        Book createdBook = CreateBook(title, int.Parse(authorID), DateTime.Parse(publicationDate), DateTime.Parse(checkedOutDate));

                        ViewBag.Success = $"You have successfully checked out {createdBook.Title} until {createdBook.DueDate}.";
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
                    ViewBag.ID = id;
                    ViewBag.BookTitle = title;
                    ViewBag.Author = authorID;
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

            ViewBag.Books = GetBooks();

            return View();
        }

        public IActionResult Details(string id, string delete, string extend)
        {
            IActionResult result;


            // If ID wasn't provided, or if it won't parse to an int, or the ID doesn't exist.
            if (id == null || !int.TryParse(id, out int temp))
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
                    Book target = GetBookByID(int.Parse(id));
                    if (target == null)
                    {
                        ViewBag.Error = "No book selected.";
                    }
                    else
                    {
                        ViewBag.Book = target;
                    }
                    result = View();
                }
            }
            return result;
        }
        public Book CreateBook(string title, int authorID, DateTime publicationDate, DateTime checkedOutDate)
        {
            /*
            Accepts the same parameters as the “Book” constructor.
            Creates and adds a “Book” to the “Books” list.
            Ensures the provided ID is unique in the list.
            Throw an exception if the ID already exists.
            */
            Book newBook = new Book()
            {
                Title = title,
                AuthorID = authorID,
                PublicationDate = publicationDate,
                CheckedOutDate = checkedOutDate,
                DueDate = checkedOutDate.AddDays(14),
                ReturnedDate = null
            };
            using (LibraryContext context = new LibraryContext())
            {             
               context.Books.Add(newBook);
                context.SaveChanges();
                return newBook;
            }
        }
        public Book GetBookByID(int id)
        {
            Book target;
            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();
                target.Author = context.Authors.Where(x => x.ID == target.AuthorID).SingleOrDefault();
            }
            return target;
        }
        public List<Author> GetAuthors()
        {
            List<Author> authors;
            using (LibraryContext context = new LibraryContext())
            {
                authors = context.Authors.ToList();
                foreach (Author author in authors)
                {
                    author.Books = context.Books.Where(x => x.AuthorID == author.ID).ToList();
                }
            }
            return authors;
        }
       
        //Add a “GetBooks()” method to get a list of all books in the database using Entity Framework.
        public List<Book> GetBooks()
        {
            List<Book> books;
            using (LibraryContext context = new LibraryContext())
            {
                books = context.Books.ToList();
                foreach (Book book in books)
                {
                    book.Author = context.Authors.Where(x => x.ID == book.AuthorID).Single();
                }
            }
            return books;
        }
        public void ExtendDueDateForBookByID(int id)
        {
            //Modify “ExtendDueDateForBookByID()” to update a book in the database using Entity Framework.

            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Where(x => x.ID == id).Single().DueDate = DateTime.Now.Date.AddDays(7);
                context.SaveChanges();
            }
        }

        public void DeleteBookByID(int id)
        {
            // Modify “DeleteBookByID()” to delete a book from the database using Entity Framework.
            Book target;
            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();
                context.Books.Remove(target);
                context.SaveChanges();
            }
        }
    }
}

// Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1

