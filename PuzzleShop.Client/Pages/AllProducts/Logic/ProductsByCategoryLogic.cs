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
        protected string Category { get; set; }

        protected List<Toy> ToyList { get; set; }

        protected string Processing = "hide";

        protected override void OnParametersSet() {
            GetAllToysOfCategory();
        }

        private async void GetAllToysOfCategory() {
            // request
            Processing = "show";
            ToyList = await Http.GetJsonAsync<List<Toy>>($"api/toys/category/{Category}");
            // complete request
            Processing = "hide";
            StateHasChanged();
        }
    }
}
