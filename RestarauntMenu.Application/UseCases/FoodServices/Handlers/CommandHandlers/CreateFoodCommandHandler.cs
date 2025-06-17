using MediatR;
using Microsoft.AspNetCore.Hosting;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.FoodServices.Commands;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;
using System.Diagnostics;

namespace RestarauntMenu.Application.UseCases.FoodServices.Handlers.CommandHandlers
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateFoodCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var pictureFile = request.Photo;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FoodPhotos");
                string fileName = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FoodPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureFile.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseModel(false, "Error in saving image!");
                }

                var food = new Food()
                {
                    Name = request.Name,
                    Allergens = request.Allergens,
                    PhotoPath = "/FoodPhotos/" + fileName,
                    Price = request.Price,
                    Ingredients = request.Ingredients,
                    MenuSectionId = request.MenuSectionId
                };

                await _context.Foods.AddAsync(food, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var result = new ResponseModel(true,
                    "Food created successfully");

                return result;
            }

            return new ResponseModel(false, "The request might be null, check & try again!");
        }
    }
}