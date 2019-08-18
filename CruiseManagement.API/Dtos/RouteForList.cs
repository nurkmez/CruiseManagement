using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class RouteForList: Route
    {
        public string PortName { get; set; }
    }
}
