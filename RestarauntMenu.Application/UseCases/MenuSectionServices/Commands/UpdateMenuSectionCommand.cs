using MediatR;
using Microsoft.AspNetCore.Http;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Commands
{
    public class UpdateMenuSectionCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public IFormFile? PhotoPath { get; set; }

        public long MenuId { get; set; }
    }
}
