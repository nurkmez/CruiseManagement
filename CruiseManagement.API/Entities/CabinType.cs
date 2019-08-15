using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class CabinType 
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
    }
}
