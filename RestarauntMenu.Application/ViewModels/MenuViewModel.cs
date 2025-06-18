using RestarauntMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.ViewModels
{
    public class MenuViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long RestarauntId { get; set; }
        public RestarauntViewModel Restaraunt { get; set; }
        public ICollection<MenuSection> Sections { get; set; }
    }
}
