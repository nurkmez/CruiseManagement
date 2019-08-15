using CruiseManagement.API.Entities;
using CruiseManagement.API.Seed;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CruiseManagement.API.Migrations
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            string[] pathofDataDirectory = { Directory.GetCurrentDirectory(), "App_Data", "SeedData" };

            string fullPath_Seed = Path.Combine(pathofDataDirectory);
            string fullPath_cruiseLineSeed = Path.Combine(fullPath_Seed, "cruise-lines.json");
            string fullPath_portsSeed = Path.Combine(fullPath_Seed, "ports.json");
            string fullPath_shipSeed = Path.Combine(fullPath_Seed, "ships.json");


            var portSeed = JsonConvert.DeserializeObject<List<PortSeed>>(File.ReadAllText(fullPath_portsSeed));
            var shipSeed = JsonConvert.DeserializeObject<List<ShipSeed>>(File.ReadAllText(fullPath_shipSeed));
            var cruiseLineSeed = JsonConvert.DeserializeObject<List<CruiseLineSeed>>(File.ReadAllText(fullPath_cruiseLineSeed));

            foreach (var item in cruiseLineSeed)
            {

                modelBuilder.Entity<CruiseLine>()
                  .HasData(new
                  {
                      Id = item.nid,
                      Title = item.title
                  }
                 );
            }

            foreach (var item in portSeed)
            {

                modelBuilder.Entity<Port>()
                  .HasData(new
                  {
                      Id = item.nid,
                      Title = item.title,
                      Country = item.country,
                      CountryCode = item.country_code
                  }
                 );


            }

            foreach (var item in shipSeed)
            {

                modelBuilder.Entity<Ship>()
                  .HasData(new
                  {
                      Id = item.ship_id,
                      Title = item.title,
                      CruiseLineId = item.company_id
                  }
                 );

                foreach (var item2 in item.CabinTypes)
                {
                    modelBuilder.Entity<CabinType>()
                    .HasData(new
                    {
                        Id = item2.nid,
                        Title = item2.title,
                        ShipId = item.ship_id
                    }
                    );

                }

            }



        }
    }
}
