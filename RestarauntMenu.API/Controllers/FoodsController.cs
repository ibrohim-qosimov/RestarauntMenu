using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.FoodServices.Commands;
using RestarauntMenu.Application.UseCases.FoodServices.Queries;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood([FromForm] CreateFoodCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
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

        [HttpPut]
        public async Task<IActionResult> UpdateFood([FromForm] UpdateFoodCommand command)
        {
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
