using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Queries
{
    public class GetAllMenuSectionQuery : IRequest<IEnumerable<MenuSectionViewModel>>
    {
    }
}
