using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel
{
    public class AssessmentResponseToUser
    {
        public AssessmentResponseToUser(int nota, string description, string assessmentDate, string titleBook)
        {
            Nota = nota;
            Description = description;
            AssessmentDate = assessmentDate;
            TitleBook = titleBook;
        }

        public int Nota { get; private set; }
        public string Description { get; private set; }
        public string AssessmentDate { get; private set; }
        public string TitleBook { get; private set; }
    }
}
