using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using PL.Models;


namespace Final_Project.Controllers
{
    public class AnswersController : Controller
    {

        IAnswerService AnswerService;

        public AnswersController(IAnswerService Answerserv)
        {
            AnswerService = Answerserv;




        }
        //  private Final_ProjectContext db = new Final_ProjectContext();

        // GET: Answers
        public ActionResult Index()
        {

            return View();
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerDTO answerDTO = AnswerService.GetAnswer(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
            AnswerViewModel answerView = mapper.Map<AnswerDTO, AnswerViewModel>(answerDTO);
            if (answerView == null)
            {
                return HttpNotFound();
            }
            return View(answerView);
        }

        // GET: Answers/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Question_ID = id.Value;
            return View();
        }

        // POST: Answers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Answer_ID,content,ISCorrect,Question_ID")] AnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, AnswerDTO>()).CreateMapper();
                AnswerDTO answerDTO = mapper.Map<AnswerViewModel, AnswerDTO>(answer);
                // answerDTO.Question_ID = id.Value;
                AnswerService.CreateAnswer(answerDTO);
                return RedirectToAction("Details", "Questions", new { id = answer.Question_ID });


            }

            // ViewBag.Question_ID = new SelectList(QuestionService.GetQuestions(), "Question_ID", "content");
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
            AnswerViewModel answerView = mapper.Map<AnswerDTO, AnswerViewModel>(AnswerService.GetAnswer(id));
            if (answerView == null)
            {
                return HttpNotFound();
            }
            //  ViewBag.Question_ID = new SelectList(QuestionService.GetQuestions(), "Question_ID", "content");
            return View(answerView);
        }

        // POST: Answers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Answer_ID,content,ISCorrect,Question_ID")] AnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, AnswerDTO>()).CreateMapper();
                AnswerDTO answerDTO = mapper.Map<AnswerViewModel, AnswerDTO>(answer);
                AnswerService.EditAnswer(answerDTO);
                return RedirectToAction("Details", "Questions", new { id = answer.Question_ID });
            }
            // ViewBag.Question_ID = new SelectList(QuestionService.GetQuestions(), "Question_ID", "content");
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
            AnswerViewModel answerView = mapper.Map<AnswerDTO, AnswerViewModel>(AnswerService.GetAnswer(id));
            if (answerView == null)
            {
                return HttpNotFound();
            }
            return View(answerView);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            AnswerDTO answerDTO = AnswerService.GetAnswer(id);
            AnswerService.DeleteAnswer(id.Value);
            return RedirectToAction("Details", "Questions", new { id = answerDTO.Question_ID });

        }
        protected override void Dispose(bool disposing)
        {
            AnswerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
