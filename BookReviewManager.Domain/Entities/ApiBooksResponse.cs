using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Service
{
    public class ApiBooksResponse
    {
        public string? Title { get; set; }
        public string? Autor { get; set; }
        public string? YearOfRelease { get; set; }
    }
}
