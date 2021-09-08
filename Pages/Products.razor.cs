using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Pages
{
    public partial class Products : ComponentBase
    {
        [Inject] public ProductData _db { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> _authState { get; set; }
        public List<ProductModel> ProductList { get; set; } = new();
        private AuthenticationState authState;

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
    }
}
