using Microsoft.AspNetCore.Components;
using OnlineShop.BusinessLogic;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class Index : ShopBase
    {
        private ItemModel value;

        void ShowDetails(int id)
        {
            NavigationManager.NavigateTo("/productDetails/" + id);
        }
        private async Task<IEnumerable<ItemModel>> Search(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            // if text is null or empty, don't return values (drop-down will not open)
            if (string.IsNullOrEmpty(value))
                return new ItemModel[0];
            return AppState.Items.Where(x => x.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        void ProductChanged(ItemModel product)
        {
            NavigationManager.NavigateTo("/productDetails/" + product.Id);
        }

    }
}
