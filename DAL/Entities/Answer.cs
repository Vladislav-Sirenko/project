using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Answer
    {
        [Key]
        public int Answer_ID { get; set; }
        public string content { get; set; }
        public bool ISCorrect { get; set; }
        [ForeignKey("Question")]
        public int Question_ID { get; set; }
        public Question Question { get; set; }
    }
}