using System.Collections.Generic;
using WorldTelecomFinal.Models;

namespace WorldTelecomFinal.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }
        public List<Slider> Sliders { get; set; }

        public List<Product> BestSeller { get; set; }
        public List<Product> Feature { get; set; }
        public List<Product> NewArrivel { get; set; }
    }
}
