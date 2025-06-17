namespace RestarauntMenu.Domain.Entities
{
    public class MenuSection
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public long MenuId { get; set; }
        public Menu Menu { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
