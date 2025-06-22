using MediatR;
using Microsoft.AspNetCore.Http;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Commands
{
    public class UpdateFoodCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }

        public string? Name { get; set; }
        public string? Ingredients { get; set; }
        public decimal? Price { get; set; }
        public string? Allergens { get; set; }

        public IFormFile? Photo { get; set; }

        public long? MenuSectionId { get; set; }
    }
}
