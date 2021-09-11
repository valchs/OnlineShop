using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnlineShop.BusinessLogic;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Components.Dialogs;

namespace OnlineShop.Components.Products
{
    public partial class Product : ShopBase
    {
        [Inject] public ProductData _db { get; set; }
        [Parameter] public ProductModel ProductModel { get; set; }
        [Parameter] public EventCallback<string> OnDelete { get; set; }

        protected override async Task OnInitializedAsync()
        {
            authState = await _authState;
        }

        async Task DeleteProduct()
        {
            var result = await OpenDialog("Delete product", "Ok");
            
            if (!result.Cancelled)
            {
                _db.DeleteProduct(authState.User.Claims.ToList()[0].Value, ProductModel.Id);
                ShowSnackbar($"Product {ProductModel.Id} deleted", Defaults.Classes.Position.BottomCenter);
                await OnDelete.InvokeAsync("Product deleted!");
            }
        }

        protected async Task<DialogResult> OpenDialog(string contentText, string buttonText = "Delete")
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", contentText);
            parameters.Add("ButtonText", buttonText);
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService.Show<ConfirmDialog>(contentText, parameters, options);
            return await dialog.Result;
        }
    }
}
