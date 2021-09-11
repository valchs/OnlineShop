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
            await OpenDialog<ProductDialog>("Add a new product", "Ok");
            ProductList = _db.GetProducts(authState.User.Claims.ToList()[0].Value);
        }
    }
}
