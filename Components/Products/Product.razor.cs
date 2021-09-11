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
        [Parameter] public bool IsSeller { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            authState = await _authState;
        }

        async Task DeleteProduct()
        {
            var result = await OpenDialog<ConfirmDialog>("Delete product", "Ok");
            
            if (!result.Cancelled)
            {
                _db.DeleteProduct(authState.User.Claims.ToList()[0].Value, ProductModel.Id);
                ShowSnackbar($"Product {ProductModel.Id} deleted", Defaults.Classes.Position.BottomCenter);
                await OnDelete.InvokeAsync("Product deleted!");
            }
        }

        void ShowDetails()
        {
            NavigationManager.NavigateTo("/productDetails/" + ProductModel.Id, forceLoad: true);
        }
    }
}
