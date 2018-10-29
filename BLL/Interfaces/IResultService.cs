using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public  interface IResultService
    {
        IEnumerable<ResultDTO> GetResults(string User_ID, int Test_ID);
        void Dispose();
    }
}
