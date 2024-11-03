using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Errors
{
    public interface IError
    {
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
