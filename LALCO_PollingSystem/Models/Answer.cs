namespace LALCO_PollingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int? ID { get; set; }

        public int? QID { get; set; }

        [StringLength(200)]
        public string AnswerDesc { get; set; }

        
    }
}
