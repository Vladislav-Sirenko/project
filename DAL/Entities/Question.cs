using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Question
    {   
        [Key]
        public int Question_ID { get; set; }
        public string content { get; set; }
        public bool ISFULL { get; set; }
        [ForeignKey("Test")]
        public int Test_ID { get; set; }
        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set;} 
    }
}