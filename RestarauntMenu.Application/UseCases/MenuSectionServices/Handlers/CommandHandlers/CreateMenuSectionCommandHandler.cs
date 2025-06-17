using MediatR;
using Microsoft.AspNetCore.Hosting;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Commands;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.CommandHandlers
{
    public class CreateMenuSectionCommandHandler : IRequestHandler<CreateMenuSectionCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateMenuSectionCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateMenuSectionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {



                var pictureFile = request.PhotoPath;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "MenuSectionPhotoPaths");
                string fileName = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "MenuSectionPhotoPaths", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureFile.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseModel(false, "Error in saving image!");
                }



                var menuSection = new MenuSection()
                {
                    Name = request.Name,
                    MenuId = request.MenuId,
                    PhotoPath = "/MenuSectionPhotoPaths/" + fileName
                };

                await _context.MenuSections.AddAsync(menuSection, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var result = new ResponseModel(true,
                    "MenuSection created successfully");

                return result;
            }

            return new ResponseModel(false,
                "MenuSection creation failed. Please try again later. Request is null");
        }
    }
}
