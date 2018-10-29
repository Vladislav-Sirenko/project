using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Test_ID { get; set; }
        public int Question_ID { get; set; }
        public string content { get; set; }
        public bool ISFULL { get; set; }
        public string FullOpen { get; set; }
        public ICollection<AnswerDTO> Answers { get; set; }
    }
}