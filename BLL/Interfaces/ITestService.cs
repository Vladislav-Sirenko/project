using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public  interface ITestService
    {
       IEnumerable<TestDTO> GetTests();
        void CreateTest(TestDTO testDTO);
        void EditTest(TestDTO testDTO);
        TestDTO GetTest(int? id);
        void DeleteTest(int? id);
        void Dispose();
    }
}
