using Microsoft.AspNetCore.Components;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class Products : ComponentBase
    {
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
    }
}
