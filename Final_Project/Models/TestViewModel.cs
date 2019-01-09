using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class TestViewModel
    {
        public int Test_ID { get; set; }
        [DisplayName("Тема")]
        public string Topic { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Введите значение больше 0")]
        [DisplayName("Время прохождения")]
        public int TimeForTest { get; set; }
        public string User_id {get;set;}
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}