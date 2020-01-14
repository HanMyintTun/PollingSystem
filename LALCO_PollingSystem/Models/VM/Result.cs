using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LALCO_PollingSystem.Models.VM
{
    public class Result
    {
        public int? QuestinID { get; set; }
        public string QuestionDesc { get; set; }
        public List<AnswerSum> AnswerList { get; set; }
    }

    public class AnswerSum
    {
        public int? Count { get; set; }
        public int? AnswerID { get; set; }
        public string AnswerDesc { get; set; }

    }
}