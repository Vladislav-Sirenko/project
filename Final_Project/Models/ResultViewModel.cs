using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class ResultViewModel
    {
        public int ID { get; set; }
        public string Test_Topic { get; set; }
        public string User_ID { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public int Count_of_questions { get; set; }
    }
}