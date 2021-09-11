using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLogic.Components
{
    public class ModalComponent : ShopBase
    {
		[CascadingParameter] public MudDialogInstance MudDialog { get; set; }

		public void Done()
		{
			MudDialog.Close(DialogResult.Ok(true));
			ShowSnackbar("Saved", Defaults.Classes.Position.BottomCenter);
		}

		public void Cancel() => MudDialog.Cancel();
	}
}
