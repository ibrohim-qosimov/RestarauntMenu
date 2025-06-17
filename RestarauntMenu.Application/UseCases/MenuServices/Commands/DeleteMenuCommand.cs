using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Commands
{
    public class DeleteMenuCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
