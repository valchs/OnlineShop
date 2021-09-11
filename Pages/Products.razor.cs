using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Components.Dialogs;
using OnlineShop.BusinessLogic;

namespace OnlineShop.Pages
{
    public partial class Products : ShopBase
    {
        [Inject] public ProductData _db { get; set; }
        public List<ProductModel> ProductList { get; set; } = new();


        protected override void OnInitialized()
        {
            for (int i = 1; i <= 3; i++)
            {
                var product = new ProductModel
                {
                    Title = $"Product {i}",
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit",
                    ImagePath = $"Assets/paint{i}.jpg"
                };
                ProductList.Add(product);
            }
        }

        async Task AddProduct()
        {
            authState = await _authState;
            var product = new ProductModel
            {
                Title = "Produkts",
                Description = "Apraksts",
                UserId = authState.User.Claims.ToList()[0].Value
            };
            var productId = _db.SaveProduct(product);
        }

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
