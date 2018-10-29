using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerDTO> GetAnswersForQuestion(int? id);
        void CreateAnswer(AnswerDTO answerDTO);
        void EditAnswer(AnswerDTO answerDTO);
        AnswerDTO GetAnswer(int? id);
        void DeleteAnswer(int? id);
        void Dispose();
    }
}
