using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
    public class TestService:ITestService
    {
        IUnitOfWork Database { get; set; }
        public TestService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<TestDTO> GetTests()
        {
            IEnumerable<Test> tests = Database.Tests.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            var testsDTO = mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(tests);
            return testsDTO;
        }
        public void CreateTest(TestDTO testDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, Test>()).CreateMapper();
            Test test = mapper.Map<TestDTO, Test>(testDTO);
            Database.Tests.Create(test);
        }
        public void EditTest(TestDTO testDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, Test>()).CreateMapper();
            Test test = mapper.Map<TestDTO, Test>(testDTO);
            Database.Tests.Update(test);
        }
        public TestDTO GetTest(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не найден id теста", "");
            }
            Test test = Database.Tests.Get(id.Value);
            var Questions = Database.Questions.GetAll().Where(ids => ids.Test_ID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            var QuestionsDTO = mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(Questions);

            var maper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            TestDTO testDTO = maper.Map<Test, TestDTO>(test);
            testDTO.Questions = QuestionsDTO.ToList();
            return (testDTO);
        }
        public void DeleteTest(int? id)
        {
            Database.Tests.Delete(id);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}