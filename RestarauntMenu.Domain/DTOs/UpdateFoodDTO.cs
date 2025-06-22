using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Domain.DTOs
{
    public class UpdateFoodDTO
    {
        public string? Name { get; set; }
        public string? Ingredients { get; set; }
        public decimal? Price { get; set; }
        public string? Allergens { get; set; }

        public IFormFile? Photo { get; set; }

        public long? MenuSectionId { get; set; }
    }
}
