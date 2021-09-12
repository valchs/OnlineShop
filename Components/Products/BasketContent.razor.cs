using Microsoft.AspNetCore.Components;
using OnlineShop.BusinessLogic;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components.Products
{
    public partial class BasketContent : ShopBase
    {
        [Parameter] public List<ProductModel> ProductList { get; set; }
    }
}
