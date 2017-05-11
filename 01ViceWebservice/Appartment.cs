namespace _01ViceWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appartment")]
    public partial class Appartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppartmentNo { get; set; }

        [Required]
        [StringLength(30)]
        public string AssignTitle { get; set; }

        [StringLength(100)]
        public string AssignText { get; set; }

        public int AssignRankNo { get; set; }

        public int EmployeeID { get; set; }

        public int AppartmentPhone1 { get; set; }

        [Required]
        [StringLength(30)]
        public string AppartmentOwner { get; set; }

        [StringLength(100)]
        public string Comment { get; set; }
    }
}
