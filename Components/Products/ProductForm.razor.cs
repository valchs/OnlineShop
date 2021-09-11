using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using OnlineShop.BusinessLogic;
using OnlineShopLibrary.DataAccess;
using OnlineShopLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components.Products
{
    public partial class ProductForm : ShopBase
    {
        [Inject] public ProductData _db { get; set; }
        [Parameter] public EventCallback<string> OnSubmit { get; set; }
        ProductModel model = new();
        private List<string> CboPaths { get; set; } = new();

        protected override void OnInitialized()
        {
            CboPaths.Add("Assets/computer.png");
            CboPaths.Add("Assets/camera.jpg");
            CboPaths.Add("Assets/iphone.jpg");
        }

        private async Task OnValidSubmit(EditContext context)
        {
            var order = (ProductModel)context.Model;
            authState = await _authState;
            order.UserId = authState.User.Claims.ToList()[0].Value;
            var productId = _db.SaveProduct(order);
            await OnSubmit.InvokeAsync("Product submitted");
            ShowSnackbar($"Product {productId} added", Defaults.Classes.Position.BottomCenter);
        }
    }
}
