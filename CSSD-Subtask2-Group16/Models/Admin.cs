namespace CSSD_Subtask2_Group16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdminId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int AdminType { get; set; }

        public string Motorway { get; set; }
    }
}
