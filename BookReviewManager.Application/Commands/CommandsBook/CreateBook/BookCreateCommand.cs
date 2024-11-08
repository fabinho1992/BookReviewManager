using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.CreateBook
{
    public class BookCreateCommand : IRequest<ResultViewModel<int>>
    {
        public BookCreateCommand(string title, string description, string author, string iSBN, 
            string publisher, GenerBook generBook, int yearPublication, int numberPages)
        {
            Title = title;
            Description = description;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            GenerBook = generBook;
            YearPublication = yearPublication;
            NumberPages = numberPages;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public GenerBook GenerBook { get; private set; }
        public int YearPublication { get; private set; }
        public int NumberPages { get; private set; }
    }
}
