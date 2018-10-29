using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class TestAnswerViewModel
    {
        public int Student_ID { get; set; }
        public int Test_ID { get; set; }
        public string Topic { get; set; }
        public int TimeForTest { get; set; }
        public ICollection<QuestionAnswerViewModel> Questions { get; set; }
    }
}