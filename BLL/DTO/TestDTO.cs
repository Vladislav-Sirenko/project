﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Test_ID { get; set; }
        public string Topic { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Введите значение больше 0")]
        public int TimeForTest { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
}