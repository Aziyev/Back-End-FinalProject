using System.Collections.Generic;
using System.Threading.Tasks;
using WorldTelecomFinal.ViewModels.BasketViewModels;

namespace WorldTelecomFinal.Interfaces
{
    public interface ILayoutService
    {
        Task<List<BasketVM>> GetBasket();
        Task<IDictionary<string,string>> GetSetting();

    }
}
