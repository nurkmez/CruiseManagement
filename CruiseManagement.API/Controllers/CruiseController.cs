using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CruiseManagement.API.Dtos;
using CruiseManagement.API.Filters;
using CruiseManagement.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var cruises = await _cruiseManagementRepository.GetCruises();

            // var mapper = (IMapper)HttpContext.RequestServices.GetService(typeof(IMapper));

            // var cruisesOutput = mapper.Map<IEnumerable<CruiseManagement.API.Dtos.Cruise>>(cruises);

            return Ok(cruises);
        }

        [HttpGet]
        [CruiseWithRoutesResultFilter]
        [Route("{id}", Name = "GetCruise")]
        public async Task<IActionResult> GetCruise(int id)
        {
            var cruiseEntity = await _cruiseManagementRepository.GetCruise(id);
            if (cruiseEntity == null)
            {
                return NotFound();
            }

            var cruiseRoutes = await _cruiseManagementRepository.GetRoutes(id);

            return Ok((cruiseEntity, cruiseRoutes));
        }

        [HttpPost]
        [CruiseResultFilter]
        public async Task<IActionResult> CreateCruise([FromBody] CruiseWithRoutesForCreation cruise)
        {
                var cruiseEntity = _mapper.Map<Entities.Cruise>(cruise);
                _cruiseManagementRepository.AddCruise(cruiseEntity);
                await _cruiseManagementRepository.SaveAsync();

                return CreatedAtRoute("GetCruise",
                    new { id = cruiseEntity.Id },
                    cruiseEntity);

        }



    }
}