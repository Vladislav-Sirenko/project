using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITestChecking
    {
        ResultDTO GetScore(int Test_ID, string User_ID, List<int> user_answers);
        void Dispose();
    }
}
