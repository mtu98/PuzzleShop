using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.ToyDetail.Logic {
    public class ToyDetailPageLogic : BlazorComponent {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Parameter]
        protected string ToyId { get; set; }
    }
}
