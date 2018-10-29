using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Test
    {
        [Key]
        public int Test_ID { get; set; }
        public string Topic { get; set;}
        public int TimeForTest { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}