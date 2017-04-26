namespace Ostbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            Residents = new HashSet<Resident>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Apartment_No { get; set; }

        public int Gate_No { get; set; }

        public int Floor_No { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public int No_Rooms { get; set; }

        public int Size { get; set; }

        public int Squaremetre { get; set; }

        public int MonthlyRent { get; set; }

        [StringLength(2)]
        public string location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resident> Residents { get; set; }
    }
}
