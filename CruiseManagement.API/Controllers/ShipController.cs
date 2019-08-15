
using AutoMapper;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CruiseManagement.API.Controllers
{
    [Route("api/ships")]

    public class ShipController : Controller
    {
        private readonly ICruiseManagementRepository _cruiseManagementRepository;

        public ShipController(ICruiseManagementRepository cruiseManagementRepository)
        {
            _cruiseManagementRepository = cruiseManagementRepository;
            
        }
        [HttpGet]
        [ShipsResultFilterAttribute]
        [Route("{cruiseLineId}", Name = "GetShips")]
        public async Task<IActionResult> GetShips(int cruiseLineId)
        {
            var ships = await _cruiseManagementRepository.GetShips(cruiseLineId);

            return Ok(ships);
        }

        [HttpGet]
        [ShipsResultFilterAttribute]
        public async Task<IActionResult> GetShips()
        {
            var ships = await _cruiseManagementRepository.GetShips();


            return Ok(ships);
        }
    }
}
