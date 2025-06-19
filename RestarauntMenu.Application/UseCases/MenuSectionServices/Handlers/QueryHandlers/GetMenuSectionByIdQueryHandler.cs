using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Queries;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Exceptions;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.QueryHandlers
{
    public class GetMenuSectionByIdQueryHandler : IRequestHandler<GetMenuSectionByIdQuery, MenuSectionViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetMenuSectionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuSectionViewModel> Handle(GetMenuSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var menuSection = await _context.MenuSections.FirstOrDefaultAsync(ms => request.Id == ms.Id, cancellationToken) ?? throw new NotFoundException("MenuSection");

            var response = new MenuSectionViewModel()
            {
                Id = menuSection.Id,
                Name = menuSection.Name,
                PhotoPath = menuSection.PhotoPath
            };

            return response;
        }
    }
}
