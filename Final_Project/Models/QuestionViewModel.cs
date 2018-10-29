using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class QuestionViewModel
    {
        public int Test_ID { get; set; }
        public int Question_ID { get; set; }
        public string content { get; set; }
        public bool ISFULL { get; set; }
        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}