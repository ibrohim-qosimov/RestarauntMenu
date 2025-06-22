using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Domain.DTOs
{
    public class UpdateRestaurantDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? WorkTime { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
