using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Infrastructure;
using AutoMapper;
using BLL.Interfaces;

namespace BLL.Services
{
    public class TestForming : ITestForming
    {
        IUnitOfWork Database { get; set; }

        public TestForming(IUnitOfWork uow)
        {
            Database = uow;


        }
        public TestDTO GetTest(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id теста", "");
            }
            var test = Database.Tests.Get(id.Value);
            if (test == null)
            {
                throw new ValidationException("Тест не найден", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            TestDTO testDTO = mapper.Map<Test, TestDTO>(test);
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();

            testDTO.Questions =
                mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll().Where(quest => quest.Test_ID == testDTO.Test_ID));

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();

            foreach (var quest in testDTO.Questions)
            {
                quest.Answers =
                mapper.Map<IEnumerable<Answer>, List<AnswerDTO>>(Database.Answers.GetAll().Where(answ => answ.Question_ID == quest.Question_ID));
            }


            return testDTO;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}