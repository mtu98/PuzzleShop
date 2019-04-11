using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.Home.Logic {
    public class NewProductsLogic : BlazorComponent {
        [Inject]
        private HttpClient Http { get; set; }

        protected List<Toy> ToyList { get; set; }

        protected override void OnInit() {
            GetFeatureToys();
        }

        private async void GetFeatureToys() {
            ToyList = await Http.GetJsonAsync<List<Toy>>("api/Toy/GetNewToys");
            StateHasChanged();
        }

        protected override void OnAfterRender() {
            //RegisteredFunction.Invoke<bool>("ActiveOwlCarousel");
        }
    }
}
