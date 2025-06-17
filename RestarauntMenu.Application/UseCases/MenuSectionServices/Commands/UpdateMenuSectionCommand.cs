using MediatR;
using Microsoft.AspNetCore.Http;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Commands
{
    public class UpdateMenuSectionCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public IFormFile? PhotoPath { get; set; }

        public long MenuId { get; set; }
    }
}
