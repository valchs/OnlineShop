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
            ProductList = _db.GetProducts();
        }

        void ShowDetails(ProductModel model)
        {
            NavigationManager.NavigateTo("/productDetails/" + model.Id, forceLoad: true);
        }
    }
}
