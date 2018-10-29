using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class ResultDTO
    {
        public int ID { get; set; }
        public int Test_ID { get; set; }
        public string User_ID { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
    }
}