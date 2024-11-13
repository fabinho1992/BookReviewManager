﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel
{
    public class AssessmentResponseAll
    {
        public AssessmentResponseAll(int id, int nota, string description, string nameUser, string titleBook, string assessmentDate)
        {
            Id = id;
            Nota = nota;
            Description = description;
            NameUser = nameUser;
            TitleBook = titleBook;
            AssessmentDate = assessmentDate;
        }

        public int Id { get; private set; }
        public int Nota { get; private set; }
        public string Description { get; set; }
        public string NameUser { get; private set; }
        public string TitleBook { get; private set; }
        public string AssessmentDate { get; private set; }
    }
}