using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Exceptions;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Handlers.QueryHandlers
{
    public class GetRestarauntByIdQueryHandler : IRequestHandler<GetRestarauntByIdQuery, RestarauntViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetRestarauntByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RestarauntViewModel> Handle(GetRestarauntByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Restaraunts.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken) ?? throw new NotFoundException("Restaraunt");

            var response = new RestarauntViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Address = result.Address,
                WorkTime = result.WorkTime,
                LogoPath = result.LogoPath
            };

            return response;
        }
    }
}
