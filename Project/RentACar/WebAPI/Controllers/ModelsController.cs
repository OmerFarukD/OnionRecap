using Application.Features.Brands.Models;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("getlistmodel")]
        public async Task<IActionResult> GeListModel([FromQuery]PageRequest pageRequest)
        {
            GetListModelQuery data = new GetListModelQuery() { PageRequest = pageRequest};
            ModelListModel result = await Mediator.Send(data);
            return Ok(result);
        }

        [HttpPost("getlist/bydynamic")]
        public async Task<IActionResult> GeListModel([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery data = new GetListModelByDynamicQuery() { PageRequest = pageRequest ,Dynamic = dynamic};
            ModelListModel result = await Mediator.Send(data);
            return Ok(result);
        }
    }
}
