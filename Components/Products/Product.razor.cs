using Microsoft.AspNetCore.Components;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components.Products
{
    public partial class Product : ComponentBase
    {
        [Parameter] public ProductModel ProductModel { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
