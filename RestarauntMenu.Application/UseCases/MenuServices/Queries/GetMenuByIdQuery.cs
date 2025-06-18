using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Queries
{
    public class GetMenuByIdQuery : IRequest<MenuViewModel>
    {
        public long Id { get; set; }
    }
}
