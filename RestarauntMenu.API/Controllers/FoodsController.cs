using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.FoodServices.Commands;
using RestarauntMenu.Application.UseCases.FoodServices.Queries;
using RestarauntMenu.API.Filters;
using RestarauntMenu.Domain.DTOs;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[FoodAccess]
        public async Task<IActionResult> CreateFood([FromForm] CreateFoodCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [FoodAccess]
        public async Task<IActionResult> DeleteFood(long id)
        {
            var command = new DeleteFoodCommand { Id = id };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut("{id}")]
        [FoodAccess]
        public async Task<IActionResult> UpdateFood(long id, [FromForm] UpdateFoodDTO dto)
        {
            var command = new UpdateFoodCommand()
            {
                Id = id,
                Name = dto.Name,
                Allergens = dto.Allergens,
                Ingredients = dto.Ingredients,
                MenuSectionId = dto.MenuSectionId,
                Photo = dto.Photo,
                Price = dto.Price
            };

            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(long id)
        {
            var query = new GetFoodByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Food not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var query = new GetAllFoodsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
