using MudBlazor;
using OnlineShop.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Components.Dialogs;

namespace OnlineShop.Pages
{
    public partial class Seller : ShopBase
    {
        async Task clicked()
        {
            await OpenDialog("Doesnt exist", "Ok");
        }

        protected async Task<DialogResult> OpenDialog(string contentText, string buttonText = "Delete")
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", contentText);
            parameters.Add("ButtonText", buttonText);
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService.Show<ProductDialog>("Delete", parameters, options);
            return await dialog.Result;
        }
    }
}
