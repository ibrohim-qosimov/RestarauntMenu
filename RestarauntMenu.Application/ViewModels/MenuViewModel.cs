namespace RestarauntMenu.Application.ViewModels
{
    public class MenuViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long RestarauntId { get; set; }
        public RestarauntViewModel Restaraunt { get; set; }
        public ICollection<MenuSectionViewModel> Sections { get; set; }
    }
}
