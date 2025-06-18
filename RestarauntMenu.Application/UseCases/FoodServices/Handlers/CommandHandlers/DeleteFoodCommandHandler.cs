using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.FoodServices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Handlers.CommandHandlers
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFoodCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _context.Foods.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (food == null)
                return new ResponseModel(false, "Food is not found!");

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel(true, "Food deleted successfully!");
        }
    }
}
