using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.MenuServices.Commands;
using RestarauntMenu.Application.UseCases.MenuServices.Queries;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromForm] CreateMenuCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(long id)
        {
            var command = new DeleteMenuCommand { Id = id };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromForm] UpdateMenuCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(long id)
        {
            var query = new GetMenuByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Menu not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaraunts()
        {
            var query = new GetAllMenuesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
