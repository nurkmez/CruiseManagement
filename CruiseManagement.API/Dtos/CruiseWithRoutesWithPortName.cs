using System.Collections.Generic;

namespace CruiseManagement.API.Dtos
{
    public class CruiseWithRoutesWithPortName : Cruise
    {
        public ICollection<RouteForList> Routes { get; set; }
          = new List<RouteForList>();

    }
}
