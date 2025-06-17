namespace RestarauntMenu.Domain.Entities
{
    public class Restaraunt
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }

        public string LogoPath { get; set; }
    }
}
