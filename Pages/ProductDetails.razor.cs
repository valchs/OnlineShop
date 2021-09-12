using Microsoft.AspNetCore.Components;
using OnlineShop.BusinessLogic;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class ProductDetails : ShopBase
    {
        [Inject] public ProductData _db { get; set; }
        [Parameter] public string Id { get; set; }
        public ProductModel Product { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = _db.GetProducts(id: Id)[0];
        }

        void ValueChanged(string ammount)
        {
            decimal? price = Product.Price ?? 0;
            decimal? sum = price * int.Parse(ammount);
            Product.Sum = sum > 0 ? sum : null;
        }
    }
}
