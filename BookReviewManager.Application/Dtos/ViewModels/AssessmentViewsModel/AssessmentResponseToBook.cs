using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel
{
    public class AssessmentResponseToBook
    {
        public AssessmentResponseToBook(int nota, string description, string assessmentDate, string nameUser)
        {
            Nota = nota;
            Description = description;
            AssessmentDate = assessmentDate;
            NameUser = nameUser;
        }

        public int Nota { get; private set; }
        public string Description { get; private set; }
        public string AssessmentDate { get; private set; }
        public string NameUser { get; private set; }
    }
}
