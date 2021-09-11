using MudBlazor;
using OnlineShop.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Components.Dialogs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;

namespace OnlineShop.Pages
{
    public partial class Seller : ShopBase
    {
        [Inject] public ProductData _db { get; set; }
        public List<ProductModel> ProductList { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            authState = await _authState;
            ProductList = _db.GetProducts(authState.User.Claims.ToList()[0].Value);
        }

        async Task AddProduct()
        {
            await OpenDialog("Add a new product", "Ok");
            ProductList = _db.GetProducts(authState.User.Claims.ToList()[0].Value);
        }

        protected async Task<DialogResult> OpenDialog(string contentText, string buttonText = "Delete")
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", contentText);
            parameters.Add("ButtonText", buttonText);
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService.Show<ProductDialog>(contentText, parameters, options);
            return await dialog.Result;
        }
    }
}
