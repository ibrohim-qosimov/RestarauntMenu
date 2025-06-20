using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Domain.DTOs
{
    public class LoginDTO
    {
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
