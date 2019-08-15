using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class Ship
    {

        public Ship()
        {
            CabinTypes = new HashSet<CabinType>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int CruiseLineId { get; set; }
        [ForeignKey("CruiseLineId")]
        public CruiseLine CruiseLine { get; set; }
        public virtual ICollection<CabinType> CabinTypes { get; set; }
    }
}
