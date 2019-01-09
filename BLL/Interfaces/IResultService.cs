using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IResultService
    {
        IEnumerable<ResultDTO> GetResults(string User_ID, int Test_ID);
        ResultDTO GetFullOpen(string User_ID, int Test_ID, DateTime date);
        void ChangeResult(string User_ID, int Test_ID, DateTime date);
        void Dispose();
    }
}
