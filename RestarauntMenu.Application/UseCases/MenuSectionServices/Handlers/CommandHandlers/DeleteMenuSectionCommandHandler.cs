using MediatR;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Commands;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.CommandHandlers
{
    public class DeleteMenuSectionCommandHandler : IRequestHandler<DeleteMenuSectionCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuSectionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteMenuSectionCommand request, CancellationToken cancellationToken)
        {
            var menuSection = await _context.MenuSections.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (menuSection == null)
            {
                return new ResponseModel(false, "MenuSection not found!");
            }

            _context.MenuSections.Remove(menuSection);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel(true, "MenuSection deleted successfully!");
        }
    }
}
