using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LALCO_PollingSystem.Models;
namespace LALCO_PollingSystem.Models.VM
{
    public class AnswerVM
    {
        public string[] selectedAnswer { get; set; }
        public int UserID { get; set; }
        public List<QuestionVM> QueAnswer { get; set; }
        public List<Voting> Vote { get; set; }
    }
}