using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuServices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Handlers.CommandHandlers
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (menu == null)
            {
                return new ResponseModel(false, "Menu not found!");
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel(true, "Menu deleted successfully!");
        }
    }
}
