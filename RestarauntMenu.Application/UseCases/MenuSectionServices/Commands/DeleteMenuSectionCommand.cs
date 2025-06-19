using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Commands
{
    public class DeleteMenuSectionCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
