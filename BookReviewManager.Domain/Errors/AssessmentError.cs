using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Errors
{
    public class AssessmentError
    {
        public static readonly Error Notfound = new(
            "Assessment.NotFound", "The Assessment could not be found");
    }
}
