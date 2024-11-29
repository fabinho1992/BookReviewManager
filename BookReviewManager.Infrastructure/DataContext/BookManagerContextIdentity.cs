
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.DataContext
{
    public class BookManagerContextIdentity : IdentityDbContext<IdentityUser>
    {
        public BookManagerContextIdentity(DbContextOptions<BookManagerContextIdentity> options) : base(options)
        {
        }
    }
}
