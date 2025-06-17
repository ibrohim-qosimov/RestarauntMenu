using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Commands
{
    public class DeleteFoodCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
