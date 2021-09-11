using Microsoft.AspNetCore.Components;
using OnlineShop.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class ProductDetails : ShopBase
    {
        [Parameter] public string Id { get; set; }
    }
}
