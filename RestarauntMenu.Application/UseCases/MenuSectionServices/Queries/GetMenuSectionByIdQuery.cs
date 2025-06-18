using MediatR;
using RestarauntMenu.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Queries
{
    public class GetMenuSectionByIdQuery : IRequest<MenuSectionViewModel>
    {
        public long Id { get; set; }
    }
}
