using MediatR;
using Microsoft.AspNetCore.Http;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands
{
        public class UpdateRestarauntCommand : IRequest<ResponseModel>
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public string? Address { get; set; }
            public string? WorkTime { get; set; }
            public long? AdminId { get; set; }
            public IFormFile? Logo { get; set; }
        }
}
