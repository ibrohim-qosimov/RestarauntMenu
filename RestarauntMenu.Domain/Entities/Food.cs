namespace RestarauntMenu.Domain.Entities
{
    public class Food
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public decimal Price { get; set; }

        public string PhotoPath { get; set; }

        public long MenuSectionId { get; set; }
        public MenuSection MenuSection { get; set; }
    }
}
