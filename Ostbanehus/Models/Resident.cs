namespace Ostbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resident
    {
        [Key]
        public int Resident_No { get; set; }

        public int Apartment_No { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public int Age { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
