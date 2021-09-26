using Microsoft.AspNetCore.Components;
using OnlineShop.Models;
using OnlineShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
	public class AppState
	{
		public List<ProductModel> Products { get; private set; } = new();
		public List<ItemModel> Items { get; private set; } = new List<ItemModel>()
		{
			new ItemModel
			{
				Id = 26,
				Title = "Iphone 12 PRO MAX"
			},
			new ItemModel
			{
				Id = 27,
				Title = "Speaker"
			},
			new ItemModel
            {
				Id = 28,
				Title = "MacBook PRO 2020"
			},
			new ItemModel
            {
				Id = 29,
				Title = "Model O Mouse"
			}
		};

		public void UpdateProducts(ComponentBase source, List<ProductModel> products)
		{
			Products = products;
			NotifyStateChanged(source, "Products");
		}

		public event Action<ComponentBase, string> StateChanged;
		private void NotifyStateChanged(ComponentBase source, string property) => StateChanged?.Invoke(source, property);
	}
}
