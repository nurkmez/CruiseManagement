using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Dtos
{
    public class CruiseForList : Cruise
    {

        public string CruiseLineName { get; set; }

        public string ShipName { get; set; }

        public string CabinTypeName { get; set; }

    }
}
