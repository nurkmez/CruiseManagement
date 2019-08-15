using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class CruiseLine
    {

        public CruiseLine()
        {

            Ships = new HashSet<Ship>();
            Cruises = new HashSet<Cruise>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
       
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Cruise> Cruises { get; set; }
    }
}
