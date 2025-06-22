using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Commands
{
    public class UpdateMenuCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? RestarauntId { get; set; }
    }
}
