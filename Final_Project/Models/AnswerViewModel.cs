using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class AnswerViewModel
    {
        public int Question_ID { get; set; }
        public int Answer_ID { get; set; }
        [DisplayName("Содержания")]
        public string content { get; set; }
        [DisplayName("Правильность")]
        public bool ISCorrect { get; set; }
       
    }
}