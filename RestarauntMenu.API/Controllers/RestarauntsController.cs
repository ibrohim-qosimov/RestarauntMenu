using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestarauntsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestarauntsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaraunt([FromForm] CreateRestarauntCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaraunt(long id)
        {
            var command = new DeleteRestarauntCommand { Id = id };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaraunt([FromForm] UpdateRestarauntCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestarauntById(long id)
        {
            var query = new GetRestarauntByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Restaraunt not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaraunts()
        {
            var query = new GetAllRestarauntsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
