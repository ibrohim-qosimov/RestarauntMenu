using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Application.UseCases.AuthServices.Commands;
using RestarauntMenu.Application.ViewModels;
using RestarauntMenu.Domain.Entities;
using RestarauntMenu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.AuthServices.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly PasswordHasher<User> _hasher = new();

        public RegisterUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == request.PhoneNumber))
                return new ResponseModel(false,"User already exist");

            var user = new User
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Role = UserRole.User,
                PasswordHash = _hasher.HashPassword(null!, request.Password)
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new ResponseModel(true, "User Created Successfully");

            return response;

        }
    }
}
