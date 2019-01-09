using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Test_ID { get; set; }
        [DisplayName("Результат")]
        public int Score { get; set; }
        public string FullOpenAnswer { get; set; }
        public int Count_of_questions { get; set; }
        public bool IsFullOpenChecked { get; set; }
    }
}