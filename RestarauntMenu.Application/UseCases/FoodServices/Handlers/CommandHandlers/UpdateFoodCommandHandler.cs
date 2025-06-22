using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.FoodServices.Commands;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.FoodServices.Handlers.CommandHandlers
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpdateFoodCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var food = await _context.Foods.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

                if (food != null)
                {
                    if (request.Photo != null)
                    {
                        var photoPath = food.PhotoPath;

                        if (File.Exists(photoPath))
                        {
                            File.Delete(photoPath);
                        }


                        var file = request.Photo;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FoodPhotos");
                        string fileName = "";

                        try
                        {
                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                                Console.WriteLine("Directory created successfully.");
                            }

                            fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FoodPhotos", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            food.PhotoPath = "/FoodPhotos/" + fileName;
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(false, "There is an error in updating image!");
                        }


                    }


                    if (!string.IsNullOrEmpty(request.Name))
                        food.Name = request.Name;

                    if (!string.IsNullOrEmpty(request.Ingredients))
                        food.Ingredients = request.Ingredients;

                    if (!string.IsNullOrEmpty(request.Allergens))
                        food.Allergens = request.Allergens;
                    if (request.Price != null)
                        food.Price = (decimal)request.Price;

                    if (request.MenuSectionId != null)
                        food.MenuSectionId = (long)request.MenuSectionId;


                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel(true, "Food updated successfully!");
                }

                return new ResponseModel(false, "Food not found!");
            }

            return new ResponseModel(false, "The request might be null. Check and try again!");
        }
    }
}
