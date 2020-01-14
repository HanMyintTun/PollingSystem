using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Models.VM;
using LALCO_PollingSystem.Repository;
using LALCO_PollingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace LALCO_PollingSystem.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;

        public QuestionController()
        {
            _questionService = new QuestionService(new QuestionRepository());
        }

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;

        }
        //Voting Page
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["LoggedInUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                AnswerVM ansVM = new AnswerVM();
                var model = new List<QuestionVM>();
                model = _questionService.GetQuestionList();
                ansVM.QueAnswer = model;
                TempData["ansVM"] = ansVM;
                return View(ansVM);

            }
          
        }
        //Submit Voting Fucnction
        [HttpPost]
        public ActionResult Index(AnswerVM ansVM)
        {
            AnswerVM a = (AnswerVM)TempData["ansVM"];
            var model = ansVM;
            bool result = _questionService.SubmitAnswer(model);
            if (!result)
            {               
                ViewBag.Msg = "Plsease select at least one option for each answer.";
                return View(a);
            }
            else
            {
                ViewBag.Msg = "Successfully submitted!";
                return View(a);
            }
        }

       
        //Question Creation Page
        public ActionResult CreateQuestion()
        {
            if (Session["LoggedInUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        //Question Create Action
        [HttpPost]
        public ActionResult CreateQuestion(QuestionVM question, string[] DynamicTextBox)
        {
            //add Answer value from array to List obj
            List<Answer> ansList = new List<Answer>();
            if (DynamicTextBox != null)
            {
                for (int i = 0; i < DynamicTextBox.Length; i++)
                {
                    Answer ansObj = new Answer();
                    var ans = DynamicTextBox[i].ToString();
                    if (ans != null && ans != "")
                    {
                        ansObj.AnswerDesc = ans;
                        ansList.Add(ansObj);
                    }
                }
                question.Answers = ansList;
                if (ansList.Count.Equals(0))
                {
                    ViewBag.Msg = "Plsease add at least one answer for the question.";
                    return View();
                }
            }
            else
            {
                ViewBag.Msg = "Plsease add at least one answer for the question.";
                return View();
            }


            if (!_questionService.CreateQuestion(question))
            {
                ViewBag.Msg = "Something went wrong!.";

            }
            else
            {
                ViewBag.Msg = "Successfully submited.";
                ModelState.Clear();
                //go to question list;
            }
            return View();
        }


        //Show ALl Result Action
        [HttpGet]
        public ActionResult Result()
        {
            var resList = new List<Result>();
            resList = _questionService.GetAllResultList();
            ResultVM res = new ResultVM();
            res.ResultList = resList;
            return View(res);
        }
    }
}