using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class AnswerViewModel
    {
        public int Question_ID { get; set; }
        public int Answer_ID { get; set; }
        public string content { get; set; }
        public bool ISCorrect { get; set; }
       
    }
}