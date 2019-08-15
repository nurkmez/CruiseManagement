using AutoMapper;
using CruiseManagement.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseManagement.API.Filters
{
    public class CruiseWithRoutesResultFilterAttribute: ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(
           ResultExecutingContext context,
           ResultExecutionDelegate next)
        {

            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            var (cruise, cruiseRuotes) = ((Entities.Cruise,
                IEnumerable<Dtos.Route>))resultFromAction.Value;

            var mapper = (IMapper)context.HttpContext.RequestServices.GetService(typeof(IMapper));

            var mappedCruise = mapper.Map<CruiseWithRoutes>(cruise);

            resultFromAction.Value = mapper.Map(cruiseRuotes, mappedCruise);

            await next();
        }
    }
}
