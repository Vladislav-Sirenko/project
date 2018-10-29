using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IQuestionService
    {
        IEnumerable<QuestionDTO> GetQuestions(int? id);
        void CreateQuestion(QuestionDTO questionDTO);
        void EditQuestion(QuestionDTO questionDTO);
         QuestionDTO GetQuestion(int? id);
        void DeleteQuestion(int? id);
        void Dispose();
    }
}
