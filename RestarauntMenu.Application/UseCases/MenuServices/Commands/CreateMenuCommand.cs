using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Commands
{
    public class CreateMenuCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }

        public long RestarauntId { get; set; }
    }
}
