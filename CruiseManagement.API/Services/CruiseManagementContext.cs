using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CruiseManagement.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CruiseManagement.API.Services
{
    public class CruiseManagementContext : DbContext
    {
        public DbSet<Cruise> Cruises { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<CruiseLine> CruiseLines { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<CabinType> CabinTypes { get; set; }


        public CruiseManagementContext(DbContextOptions<CruiseManagementContext> options)
          : base(options)
        {
        }

    }
}
