using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Models.VM;
using LALCO_PollingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace LALCO_PollingSystem.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private DBModel _db = new DBModel();

        #region Create Question and Answers Function        
        public bool CreateQuestion(QuestionVM questionToCreate)
        {
            int createdID = 0;
            bool isCreated = false;
            try
            {
                Question question = new Question();
                question.CreatedUserID = questionToCreate.CreatedUserID;
                question.QuestionDesc = questionToCreate.QuestionDesc;

                //check existing question
                var isExistingQuestion = _db.Questions.Where(x => x.QuestionDesc == question.QuestionDesc)
                                         .FirstOrDefault();
                if (isExistingQuestion == null)
                {
                    _db.Questions.Add(question);
                    _db.SaveChanges();

                    //get newly added Question ID
                    createdID = _db.Questions.Where(x => x.CreatedUserID == question.CreatedUserID)
                                             .Where(x => x.QuestionDesc == question.QuestionDesc)
                                             .FirstOrDefault().ID;
                    if (createdID != 0)
                    {
                        //add answer list to db

                        List<Answer> ansList = new List<Answer>();
                        ansList = questionToCreate.Answers;
                        if (ansList != null)
                        {
                            foreach (var item in ansList)
                            {
                                item.QID = createdID;
                                _db.Answers.Add(item);
                            }
                            _db.SaveChanges();

                        }
                        isCreated = true;
                    }
                }
                else
                {
                    isCreated = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isCreated = false;
            }
            return isCreated;
        }
        #endregion

        #region Get All Question
        public List<QuestionVM> GetQuestionList()
        {
            List<QuestionVM> qList = new List<QuestionVM>();
            Question qs = new Question();

            try
            {
                //var qesVM = from q in _db.Questions where q.ID == (from a in _db.Answers ))
                var questions = _db.Questions.ToList();
                foreach (var item in questions)
                {
                    QuestionVM qvm = new QuestionVM();
                    qvm.ID = item.ID;
                    qvm.QuestionDesc = item.QuestionDesc;
                    qvm.CreatedUserID = item.CreatedUserID;
                    Answer ans = new Answer();
                    var answers = (from a in _db.Answers where a.QID == item.ID select a).ToList();
                    qvm.Answers = answers;
                    qList.Add(qvm);
                }
                //var answers = _db.Answers.ToList().Where(x=> x.QID == questions.)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return qList;
        }
        #endregion

        #region Submit answer function
        public bool SubmitAnswer(AnswerVM answer)
        {
            bool isSubmitted = false;
            List<Voting> voteList = new List<Voting>();
            var ans = answer;
            try
            {
                foreach (var item in answer.selectedAnswer)
                {
                    Voting vote = new Voting();
                    vote.AID = Int32.Parse(item);
                    vote.UserID = answer.UserID;
                    vote.QID = _db.Answers.Where(x => x.ID == vote.AID).FirstOrDefault().QID;
                    voteList.Add(vote);
                }
                _db.Votings.AddRange(voteList);
                _db.SaveChanges();
                isSubmitted = true;
            }
            catch (Exception ex)
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
            try
            {
                var votings = _db.Votings.GroupBy(c => c.QID).Select(grp => grp.FirstOrDefault()).ToList();
                for (int i = 0; i < votings.Count(); i++)
                {
                    Result res = new Result();
                    var qid = votings[i].QID;
                    res.QuestinID = qid;
                    res.QuestionDesc = _db.Questions.Where(q => q.ID == qid).FirstOrDefault().QuestionDesc;
                    List<AnswerSum> ansSummaryList = new List<AnswerSum>();
                    //get all answer id under same question id
                    var arAnsIDs = _db.Answers.Where(a => a.QID == qid).Select(a => a.ID).ToList();
                    int?[] arr = arAnsIDs.Distinct().ToArray();//filter duplicate 
                    for (int j = 0; j < arr.Count(); j++)
                    {
                        var aid = arr[j];
                        var count = _db.Votings.Where(v => v.AID == aid).Count();
                        AnswerSum ansSummary = new AnswerSum();
                        ansSummary.AnswerID = aid;
                        ansSummary.AnswerDesc = _db.Answers.Where(a => a.ID == aid).FirstOrDefault().AnswerDesc;
                        ansSummary.Count = count;
                        ansSummaryList.Add(ansSummary);
                    }
                    res.AnswerList = ansSummaryList;
                    resultList.Add(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resultList;
        }

        #endregion
    }

}