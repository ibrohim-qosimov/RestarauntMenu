using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Handlers.CommandHandlers
{
    public class UpdateMenuCommandHandler : IRequestHandler<Commands.UpdateMenuCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(Commands.UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var menu = await _context.Menus.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

                if (menu != null)
                {

                    if (!string.IsNullOrEmpty(request.Name))
                        menu.Name = request.Name;

                    if (request.RestarauntId != null)
                        menu.RestarauntId = (long)request.RestarauntId;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel(true, "Menu updated successfully!");
                }

                return new ResponseModel(false, "Menu not found!");
            }

            return new ResponseModel(false, "The request might be null. Check and try again!");
        }
    }
}
