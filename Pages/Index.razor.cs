using Microsoft.AspNetCore.Components;
using OnlineShop.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class Index : ShopBase
    {
        void ShowDetails(int id)
        {
            NavigationManager.NavigateTo("/productDetails/" + id);
        }
    }
}
