using Microsoft.AspNetCore.Components;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
	public class AppState
	{
		public List<ProductModel> Products { get; private set; } = null;

		public void UpdateProducts(ComponentBase source, List<ProductModel> products)
		{
			Products = products;
			NotifyStateChanged(source, "Products");
		}

		public event Action<ComponentBase, string> StateChanged;
		private void NotifyStateChanged(ComponentBase source, string property) => StateChanged?.Invoke(source, property);
	}
}
