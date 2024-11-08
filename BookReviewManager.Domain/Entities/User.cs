using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<Assessment> Assessments { get; private set; } = new List<Assessment>();

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;                 
        }
    }

}
