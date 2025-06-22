using MediatR;
using Microsoft.AspNetCore.Hosting;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;
using System.Diagnostics;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Handlers.CommandHandlers
{
    public class CreateRestarauntCommandHandler : IRequestHandler<CreateRestarauntCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateRestarauntCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateRestarauntCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {



                var pictureFile = request.Logo;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "RestarauntLogos");
                string fileName = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "RestarauntLogos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureFile.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseModel(false, "Error in saving image!");
                }



                var restaraunt = new Restaraunt()
                {
                    Name = request.Name,
                    Address = request.Address,
                    WorkTime = request.WorkTime,
                    AdminId = request.AdminId,
                    LogoPath = "/RestarauntLogos/" + fileName
                };

                await _context.Restaraunts.AddAsync(restaraunt, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var result = new ResponseModel(true,
                    "Restaraunt created successfully");

                return result;
            }

            return new ResponseModel(false,
                "Restaraunt creation failed. Please try again later. Request is null");
        }
    }
}
