
using AutoMapper;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CruiseManagement.API.Controllers
{
    [Route("api/cruiselines")]

    public class CruiseLineController : Controller
    {
        private readonly ICruiseManagementRepository _cruiseManagementRepository;

        public CruiseLineController(ICruiseManagementRepository cruiseManagementRepository)
        {
            _cruiseManagementRepository = cruiseManagementRepository;
            
        }

        [HttpGet]
        [CruiseLinesResultFilterAttribute]
        public async Task<IActionResult> GetCruiseLines()
        {
            var cruiseLines = await _cruiseManagementRepository.GetCruiseLines();
            return Ok(cruiseLines);
        }
    }
}
