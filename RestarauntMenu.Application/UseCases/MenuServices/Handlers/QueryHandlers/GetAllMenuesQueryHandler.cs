using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuServices.Queries;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;

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
                RestarauntId = r.RestarauntId,
                Restaraunt = new RestarauntViewModel() {Id = r.Restaraunt.Id, Name = r.Restaraunt.Name, Address = r.Restaraunt.Address, WorkTime = r.Restaraunt.WorkTime, LogoPath = r.Restaraunt.LogoPath},
                Sections = r.Sections.Select(c => new MenuSection
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhotoPath = c.PhotoPath
                }).ToList()

            });
            return response;
        }
    }
}
