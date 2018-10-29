using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class TestViewModel
    {
        public int Test_ID { get; set; }
        public string Topic { get; set; }
        public int TimeForTest { get; set; }
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}