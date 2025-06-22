using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.MenuSectionServices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.MenuSectionServices.Handlers.CommandHandlers
{
    public class UpdateMenuSectionCommandHandler : IRequestHandler<UpdateMenuSectionCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateMenuSectionCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateMenuSectionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var menuSection = await _context.MenuSections.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

                if (menuSection != null)
                {
                    if (request.PhotoPath != null)
                    {
                        var logoPath = menuSection.PhotoPath;

                        if (File.Exists(logoPath))
                        {
                            File.Delete(logoPath);
                        }


                        var file = request.PhotoPath;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "MenuSectionPhotoPaths");
                        string fileName = "";

                        try
                        {
                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                                Console.WriteLine("Directory created successfully.");
                            }

                            fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            filePath = Path.Combine(_webHostEnvironment.WebRootPath, "MenuSectionPhotoPaths", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            menuSection.PhotoPath = "/MenuSectionPhotoPaths/" + fileName;
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(false, "There is an error in updating image!");
                        }


                    }

                    if (!string.IsNullOrEmpty(request.Name))
                        menuSection.Name = request.Name;

                    if (request.MenuId != null)
                        menuSection.MenuId = (long)request.MenuId;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel(true, "MenuSection updated successfully!");
                }

                return new ResponseModel(false, "MenuSection not found!");
            }

            return new ResponseModel(false, "The request might be null. Check and try again!");
        }
    }
}
