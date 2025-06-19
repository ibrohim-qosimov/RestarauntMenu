using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Queries
{
    public class GetMenuSectionByIdQuery : IRequest<MenuSectionViewModel>
    {
        public long Id { get; set; }
    }
}
