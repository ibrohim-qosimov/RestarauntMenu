using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Handlers.QueryHandlers
{
    public class GetAllRestarauntsQueryHandler : IRequestHandler<GetAllRestarauntsQuery, IEnumerable<RestarauntViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRestarauntsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestarauntViewModel>> Handle(GetAllRestarauntsQuery request, CancellationToken cancellationToken)
        {
            var response = _context.Restaraunts.Select(r => new RestarauntViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                WorkTime = r.WorkTime,
                LogoPath = r.LogoPath
            });
            return response;
        }
    }
}
