using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class QuestionViewModel
    {
        public int Test_ID { get; set; }
        public int Question_ID { get; set; }
        [DisplayName("Содержание")]
        public string content { get; set; }
        [DisplayName("Открытый вопрос")]
        public bool ISFULL { get; set; }
        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}