using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Queries;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.QueryHandlers
{
    public class GetAllMenuSectionQueryHandler : IRequestHandler<GetAllMenuSectionQuery, IEnumerable<MenuSectionViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMenuSectionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuSectionViewModel>> Handle(GetAllMenuSectionQuery request, CancellationToken cancellationToken)
        {
            var menuSections = _context.MenuSections.Select(x => new MenuSectionViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PhotoPath = x.PhotoPath
            });

            return menuSections;
        }
    }
}
