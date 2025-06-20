using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Commands;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Queries;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuSectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuSectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuSection([FromForm] CreateMenuSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuSection(long id)
        {
            var command = new DeleteMenuSectionCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuSection([FromForm] UpdateMenuSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuSectionById(long id)
        {
            var query = new GetMenuSectionByIdQuery() { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuSections()
        {
            var query = new GetAllMenuSectionQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("byMenuId/{menuId}")]
        public async Task<IActionResult> GetMenuSectionsByMenuId(long menuId)
        {
            var query = new GetMenuSectionsByMenuIdQuery()
            {
                MenuId = menuId
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
