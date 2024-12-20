using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.BookViewsModel
{
    public class BookResponseAll
    {
        public BookResponseAll(int id, string title, string description, string author, 
            GenerBook generBook, int yearPublication, int numberPages, string isbn, string publisher, byte[] cover)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            GenerBook = generBook;
            YearPublication = yearPublication;
            NumberPages = numberPages;
            ISBN = isbn;
            Publisher = publisher;
            Cover = cover;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public GenerBook GenerBook { get; private set; }
        public int YearPublication { get; private set; }
        public int NumberPages { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public byte[] Cover { get; private set; }

    }
}
