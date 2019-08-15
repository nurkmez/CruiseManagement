using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class CruiseForUpdate:CruiseAbstractBase
    {
            [Required(AllowEmptyStrings = false,
                ErrorMessage = "required|When updating a tour, the description is required.")]
            public override string Title
            { get => base.Title; set => base.Title = value; }
     
    }
}
