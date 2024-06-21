﻿using System.Collections.Generic;

namespace SurveyAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
