using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.AuthServices.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
