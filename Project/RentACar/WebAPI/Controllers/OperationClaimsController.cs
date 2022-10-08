using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController :BaseController
    {
        [HttpPost("addoperationclaims")]
        public async Task<IActionResult> AddOperationClaim([FromBody]CreateOperationClaimCommand command)
        {
            CreateOperationClaimDto result = await Mediator.Send(command);

            return Created("", result);
        }

        [HttpGet("getbylistoperationclaim")]
        public async Task<IActionResult> GetByListOperationClaim([FromQuery]PageRequest pageRequest)
        {
            GetListOperationClaimQuery query = new() { PageRequest = pageRequest };
            GetOperationClaimModel model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpGet("getbyidoperationclaim/{id}")]
        public async Task<IActionResult> GetByIdOperationClaim([FromRoute] int id)
        {
            GetByIdOperationClaimQuery query = new() {Id = id};
            GetByIdOperationClaimDto result = await Mediator.Send(query);
            return Ok(result);
        }

    }

