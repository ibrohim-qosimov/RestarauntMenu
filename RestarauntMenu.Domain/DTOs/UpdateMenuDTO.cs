using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Domain.DTOs
{
    public class UpdateMenuDTO
    {
        public string? Name { get; set; }
        public long? RestarauntId { get; set; }
    }
}
