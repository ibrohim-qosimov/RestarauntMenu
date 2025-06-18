using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.FoodServices.Queries;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Exceptions;

namespace RestarauntMenu.Application.UseCases.FoodServices.Handlers.QueryHandlers
{
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetFoodByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FoodViewModel> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken) ?? throw new NotFoundException("Food");

            var response = new FoodViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Allergens = result.Allergens,
                Ingredients = result.Ingredients,
                PhotoPath = result.PhotoPath,
                Price = result.Price
            };

            return response;
        }
    }
}
