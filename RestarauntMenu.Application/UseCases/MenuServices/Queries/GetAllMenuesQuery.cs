using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Queries
{
    public class GetAllMenuesQuery : IRequest<IEnumerable<MenuViewModel>>
    {
    }
}
