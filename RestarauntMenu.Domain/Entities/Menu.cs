namespace RestarauntMenu.Domain.Entities
{
    public class Menu
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long RestarauntId { get; set; }
        public Restaraunt Restaraunt { get; set; }

        public ICollection<MenuSection> Sections { get; set; }
    }
}
