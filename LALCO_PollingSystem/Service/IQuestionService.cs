using LALCO_PollingSystem.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALCO_PollingSystem.Service
{
    public interface IQuestionService
    {
        bool CreateQuestion(QuestionVM questionToCreate);
        List<QuestionVM> GetQuestionList();
        bool SubmitAnswer(AnswerVM answer);
        List<Result> GetAllResultList();
    }
}
