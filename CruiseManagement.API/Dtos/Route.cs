using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class Route:RouteBaseClass
    {
        public int Id { get; set; }
        public int CruiseId { get; set; }
    }
}
