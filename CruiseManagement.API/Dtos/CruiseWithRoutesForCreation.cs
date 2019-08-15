using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class CruiseWithRoutesForCreation : CruiseForCreation
    {
        public ICollection<RouteForCreation> Routes { get; set; }
          = new List<RouteForCreation>();
    }
}
