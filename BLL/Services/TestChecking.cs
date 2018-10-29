using AutoMapper;
using BLL.BusinessModels;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
    public class TestChecking:ITestChecking
    {
        IUnitOfWork Database { get; set; }
        ITestForming testService;
        public TestChecking(IUnitOfWork uow, ITestForming testServ)
        {
            Database = uow;
            testService = testServ;
        }
        public ResultDTO GetScore(int Test_ID, string User_ID, List<int> user_answers)
        {
            ResultDTO resultDTO = new ResultDTO();
            List<Answer> answers = new List<Answer>();
            TestDTO testDTO = testService.GetTest(Test_ID);
            List<int> true_list = new List<int>();
            foreach (var tru in testDTO.Questions)
            {
                foreach (var true_answers in tru.Answers)
                    if (true_answers.ISCorrect)
                    {
                        true_list.Add(true_answers.Answer_ID);
                    }
            }
            CheckTest checkTest = new CheckTest(true_list, user_answers);
            resultDTO.Test_ID = Test_ID;
            resultDTO.User_ID= User_ID;
            resultDTO.Score = checkTest.GetScore();
            resultDTO.Date = DateTime.Now;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResultDTO, Result>()).CreateMapper();
            Result result = mapper.Map<ResultDTO, Result>(resultDTO);
            Database.Results.Create(result);
            return resultDTO;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}