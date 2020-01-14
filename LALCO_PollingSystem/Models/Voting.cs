namespace LALCO_PollingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voting")]
    public partial class Voting
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? QID { get; set; }

        public int? AID { get; set; }
    }
}
