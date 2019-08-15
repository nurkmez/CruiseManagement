using CruiseManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class CruiseWithRoutes : Cruise
    {
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
