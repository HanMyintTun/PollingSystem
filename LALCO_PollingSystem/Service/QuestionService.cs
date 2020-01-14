using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LALCO_PollingSystem.Repository.Interfaces;
using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Models.VM;

namespace LALCO_PollingSystem.Service
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        #region Create Question and Answer function
        public bool CreateQuestion(QuestionVM questionToCreate)
        {
            bool isCreated = false;
            try
            {
                //check empty answer and remove
                List<Answer> ansList = questionToCreate.Answers;
                if(ansList != null)
                {
                    ansList.RemoveAll(x => (x.AnswerDesc == null || x.AnswerDesc == ""));
                    questionToCreate.Answers = ansList;
                }
               
               
                isCreated = _questionRepository.CreateQuestion(questionToCreate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isCreated = false;
            }
            return isCreated;
        }
        #endregion

        #region Get all questions function
        public List<QuestionVM> GetQuestionList()
        {
            List<QuestionVM> qList = new List<QuestionVM>();
            try
            {
                var qs = _questionRepository.GetQuestionList();
                qList = qs;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return qList;
        }
        #endregion

        #region Submit Answer function
        public bool SubmitAnswer(AnswerVM answer)
        {
            bool isSubmitted = false;
            try
            {
                isSubmitted = _questionRepository.SubmitAnswer(answer);
            }
            catch(Exception ex)
            {
                isSubmitted = false;
                Console.WriteLine(ex);
            }
            return isSubmitted;
        
        }
        #endregion

        #region Get results function
        public List<Result> GetAllResultList()
        {
            List<Result> resultList = new List<Result>();
            resultList = _questionRepository.GetAllResultList();
            return resultList;
        }

        #endregion
    }
}