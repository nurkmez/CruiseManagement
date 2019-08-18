﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CruiseManagement.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CruiseManagement.API.Services
{
    public class CruiseManagementRepository : ICruiseManagementRepository, IDisposable
    {
        private CruiseManagementContext _context;

        public CruiseManagementRepository(CruiseManagementContext context)
        {
            _context = context;
        }
        public void AddCruise(Cruise cruise)
        {
            if (cruise == null)
            {
              throw new ArgumentNullException(nameof(cruise));
            }
            _context.Cruises.AddAsync(cruise);
        }

        public void UpdateCruise(Cruise cruise)
        {
            if (cruise == null)
            {
                throw new ArgumentNullException(nameof(cruise));
            }
            _context.Entry<Cruise>(cruise).State = EntityState.Modified;

            _context.Cruises.Update(cruise);
        }

        public void AddRoute(Route route)
        {
            var cruise = GetCruise(route.CruiseId);
            if (cruise == null)
            {
                throw new Exception($"Cannot add route to cruise with id {route.CruiseId}: cruise not found.");
            }
            _context.Entry<Route>(route).State = EntityState.Added;
            _context.Routes.Add(route);
        }

        public void UpdateRoute(Route route)
        {
            var cruise = GetCruise(route.CruiseId);
            if (cruise == null)
            {
                throw new Exception($"Cannot update route to cruise with id {route.CruiseId}: cruise not found.");
            }
            _context.Entry<Route>(route).State = EntityState.Modified;
            _context.Routes.Update(route);
        }


        public async Task<bool> CruiseExists(int CruiseId)
        {
            return await _context.Cruises.AnyAsync(t => t.Id == CruiseId);
        }

        public void DeleteCruise(int Id)
        {

            var deletedCruise = _context.Cruises.Where(s => s.Id == Id).First();

            if (deletedCruise != null)
            {
                _context.Entry(deletedCruise).State = EntityState.Deleted;
                _context.Cruises.Remove(deletedCruise);
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }


        public async Task<IEnumerable<CabinType>> GetCabinTypes(int ShipId)
        {
            return await _context.CabinTypes.Where(s => s.ShipId == ShipId).ToListAsync();
        }

        public async Task<Cruise> GetCruise(int CruiseId, bool includeRoutes = false)
        {
            if (includeRoutes)
            {
                return await _context.Cruises.Include(t => t.CruiseLine).Include(t => t.Ship)
                    .Include(t => t.CabinType).Include(t => t.Routes)
                    .Where(t => t.Id == CruiseId).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Cruises.Include(t => t.CruiseLine).Include(t => t.Ship)
                             .Include(t => t.CabinType)
                             .Where(t => t.Id == CruiseId).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<CruiseLine>> GetCruiseLines()
        {
            return await  _context.CruiseLines.ToListAsync();
        }

        public async Task<IEnumerable<Cruise>> GetCruises(bool includeRoutes = false)
        {
            if (includeRoutes)
            {
                return await _context.Cruises.Include(t => t.CruiseLine).Include(t => t.Ship)
                   .Include(t => t.CabinType).Include(t => t.Routes)
                   .ToListAsync();
            }
            else
            {
                return await _context.Cruises.ToListAsync();
            }
        }

        public async Task<IEnumerable<Port>> GetPorts()
        {
            return await _context.Ports.ToListAsync();
        }

        public async Task<Port> GetPort(int PortId)
        {
            return await _context.Ports.Where(s => s.Id == PortId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Route>> GetRoutes(int CruiseId)
        {
            return await _context.Routes.Include(p=>p.Port).Where(s => s.CruiseId == CruiseId).ToListAsync();
        }

        public async Task<IEnumerable<Route>> GetRoutes(int CruiseId, IEnumerable<int> RouteIds)
        {
            return await _context.Routes
                        .Where(s => s.CruiseId == CruiseId && RouteIds.Contains(s.CruiseId))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Ship>> GetShips(int CruiseLineId)
        {
            return await _context.Ships.Where(s => s.CruiseLineId == CruiseLineId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }


        public async Task<IEnumerable<Ship>> GetShips()
        {
            return await _context.Ships.ToListAsync();
        }

        public async Task<IEnumerable<CabinType>> GetCabinTypes()
        {
            return await _context.CabinTypes.ToListAsync();
        }

        public async Task<CabinType> GetCabinType(int CabinTypeId)
        {
            return await _context.CabinTypes.Where(s => s.Id == CabinTypeId).FirstOrDefaultAsync();
        }

        public async Task<Ship> GetShip(int ShipId)
        {
            return await _context.Ships.Where(s => s.Id == ShipId).FirstOrDefaultAsync();
        }

        public async Task<CruiseLine> GetCruiseLine(int CruiseLineId)
        {
            return await _context.CruiseLines.Where(s => s.Id == CruiseLineId).FirstOrDefaultAsync();
        }

        public void DeleteRoute(int routeId)
        {
            var deletedRoute = _context.Routes.Where(s => s.Id == routeId).First();
            if (deletedRoute != null)
            {
                _context.Entry(deletedRoute).State = EntityState.Deleted;
                _context.Routes.Remove(deletedRoute);
            }
        }
    }
}
