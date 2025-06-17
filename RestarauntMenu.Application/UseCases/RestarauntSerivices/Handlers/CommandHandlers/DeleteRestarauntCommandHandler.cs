using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Handlers.CommandHandlers
{
    public class DeleteRestarauntCommandHandler : IRequestHandler<DeleteRestarauntCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRestarauntCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteRestarauntCommand request, CancellationToken cancellationToken)
        {
            var restaraunt = await _context.Restaraunts.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (restaraunt == null)
            {
                return new ResponseModel(false, "Restaraunt not found!");
            }

            _context.Restaraunts.Remove(restaraunt);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel(true, "Restaraunt deleted successfully!");
        }
    }
}
