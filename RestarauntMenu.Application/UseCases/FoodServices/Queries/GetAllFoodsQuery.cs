using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Queries
{
    public class GetAllFoodsQuery : IRequest<IEnumerable<FoodViewModel>>
    {
    }
}
