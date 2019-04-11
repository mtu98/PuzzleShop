using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.AllProducts.Logic {
    public class AllProductsLogic : BlazorComponent {
        [Inject]
        private HttpClient Http { get; set; }

        protected List<Toy> ToyList { get; set; }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        protected override void OnInit() {
            GetAllToys();
        }

        private async void GetAllToys() {
            StartProcessing();
            ToyList = await Http.GetJsonAsync<List<Toy>>("api/toys");
            EndProcessing();
            StateHasChanged();
        }
    }
}
