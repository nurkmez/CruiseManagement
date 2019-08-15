using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{

    public abstract class CruiseAbstractBase : IValidatableObject
    {
        public int CruiseLineId { get; set; }

        public int ShipId { get; set; }

        public int CabinTypeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "required|Title is required.")]
        [MaxLength(200, ErrorMessage = "maxLength|Title is too long.")]
        public virtual string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "required|Depature date is required.")]
        public DateTimeOffset DepatureDate { get; set; }

        public virtual bool FlightIncluded { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(DepatureDate < DateTime.Now))
            {
                yield return new ValidationResult(
                "departureDateBeforeNow|The departure date should be later than now.",
                new[] { "Cruise" });
            }

        }
    }

}
