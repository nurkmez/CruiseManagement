using CruiseManagement.API.Entities;
using CruiseManagement.API.Seed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Services
{
    public static class CruiseManagementContextExtensions
    {
        public static void EnsureSeedDataForContext(this CruiseManagementContext context)
        {
            context.Cruises.RemoveRange(context.Cruises);
            context.CruiseLines.RemoveRange(context.CruiseLines);
            context.Ships.RemoveRange(context.Ships);
            context.CabinTypes.RemoveRange(context.CabinTypes);
            context.Routes.RemoveRange(context.Routes);
            context.Ports.RemoveRange(context.Ports);

            context.SaveChanges();


            string[] pathofDataDirectory = { Directory.GetCurrentDirectory(), "App_Data", "SeedData" };

            string fullPath_Seed = Path.Combine(pathofDataDirectory);
            string fullPath_cruiseLineSeed = Path.Combine(fullPath_Seed, "cruise-lines.json");
            string fullPath_portsSeed = Path.Combine(fullPath_Seed, "ports.json");
            string fullPath_shipSeed = Path.Combine(fullPath_Seed, "ships.json");


            var portSeed = JsonConvert.DeserializeObject<List<PortSeed>>(File.ReadAllText(fullPath_portsSeed));
            var shipSeed = JsonConvert.DeserializeObject<List<ShipSeed>>(File.ReadAllText(fullPath_shipSeed));
            var cruiseLineSeed = JsonConvert.DeserializeObject<List<CruiseLineSeed>>(File.ReadAllText(fullPath_cruiseLineSeed));

            var cruiseLines = new List<CruiseLine>();

            foreach (var item in cruiseLineSeed)
            {
                var cruiseLine = new CruiseLine();
                cruiseLine.Id = item.nid;
                cruiseLine.Title = item.title;

                cruiseLines.Add(cruiseLine);
            }

            context.CruiseLines.AddRange(cruiseLines);

            
            var ports = new List<Port>();

            foreach (var item in portSeed)
            {
                ports.Add(new Port
                {
                    Id = item.nid,
                    Title = item.title,
                    Country = item.country,
                    CountryCode = item.country_code
                });
                
            }

            context.Ports.AddRange(ports); 
            

           
            var ships = new List<Ship>();

            foreach (var item in shipSeed)
            {
                ships.Add(
                new Ship()
                {
                    Id = item.ship_id,
                    Title = item.title,
                    CruiseLineId = item.company_id,
                    CabinTypes = item.CabinTypes
                            .Select(s => new CabinType { Id = s.nid, Title = s.title, ShipId = item.ship_id })
                            .ToList<CabinType>()
                }
                );
 
            }

            context.Ships.AddRange(ships);



            context.SaveChanges();
        }
    }
}
