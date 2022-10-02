using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand brandCommand)
        {
            CreateedBrandDto brandDto = await Mediator.Send(brandCommand);
            return Created("", brandDto);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new GetListBrandQuery(){PageRequest = pageRequest};

            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery brandQuery)
        {
           
            BrandGetByIdDto result = await Mediator.Send(brandQuery);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            DeletedBrandDto deletedBrandDto = await Mediator.Send(deleteBrandCommand);
            return Ok(deletedBrandDto);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            UpdatedBrandDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
