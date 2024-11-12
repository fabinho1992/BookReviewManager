using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.BookViewsModel
{
    public class BookResponse
    {
        public BookResponse(string title, string description, string author, string iSBN, 
            string publisher, GenerBook generBook, int yearPublication, int numberPages, List<AssessmentResponseToBook> assessments)
        {
            Title = title;
            Description = description;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            GenerBook = generBook;
            YearPublication = yearPublication;
            NumberPages = numberPages;
            Assessments = assessments;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public GenerBook GenerBook { get; private set; }
        public int YearPublication { get; private set; }
        public int NumberPages { get; private set; }
        public List<AssessmentResponseToBook> Assessments { get; private set; } = new List<AssessmentResponseToBook>();
    }
}
