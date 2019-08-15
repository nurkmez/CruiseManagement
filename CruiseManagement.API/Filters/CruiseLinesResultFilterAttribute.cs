﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CruiseManagement.API
{

    public class CruiseLinesResultFilterAttribute : ResultFilterAttribute
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


            var mapper = (IMapper)context.HttpContext.RequestServices.GetService(typeof(IMapper));
            resultFromAction.Value = mapper.Map<IEnumerable<Dtos.CruiseLine>>(resultFromAction.Value);

            await next();
        }

    }

}
