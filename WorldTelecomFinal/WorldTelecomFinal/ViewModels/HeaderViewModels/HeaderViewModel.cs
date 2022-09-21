using System.Collections.Generic;
using WorldTelecomFinal.ViewModels.BasketViewModels;

namespace WorldTelecomFinal.ViewModels.HeaderViewModels
{
    public class HeaderViewModel
    {
        public IDictionary<string, string> Settings { get; set; }
        public List<BasketVM> BasketVMs { get; set; }
    }
}
