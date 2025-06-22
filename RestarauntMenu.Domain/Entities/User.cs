using RestarauntMenu.Domain.DTOs;
using RestarauntMenu.Domain.Enums;

namespace RestarauntMenu.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string PasswordHash { get; set; }

        /// <summary>
        ///  Admin uchun restarant qoshiladi, restarantni boshqarish uchun , restaraunt create vaqtidaaaa
        /// </summary>
        public Restaraunt? Restaraunt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
