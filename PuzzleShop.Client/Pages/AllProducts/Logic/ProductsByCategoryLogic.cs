using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;

namespace PuzzleShop.Client.Pages.AllProducts.Logic
{
    public class ProductsByCategoryLogic : BlazorComponent
    {
        protected string Processing = "hide";

        [Inject] private HttpClient Http { get; set; }

        [Parameter] protected string Category { get; set; }

        protected List<Toy> ToyList { get; set; }

        private void StartProcessing()
        {
            Processing = "show";
        }

        private void EndProcessing()
        {
            Processing = "hide";
        }

        protected override void OnInit()
        {
            GetAllToysOfCategory();
        }

        protected override void OnParametersSet()
        {
            GetAllToysOfCategory();
        }

        private async void GetAllToysOfCategory()
        {
            // request
            StartProcessing();
            ToyList = await Http.GetJsonAsync<List<Toy>>($"api/toys/category/{Category}");
            // complete request
            EndProcessing();
            StateHasChanged();
        }
    }
}