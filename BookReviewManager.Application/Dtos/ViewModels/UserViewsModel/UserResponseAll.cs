using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.UserViewsModel
{
    public class UserResponseAll
    {
        public UserResponseAll(string name, string email, List<AssessmentResponseToUser> assessmentResponses)
        {
            Name = name;
            Email = email;
            AssessmentResponses = assessmentResponses;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<AssessmentResponseToUser> AssessmentResponses{ get; set; }
    }
}
