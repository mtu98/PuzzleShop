using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.Search.Logic {
    public class SearchLogic : BlazorComponent {
        [Parameter]
        protected string SearchValue { get; set; }

        protected List<Toy> ToyList { get; set; } = new List<Toy>();

        [Inject]
        public HttpClient Http { get; set; }

        protected string processing = "hide";

        private void startProcessing() {
            processing = "show";
        }

        private void endProcessing() {
            processing = "hide";
        }

        protected override void OnInit() {
            SearchToy();
        }

        protected async void SearchToy() {
            try {
                startProcessing();
                ToyList = await Http.SendJsonAsync<List<Toy>>(HttpMethod.Post, "api/Toy/Search", SearchValue);
                endProcessing();
                StateHasChanged();
            } catch (Exception ex) {
                Debug.WriteLine("SearchLogic Exception: " + ex.Message);
            }
        }
    }
}
