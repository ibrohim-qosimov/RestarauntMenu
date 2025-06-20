using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuServices.Queries;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Exceptions;

namespace RestarauntMenu.Application.UseCases.MenuServices.Handlers.QueryHandlers
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, MenuViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetMenuByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuViewModel> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var r = await _context.Menus
                .Include(m => m.Restaraunt)
                .Include(m => m.Sections)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException("Menu");

            var response = new MenuViewModel
            {
                Id = r.Id,
                Name = r.Name,
                RestarauntId = r.RestarauntId
            };

            return response;
        }

    }
}
