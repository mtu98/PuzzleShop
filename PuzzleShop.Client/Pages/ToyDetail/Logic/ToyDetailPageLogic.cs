using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models.Toy;

namespace PuzzleShop.Client.Pages.ToyDetail.Logic
{
    public class ToyDetailPageLogic : BlazorComponent
    {
        protected string Processing = "hide";

        [Inject] private IUriHelper UriHelper { get; set; }

        [Inject] private HttpClient Http { get; set; }

        [Parameter] protected string ToyId { get; set; }

        protected Toy CurrentToy { get; set; }

        private void StartProcessing()
        {
            Processing = "show";
        }

        private void EndProcessing()
        {
            Processing = "hide";
        }

        protected override void OnParametersSet()
        {
            GetCurrentToy();
        }

        private async void GetCurrentToy()
        {
            StartProcessing();
            CurrentToy = await Http.GetJsonAsync<Toy>($"api/toy/{ToyId}");
            EndProcessing();
            StateHasChanged();
        }

        protected List<Toy> GenerateToyList()
        {
            var list = new List<Toy> {CurrentToy};
            return list;
        }
    }
}