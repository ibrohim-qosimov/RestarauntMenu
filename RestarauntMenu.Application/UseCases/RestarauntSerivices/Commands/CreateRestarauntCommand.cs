using MediatR;
using Microsoft.AspNetCore.Http;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands
{
    public class CreateRestarauntCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public IFormFile Logo { get; set; }
    }
}
