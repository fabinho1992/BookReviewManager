using BookReviewManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Entities
{
    public class Book : Base
    {
        public Book(string title, string description, string author, string iSBN,
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
        public decimal MedianaNota { get; private set; }
        public byte[] Cover { get; private set; }
        
        public List<Assessment> Assessments { get; private set; } = new List<Assessment>();

        public void Update(string title, string description, string author, string iSBN,
            string publisher, GenerBook generBook, int yearPublication, int numberPages)
        {
            Title = title;
            Description= description;   
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            GenerBook = generBook;
            YearPublication = yearPublication;
            NumberPages = numberPages;
        }


        // Método para calcular a média da nota
        public void CalcularMedianaNota()
        {
            if (Assessments.Count == 0)
            {
                MedianaNota = 0; // Ou outro valor padrão
            }
            else
            {
                MedianaNota = Math.Round((decimal)Assessments.Average(r => r.Nota), 2);
            }
        }

        public void AddCover(byte[] cover)
        {
            Cover = cover;
        }

    }
}
