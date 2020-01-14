using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LALCO_PollingSystem.Models;
namespace LALCO_PollingSystem.Models.VM
{
    public class QuestionVM
    {
        public int ID { get; set; }

        public int? CreatedUserID { get; set;}

        public string QuestionDesc { get; set;}

        public List<Answer> Answers { get; set;}

    }
}