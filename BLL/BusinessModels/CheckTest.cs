using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.BusinessModels
{
    public class CheckTest
    {
        List<int> user_answers;
        List<int> db_answers;
        public CheckTest(List<int> db_answers, List<int> user_answers)
        {
            this.db_answers = db_answers;
            this.user_answers = user_answers;
        }
        public int GetScore()
        {
            return user_answers.Intersect(db_answers).Count();
        }
    }
}