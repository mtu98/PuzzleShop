using Microsoft.AspNetCore.Blazor.Components;

namespace PuzzleShop.Client.Pages.ToyDetail.Logic {
    public class ToyDetailLogic : BlazorComponent {

        [Parameter]
        protected string ToyId { get; set; }
    }
}
