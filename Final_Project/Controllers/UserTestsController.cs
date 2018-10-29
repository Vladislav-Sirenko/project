using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    
    public class UserTestsController : Controller
    {
        ITestService TestService;
        IResultService ResultService;
        public UserTestsController(ITestService Testserv, IResultService ResultServ)
        {
            TestService = Testserv;
            ResultService = ResultServ;
        }



        // GET: Results
        [Authorize]
        public ActionResult Index()
        {
              if (User.Identity.IsAuthenticated)
            {
                IEnumerable<TestDTO> testDTO = TestService.GetTests();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                IEnumerable<TestViewModel> testView = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testDTO);
                return View(testView);
                   }
                 else return RedirectToAction("Login", "Account");
            }
        
        
        public ActionResult Result(int? Test_ID)
        {
            string User_ID = User.Identity.GetUserId();
            IEnumerable<ResultDTO> results = ResultService.GetResults(User_ID, Test_ID.Value);
            var testDTO = TestService.GetTest(Test_ID);
            ViewBag.Count = testDTO.Questions.Count;
            ViewBag.Topic = testDTO.Topic;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResultDTO, ResultViewModel>()).CreateMapper();
            IEnumerable<ResultViewModel> resultView = mapper.Map<IEnumerable<ResultDTO>, IEnumerable<ResultViewModel>>(results);

            if (resultView == null)
            {
                return RedirectToAction("Error.cshtml");
            }
            return View(resultView);
        }
        protected override void Dispose(bool disposing)
        {
            TestService.Dispose();
            ResultService.Dispose();
            base.Dispose(disposing);
        }
    }
}