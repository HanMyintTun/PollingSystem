namespace LALCO_PollingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        public long? IsAdmin { get; set; }
    }
}
