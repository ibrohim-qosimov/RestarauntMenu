namespace RestarauntMenu.Application.ViewModels
{
    public class FoodViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public decimal Price { get; set; }

        public string PhotoPath { get; set; }
    }
}
