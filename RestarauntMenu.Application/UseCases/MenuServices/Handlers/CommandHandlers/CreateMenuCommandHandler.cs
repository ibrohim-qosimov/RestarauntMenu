using MediatR;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuServices.Commands;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;

namespace RestarauntMenu.Application.UseCases.MenuServices.Handlers.CommandHandlers
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var menu = new Menu()
                {
                    Name = request.Name,
                    RestarauntId = request.RestarauntId
                };

                await _context.Menus.AddAsync(menu, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var result = new ResponseModel(true,
                    "Menu created successfully");

                return result;
            }

            return new ResponseModel(false,
                "Menu creation failed. Please try again later. Request is null");
        }
    }
}
