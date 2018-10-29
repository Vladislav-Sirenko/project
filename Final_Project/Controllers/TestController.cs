using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.DTO;
using AutoMapper;
using PL.Models;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;

namespace Final_Project.Controllers
{
    public class TestController : Controller
    {
        ITestChecking TestCheckingService;
        ITestForming TestFormingService;
        public TestController(ITestForming Formingserv, ITestChecking Checkingserv)
        {
            TestFormingService = Formingserv;
            TestCheckingService = Checkingserv;
        }

        public ActionResult Index(int? id)
        {
            TestDTO testDTO = TestFormingService.GetTest(id);
            TestAnswerViewModel testView = new TestAnswerViewModel()
            {
                Test_ID = testDTO.Test_ID,
                Topic = testDTO.Topic,
                TimeForTest = testDTO.TimeForTest,
            };
            testView.Questions = new List<QuestionAnswerViewModel>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
            foreach (var quest in testDTO.Questions)
            {
                QuestionAnswerViewModel qvm = new QuestionAnswerViewModel
                {
                    Question_ID = quest.Question_ID,
                    Test_ID = quest.Test_ID,
                    content = quest.content,
                    ISFULL = quest.ISFULL,
                    FullOpen = quest.FullOpen
                };
                testView.Questions.Add(qvm);
                qvm.Answers = mapper.Map<IEnumerable<AnswerDTO>, List<AnswerViewModel>>(quest.Answers);
            }
            return View(testView);
        }
        [HttpPost]
        public ActionResult Check(TestAnswerViewModel testView)
        {
            string FullOpen;
            List<int> user_answers = new List<int>();
            foreach (var k in testView.Questions)
            {
                user_answers.Add(k.SelectedAnswer);
            }
            string User_ID = User.Identity.GetUserId();
            foreach (var question in testView.Questions)
            {
                if (question.FullOpen != null)
                    FullOpen = question.FullOpen;
            }
            var result = TestCheckingService.GetScore(testView.Test_ID, User_ID, user_answers);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResultDTO, ResultViewModel>()).CreateMapper();
            ResultViewModel resultView = mapper.Map<ResultDTO, ResultViewModel>(result);
            resultView.Test_Topic = testView.Topic;
            resultView.Count_of_questions = testView.Questions.Count - 1;
            return View(resultView);
        }

        protected override void Dispose(bool disposing)
        {
            TestFormingService.Dispose();
            base.Dispose(disposing);
        }
    }
}