using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Final_Project.Models;
using PL.Models;

namespace Final_Project.Controllers
{

    public class TestsController : Controller
    {
        ITestService TestService;
        public TestsController(ITestService Testserv)
        {
            TestService = Testserv;
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


        // GET: Tests
        public ActionResult Index(int page = 1)
        {
            int pageSize = 20;
            if (User.IsInRole("admin")){

                IEnumerable<TestDTO> testDTO = TestService.GetTests();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                IEnumerable<TestViewModel> testView = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testDTO);
                IEnumerable<TestViewModel> testsPerPages = testView.Skip((page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = testView.Count() };
                IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tests = testsPerPages };
                return View(ivm);
            }
            else return RedirectToAction("Index","UserTests");
        }

        public ActionResult IndexAdmin(string User_id)
        {
            if (User.IsInRole("admin"))
            {
                IEnumerable<TestDTO> testDTO = TestService.GetTests();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                IEnumerable<TestViewModel> testView = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testDTO);
                foreach(var test in testView)
                {
                    test.User_id = User_id;
                }
                return View(testView);
            }
            else return RedirectToAction("Index", "UserTests");
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDTO testDTO = TestService.GetTest(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            TestViewModel testViewModel = mapper.Map<TestDTO, TestViewModel>(testDTO);

            return View(testViewModel);

        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Test_ID,Topic,TimeForTest")] TestViewModel test)
        {
            if (ModelState.IsValid)
            {

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestViewModel, TestDTO>()).CreateMapper();
                TestDTO testDTO = mapper.Map<TestViewModel, TestDTO>(test);
                TestService.CreateTest(testDTO);
                int id = TestService.GetTestByName(testDTO.Topic);
                return RedirectToAction("Details",new { ID = id});
            }

            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            TestViewModel testView = mapper.Map<TestDTO, TestViewModel>(TestService.GetTest(id));

            if (testView == null)
            {
                return HttpNotFound();
            }
            return View(testView);
        }

        // POST: Tests/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Test_ID,Topic,TimeForTest")] TestViewModel test)
        {
            if (ModelState.IsValid)
            {

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestViewModel, TestDTO>()).CreateMapper();
                TestDTO testDTO = mapper.Map<TestViewModel, TestDTO>(test);
                TestService.EditTest(testDTO);
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            TestViewModel testView = mapper.Map<TestDTO, TestViewModel>(TestService.GetTest(id));
            if (testView == null)
            {
                return HttpNotFound();
            }

            return View(testView);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            TestService.DeleteTest(id.Value);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            TestService.Dispose();
            base.Dispose(disposing);
        }

    }
}
