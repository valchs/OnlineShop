using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLogic
{
    public class ShopBase : ComponentBase
    {
		[Inject] public ISnackbar Snackbar { get; set; }
		[Inject] public IDialogService DialogService { get; set; }
		[Inject] public NavigationManager NavigationManager { get; set; }
		[CascadingParameter] public Task<AuthenticationState> _authState { get; set; }
		public AuthenticationState authState;

		public virtual void OpenDialog<T>() where T : ComponentBase
		{
			DialogService.Show<T>("Choose visible columns");
		}

		public void ShowSnackbar(string message, string position)
		{
			Snackbar.Clear();
			Snackbar.Configuration.PositionClass = position;
			Snackbar.Configuration.SnackbarVariant = Variant.Outlined;
			Snackbar.Configuration.HideTransitionDuration = 500;
			Snackbar.Configuration.ShowTransitionDuration = 500;
			Snackbar.Add(message, Severity.Success);
		}
	}
}
