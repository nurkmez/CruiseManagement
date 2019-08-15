using CruiseManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CruiseManagement.API.Services
{
    public interface ICruiseManagementRepository
    {
        void AddCruise(Cruise cruise);
        Task DeleteCruise(Cruise cruise);
        Task<Cruise> GetCruise(int CruiseId, bool includeRoutes = false);
        Task<IEnumerable<Cruise>> GetCruises(bool includeRoutes = false);
        Task<bool> SaveAsync();
        Task<bool> CruiseExists(int CruiseId);
        Task UpdateCruise(Cruise Cruise);
        Task<IEnumerable<Route>> GetRoutes(int CruiseId);
        Task<IEnumerable<Route>> GetRoutes(int CruiseId, IEnumerable<int> RouteIds);
        Task AddRoute(int CruiseId, Route Route);
        Task<IEnumerable<CruiseLine>> GetCruiseLines();
        Task<IEnumerable<Ship>> GetShips(int CruiseLineId);
        Task<IEnumerable<Ship>> GetShips();
        Task<IEnumerable<CabinType>> GetCabinTypes(int ShipId);
        Task<CabinType> GetCabinType(int CabinTypeId);
        Task<Ship> GetShip(int ShipId);
        Task<CruiseLine> GetCruiseLine(int CruiseLineId);

        Task<IEnumerable<CabinType>> GetCabinTypes();

        Task<IEnumerable<Port>> GetPorts();
    }
}
