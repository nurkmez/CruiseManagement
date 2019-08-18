
using AutoMapper;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CruiseManagement.API.Controllers
{
    [Route("api/ports")]

    public class PortController : Controller
    {
        private readonly ICruiseManagementRepository _cruiseManagementRepository;

        public PortController(ICruiseManagementRepository cruiseManagementRepository)
        {
            _cruiseManagementRepository = cruiseManagementRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPorts()
        {
            var ports = await _cruiseManagementRepository.GetPorts();


            return Ok(ports);
        }
    }
}
