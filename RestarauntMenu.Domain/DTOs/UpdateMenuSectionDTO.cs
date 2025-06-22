using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Domain.DTOs
{
    public class UpdateMenuSectionDTO
    {
        public string? Name { get; set; }

        public IFormFile? Photo { get; set; }

        public long? MenuId { get; set; }
    }
}
