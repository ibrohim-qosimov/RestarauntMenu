using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Queries;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.QueryHandlers
{
    public class GetMenuSectionsByMenuIdQueryHandler : IRequestHandler<GetMenuSectionsByMenuIdQuery, IEnumerable<MenuSectionViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetMenuSectionsByMenuIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuSectionViewModel>> Handle(GetMenuSectionsByMenuIdQuery request, CancellationToken cancellationToken)
        {
            var response = _context.MenuSections.Where(ms => request.MenuId == ms.MenuId).Select(ms => new MenuSectionViewModel
            {
                Id = ms.Id,
                Name = ms.Name,
                PhotoPath = ms.PhotoPath
            });

            return response;
        }
    }
}
