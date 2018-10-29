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
    public class AnswerService:IAnswerService
    {
        IUnitOfWork Database { get; set; }

        public AnswerService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<AnswerDTO> GetAnswersForQuestion(int? id)
        {
            var answers = Database.Answers.GetAll().Where(ids => ids.Question_ID == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            var AnswersDTO = mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
            return AnswersDTO;
        }
        public void CreateAnswer(AnswerDTO AnswerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, Answer>()).CreateMapper();
            Answer answer = mapper.Map<AnswerDTO, Answer>(AnswerDTO);
            Database.Answers.Create(answer);
        }
        public void EditAnswer(AnswerDTO AnswerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, Answer>()).CreateMapper();
            Answer answer = mapper.Map<AnswerDTO, Answer>(AnswerDTO);
            Database.Answers.Update(answer);
        }
        public AnswerDTO GetAnswer(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не найден id вопроса", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            AnswerDTO answerDTO = mapper.Map<Answer, AnswerDTO>(Database.Answers.Get(id.Value));
            return (answerDTO);
        }
        public void DeleteAnswer(int? id)
        {
            Database.Answers.Delete(id);
        }
        public IEnumerable<AnswerDTO> GetTests()
        {
            IEnumerable<Answer> answers = Database.Answers.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            var answersDTO = mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
            return answersDTO;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}