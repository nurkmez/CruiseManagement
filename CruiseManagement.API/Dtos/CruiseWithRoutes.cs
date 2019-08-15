using System.Collections.Generic;

namespace CruiseManagement.API.Dtos
{
    public class CruiseWithRoutes : Cruise
    {
        public IEnumerable<Route> Routes { get; set; } = new List<Route>();

    }
}
