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
using PL.Models;

namespace Final_Project.Controllers
{
    public class QuestionsController : Controller
    {
        IQuestionService QuestionService;
        public QuestionsController(IQuestionService QuestionServ)
        {

            QuestionService = QuestionServ;



        }


        // GET: Questions
        public ActionResult Index()
        {
            return View();

        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            QuestionDTO questionDTO = QuestionService.GetQuestion(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            QuestionViewModel questionViewModel = mapper.Map<QuestionDTO, QuestionViewModel>(questionDTO);
            return View(questionViewModel);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Questions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question_ID,content,ISFULL,Test_ID, Topic")] QuestionViewModel question, int? id)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, QuestionDTO>()).CreateMapper();
                QuestionDTO questionDTO = mapper.Map<QuestionViewModel, QuestionDTO>(question);
                questionDTO.Test_ID = id.Value;
               // questionDTO.ISFULL = question.ISFULL;
                QuestionService.CreateQuestion(questionDTO);
                return RedirectToAction("Details", "Tests", new { id = questionDTO.Test_ID });
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            QuestionViewModel QuestionView = mapper.Map<QuestionDTO, QuestionViewModel>(QuestionService.GetQuestion(id));
            if (QuestionView == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Test_ID = new SelectList(testService.GetTests(), "Test_ID", "Topic", QuestionView.Test_ID);

            return View(QuestionView);
        }

        // POST: Questions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Test_ID,Question_ID,content")] QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, QuestionDTO>()).CreateMapper();
                QuestionDTO questionDTO = mapper.Map<QuestionViewModel, QuestionDTO>(question);
                //questionDTO.Test_ID = id.Value;
                QuestionService.EditQuestion(questionDTO);
                return RedirectToAction("Details", "Tests", new { id = questionDTO.Test_ID });
            }
            //ViewBag.Test_ID = new SelectList(testService.GetTests(), "Test_ID", "Topic", question.Test_ID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            QuestionViewModel questionView = mapper.Map<QuestionDTO, QuestionViewModel>(QuestionService.GetQuestion(id));
            if (questionView == null)
            {
                return HttpNotFound();
            }
            return View(questionView);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            QuestionDTO questionDTO = QuestionService.GetQuestion(id);
            QuestionService.DeleteQuestion(id.Value);
            return RedirectToAction("Details", "Tests", new { id = questionDTO.Test_ID });

        }

        protected override void Dispose(bool disposing)
        {
            QuestionService.Dispose();
            base.Dispose(disposing);
        }
    }
}
