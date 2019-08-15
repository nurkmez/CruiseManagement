
using AutoMapper;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CruiseManagement.API.Controllers
{
    [Route("api/cabintypes")]

    public class CabinTypeController : Controller
    {
        private readonly ICruiseManagementRepository _cruiseManagementRepository;

        public CabinTypeController(ICruiseManagementRepository cruiseManagementRepository)
        {
            _cruiseManagementRepository = cruiseManagementRepository;
            
        }


        [HttpGet]
        [CabinTypesResultFilterAttribute]
        [Route("{shipId}", Name = "GetCabinTypes")]

        public async Task<IActionResult> GetCabinTypes(int shipId)
        {
            var cruiseLines = await _cruiseManagementRepository.GetCabinTypes(shipId);
            return Ok(cruiseLines);
        }


        [HttpGet]
        [CabinTypesResultFilterAttribute]
        public async Task<IActionResult> GetCabinTypes()
        {
            var cabinTypes = await _cruiseManagementRepository.GetCabinTypes();
            return Ok(cabinTypes);
        }
    }
}
