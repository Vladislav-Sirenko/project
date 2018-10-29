using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Result
    {
        public int ID { get; set; }
        public int Test_ID { get; set; }
        public string  User_ID { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
    }
}