using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Errors
{
    public class BookError
    {
        public static readonly Error Notfound = new(
            "Book.NotFound", "The Book could not be found");
    }
}
