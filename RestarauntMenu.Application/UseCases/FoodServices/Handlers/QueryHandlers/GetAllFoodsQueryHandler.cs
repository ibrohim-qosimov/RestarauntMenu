using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.FoodServices.Queries;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Handlers.QueryHandlers
{
    public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, IEnumerable<FoodViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllFoodsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodViewModel>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
        {
            var response = _context.Foods.Select(r => new FoodViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                Allergens = r.Allergens,
                Ingredients = r.Ingredients,
                PhotoPath = r.PhotoPath,
                Price = r.Price
            });
            return response;
        }
    }
}
