using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
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

        protected string IsDisplay { get; set; } = "show";

        protected string SelectedToyId { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        //protected override void OnInit() {
        //    SearchToy();
        //}

        protected override void OnParametersSet() {
            SearchToy();
        }

        protected async void SearchToy() {
            try {
                IsDisplay = "show";
                StartProcessing();
                ToyList = await Http.SendJsonAsync<List<Toy>>(HttpMethod.Post, "api/Toy/Search", SearchValue);
                EndProcessing();
                StateHasChanged();
            } catch (Exception ex) {
                Debug.WriteLine("SearchLogic Exception: " + ex.Message);
            }
        }

        protected string ViewToyDetail(string toyId) {
            //UriHelper.NavigateTo("/toyDetail/" + toyId);
            SelectedToyId = toyId;
            IsDisplay = "hide";
            StateHasChanged();
            return "return false";
        }

        protected void BackToSearchResult() {
            IsDisplay = "show";
        }
    }
}
