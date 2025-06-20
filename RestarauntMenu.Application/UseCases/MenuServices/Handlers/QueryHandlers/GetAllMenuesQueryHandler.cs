using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuServices.Queries;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuServices.Handlers.QueryHandlers
{
    public class GetAllMenuesQueryHandler : IRequestHandler<GetAllMenuesQuery, IEnumerable<MenuViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMenuesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuViewModel>> Handle(GetAllMenuesQuery request, CancellationToken cancellationToken)
        {
            var response = _context.Menus.Select(r => new MenuViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                RestarauntId = r.RestarauntId
            });
            return response;
        }
    }
}
