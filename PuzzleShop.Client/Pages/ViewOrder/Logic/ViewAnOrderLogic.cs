using System.Diagnostics;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Order;

namespace PuzzleShop.Client.Pages.ViewOrder.Logic
{
    public class ViewAnOrderLogic : BlazorComponent
    {
        [Parameter] protected Orders Order { get; set; }

        [Parameter] protected int OrderNumber { get; set; }

        protected override void OnParametersSet()
        {
            if (Order != null)
                Debug.WriteLine("==> parameter: order index: " + OrderNumber + ", order date: " + Order.OrderDate);
            StateHasChanged();
        }
    }
}