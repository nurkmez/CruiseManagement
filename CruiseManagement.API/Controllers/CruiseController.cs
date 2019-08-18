using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CruiseManagement.API.Dtos;
using CruiseManagement.API.Filters;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CruiseManagement.API.Controllers
{
    [Route("api/cruises")]
    [ApiController]
    public class CruiseController : ControllerBase
    {
        private readonly ICruiseManagementRepository _cruiseManagementRepository;
        private readonly IMapper _mapper;

        public CruiseController(ICruiseManagementRepository cruiseManagementRepository, IMapper mapper)
        {
            _cruiseManagementRepository = cruiseManagementRepository ??
                    throw new ArgumentNullException(nameof(cruiseManagementRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        [CruisesResultFilter]
        public async Task<IActionResult> GetCruises()
        {
            var cruises = await _cruiseManagementRepository.GetCruises(true);

            return Ok(cruises);
        }

        [HttpGet]
       // [CruiseWithRoutesResultFilter]
        [Route("{id}", Name = "GetCruise")]
        public async Task<IActionResult> GetCruise(int id)
        {
            var cruiseEntity = await _cruiseManagementRepository.GetCruise(id, true);
            if (cruiseEntity == null)
            {
                return NotFound();
            }

            var cruiseRoutes = await _cruiseManagementRepository.GetRoutes(id);


            var cruiseEntityJson = new
            {
                Id = cruiseEntity.Id,
                ShipId = cruiseEntity.ShipId,
                CruiseLineId = cruiseEntity.CruiseLineId,
                Title = cruiseEntity.Title,
                CabinTypeId = cruiseEntity.CabinTypeId,
                DepartureDate = cruiseEntity.DepartureDate,
                FlightIncluded = cruiseEntity.FlightIncluded,
                Routes = cruiseEntity.Routes.Select(o =>
                        new
                        {
                            Id = o.Id,
                            CruiseId = o.CruiseId,
                            PortId = o.Port.Id,
                            PortName = o.Port.Title,
                            Days = o.Days
                        }).ToList()
            };
            return Ok(cruiseEntityJson);
            
            // return Ok((cruiseEntity, cruiseRoutes));
        }


        [HttpDelete]
        [Route("{id}", Name = "DeleteCruise")]
        public async Task<IActionResult> DeleteCruise([FromRoute] int id)
        {
            _cruiseManagementRepository.DeleteCruise(id);
            await _cruiseManagementRepository.SaveAsync();
            return Ok();
        }


        [HttpPost]
        [CruiseResultFilter]
        public async Task<IActionResult> CreateCruise([FromBody] CruiseWithRoutesForCreation cruise)
        {
                var cruiseEntity = _mapper.Map<Entities.Cruise>(cruise);
                _cruiseManagementRepository.AddCruise(cruiseEntity);
                await _cruiseManagementRepository.SaveAsync();

            return CreatedAtRoute("GetCruise", new { id = cruiseEntity.Id }, cruiseEntity);

        }

        [HttpPost]
        [CruiseResultFilter]
        [Route("{id}", Name = "UpdateCruise")]
        public async Task<IActionResult> UpdateCruise([FromBody] CruiseWithRoutesForUpdate cruise)
        {

            var cruiseEntity = _mapper.Map<Entities.Cruise>(cruise);

            _cruiseManagementRepository.UpdateCruise(cruiseEntity);

            

            foreach (var route in cruiseEntity.Routes)
            {
                if(route.Id ==0)
                {
                    _cruiseManagementRepository.AddRoute(route);
                }
               else
                {
                    _cruiseManagementRepository.UpdateRoute(route);
                }

            }

            var deletedRoutes = cruise.DeletedRoutesIDs.Split(',');

            foreach (var routesId in deletedRoutes)
            {
                int routeId = 0;

                

                if (Int32.TryParse(routesId, out routeId))
                {
                    _cruiseManagementRepository.DeleteRoute(routeId);
                }
            }

            _cruiseManagementRepository.UpdateCruise(cruiseEntity);


            await _cruiseManagementRepository.SaveAsync();

            return CreatedAtRoute("GetCruise", new { id = cruiseEntity.Id }, cruiseEntity);

        }



    }
}