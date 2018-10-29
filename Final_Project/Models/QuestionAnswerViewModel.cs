using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class QuestionAnswerViewModel:QuestionViewModel
    {
        public int SelectedAnswer { get; set; }
        public string FullOpen { get; set; }



    }
}