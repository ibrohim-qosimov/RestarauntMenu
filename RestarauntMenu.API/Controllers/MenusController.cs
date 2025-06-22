using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.API.Filters;
using RestarauntMenu.Application.UseCases.MenuServices.Commands;
using RestarauntMenu.Application.UseCases.MenuServices.Queries;
using RestarauntMenu.Domain.DTOs;

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
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateMenu([FromForm] CreateMenuCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [MenuAccess]
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

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [MenuAccess]
        public async Task<IActionResult> UpdateMenu(long id, [FromForm] UpdateMenuDTO dto)
        {
            var command = new UpdateMenuCommand()
            {
                Id = id,
                Name = dto.Name,
                RestarauntId = dto.RestarauntId,
            };

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
