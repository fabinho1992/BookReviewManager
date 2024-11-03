using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Errors
{
    public class UserError
    {
        public static readonly Error Notfound = new(
            "User.NotFound", "The User could not be found");
    }
}
