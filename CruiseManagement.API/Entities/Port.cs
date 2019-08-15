using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Entities
{
    public class Port
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryCode { get; set; }

    }
}
