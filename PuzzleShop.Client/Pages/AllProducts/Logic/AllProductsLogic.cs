using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;

namespace PuzzleShop.Client.Pages.AllProducts.Logic
{
    public class AllProductsLogic : BlazorComponent
    {
        private const string GetToysApi = "api/toys";

        protected string Processing = "hide";

        [Inject] private HttpClient Http { get; set; }

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
            GetAllToys();
        }

        private async void GetAllToys()
        {
            StartProcessing();
            ToyList = await Http.GetJsonAsync<List<Toy>>(GetToysApi);
            EndProcessing();
            StateHasChanged();
        }
    }
}