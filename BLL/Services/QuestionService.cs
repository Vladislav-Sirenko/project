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
    public class QuestionService:IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<QuestionDTO> GetQuestions(int? id)
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
            var Questions = Database.Questions.GetAll().Where(ids => ids.Test_ID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            var QuestionsDTO = mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(Questions);
            return QuestionsDTO;
        }
        public void CreateQuestion(QuestionDTO questionDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, Question>()).CreateMapper();
            Question question = mapper.Map<QuestionDTO, Question>(questionDTO);
            Database.Questions.Create(question);
        }
        public void EditQuestion(QuestionDTO questionDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, Question>()).CreateMapper();
            Question question = mapper.Map<QuestionDTO, Question>(questionDTO);
            Database.Questions.Update(question);
        }
        public QuestionDTO GetQuestion(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }
            var answers = Database.Answers.GetAll().Where(ids => ids.Question_ID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            var AnswersDTO = mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);

            var maper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            QuestionDTO Question = maper.Map<Question, QuestionDTO>(Database.Questions.Get(id.Value));
            Question.Answers = AnswersDTO.ToList();
            return (Question);
        }
        public void DeleteQuestion(int? id)
        {
            Database.Questions.Delete(id.Value);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}