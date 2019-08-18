using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class CruiseWithRoutesForUpdate : Cruise
    {
        public string DeletedRoutesIDs { get; set; }
        public ICollection<Route> Routes { get; set; }
          = new List<Route>();
    }
}
