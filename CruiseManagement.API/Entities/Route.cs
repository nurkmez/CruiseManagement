using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class Route
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }

        [Required]
        [Range(1,31,ErrorMessage ="Day field must be between 1 and 31")]
        public int Days { get; set; }
        public int PortId { get; set; }
        [ForeignKey("PortId")]
        public Port Port { get; set; }
        public int CruiseId { get; set; }
        [ForeignKey("CruiseId")]
        public Cruise Cruise { get; set; }

    }
}
