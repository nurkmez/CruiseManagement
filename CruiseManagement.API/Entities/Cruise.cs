using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class Cruise
    {


        public Cruise()
        {
            Routes = new HashSet<Route>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public int? CruiseLineId { get; set; }
        [ForeignKey("CruiseLineId")]
        public  CruiseLine CruiseLine { get; set; }

        public int? ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public int? CabinTypeId { get; set; }
        [ForeignKey("CabinTypeId")]
        public CabinType CabinType { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public bool FlightIncluded { get; set; }

    }
}
