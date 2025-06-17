using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Handlers.CommandHandlers
{
    public class UpdateRestarauntCommandHandler : IRequestHandler<UpdateRestarauntCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateRestarauntCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateRestarauntCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var restaraunt = await _context.Restaraunts.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

                if (restaraunt != null)
                {
                    if (request.Logo != null)
                    {
                        var logoPath = restaraunt.LogoPath;

                        if (File.Exists(logoPath))
                        {
                            File.Delete(logoPath);
                        }


                        var file = request.Logo;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "RestarauntLogos");
                        string fileName = "";

                        try
                        {
                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                                Console.WriteLine("Directory created successfully.");
                            }

                            fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            filePath = Path.Combine(_webHostEnvironment.WebRootPath, "RestarauntLogos", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            restaraunt.LogoPath = "/RestarauntLogos/" + fileName;
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(false, "There is an error in updating image!");
                        }


                    }

                    if (!string.IsNullOrEmpty(request.Name))
                        restaraunt.Name = request.Name;

                    if (!string.IsNullOrEmpty(request.Address))
                        restaraunt.Address = request.Address;

                    if (!string.IsNullOrEmpty(request.WorkTime))
                        restaraunt.WorkTime = request.WorkTime;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel(true, "Restaraunt updated successfully!");
                }

                return new ResponseModel(false, "Restaraunt not found!");
            }

            return new ResponseModel(false, "The request might be null. Check and try again!");
        }
    }
}
