using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Queries
{
    public class GetMenuSectionsByMenuIdQuery : IRequest<IEnumerable<MenuSectionViewModel>>
    {
        public long MenuId { get; set; }
    }
}
