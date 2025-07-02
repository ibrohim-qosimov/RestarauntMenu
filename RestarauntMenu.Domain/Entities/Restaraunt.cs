using RestarauntMenu.Domain.DTOs;
using System.Net.Sockets;

namespace RestarauntMenu.Domain.Entities
{
    public class Restaraunt
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        

        /// <summary>
        /// Har bitta admin faqat bitta restaurant uchun javobgarrrr
        /// </summary>
        public long UserId { get; set; }
        public User User { get; set; }


        public string LogoPath { get; set; }
    }
}
