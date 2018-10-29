using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Test_ID { get; set; }
        public string Topic { get; set; }
        public int TimeForTest { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
}