using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Queries
{
    public class GetFoodByIdQuery : IRequest<FoodViewModel>
    {
        public long Id { get; set; }
    }
}
