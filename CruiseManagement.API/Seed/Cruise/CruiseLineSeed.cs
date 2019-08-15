using System.Collections.Generic;

namespace CruiseManagement.API.Seed
{
    public class CruiseLineSeed
    {
        public int nid { get; set; }
        public string title { get; set; }

    }

    public class PortSeed
    {
        public int nid { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

    public class CabinTypeSeed
    {
        public int nid { get; set; }
        public string title { get; set; }
    }

    public class ShipSeed
    {
        public ShipSeed()
        {
            _cabintypes = new List<CabinTypeSeed>();
        }

        public int ship_id { get; set; }
        public int company_id { get; set; }
        public string title { get; set; }
        public string country_code { get; set; }
        private List<CabinTypeSeed> _cabintypes;

        public List<CabinTypeSeed> CabinTypes
        {
            get { return _cabintypes; }
            set { _cabintypes = value; }
        }


    }

    /*
          "ship_id": 119463,
      "company_id": 119055,
      "title": "MSC Splendida",
      "cabinTypes": [
        {
          "nid": 119538,
          "title": "Suite: Executive and Family YC2"
        },
        {
          "nid": 119542,
          "title": "Balcony Cabin: Aurea B3"
        }
      ]
     
     
     */
}