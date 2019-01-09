using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Final_Project.Models;
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
        public ActionResult Index(int page = 1)
        {
            int pageSize = 20;
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<TestDTO> testDTO = TestService.GetTests();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                IEnumerable<TestViewModel> testView = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testDTO);
                IEnumerable<TestViewModel> testsPerPages = testView.Skip((page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = testView.Count() };
                IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tests = testsPerPages };
                return View(ivm);
            }
            else return RedirectToAction("Login", "Account");
            }
        
        
        public ActionResult Result(int? Test_ID,string User_id)
        {
           
            string User_ID = User_id==null ? User.Identity.GetUserId() :User_id;
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


        [HttpPost]
        public ActionResult TestSearch(string name)
        {
            IEnumerable<TestDTO> testDTO = TestService.GetTests();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            IEnumerable<TestViewModel> testView = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testDTO);
            var allbooks = testView.Where(a => a.Topic.Contains(name)).ToList();

            if (allbooks.Count() <= 0)
            {
                return HttpNotFound();
            }
            return View(allbooks);
        }

            public ActionResult ResultAdmin(int? Test_id, string User_id)
        {
             IEnumerable <ResultDTO> results = ResultService.GetResults(User_id, Test_id.Value);
            var testDTO = TestService.GetTest(Test_id);
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

        public ActionResult Check(int? Test_ID, string User_id,DateTime? Date)
        {

            var result = ResultService.GetFullOpen(User_id, Test_ID.Value,Date.Value);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResultDTO, ResultViewModel>()).CreateMapper();
            var resultView = mapper.Map<ResultDTO, ResultViewModel>(result);
            if (result == null)
            {
                return RedirectToAction("Error.cshtml");
            }
            return View(resultView);
        }

        public ActionResult CheckFull(int? Test_ID, string User_id, DateTime? Date)
        {
            var count_of_questions = TestService.GetTest(Test_ID).Questions.Count();
           var results= ResultService.GetResults(User_id, Test_ID.Value);
            ResultDTO result = results.Where(dat => dat.Date.ToString() == Date.ToString()).First();
            if (result.Score + 1 > count_of_questions)
            {
                return RedirectToAction("ResultAdmin",new { Test_ID, User_id, Date });
            }
            ResultService.ChangeResult(User_id, Test_ID.Value, Date.Value);
            return RedirectToAction("ResultAdmin", new { Test_ID, User_id, Date });
        }
        protected override void Dispose(bool disposing)
        {
            TestService.Dispose();
            ResultService.Dispose();
            base.Dispose(disposing);
        }
    }
}