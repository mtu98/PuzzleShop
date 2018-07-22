using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.AllProducts.Logic {
    public class ProductsByCategoryLogic : BlazorComponent {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        protected string CategoryName { get; set; }

        protected List<Toy> ToyList { get; set; }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        protected override void OnParametersSet() {
            GetAllToysOfCategory();
        }

        private async void GetAllToysOfCategory() {
            StartProcessing();
            ToyList = await Http.PostJsonAsync<List<Toy>>("api/Toy/GetAllToysOfCategory", CategoryName);
            EndProcessing();
            StateHasChanged();
        }
    }
}
