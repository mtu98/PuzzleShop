using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace PuzzleShop.Client.Shared.Logic {
    public class ToyCategoryLogic : BlazorComponent {
        private readonly string _getCategoryApiPath = "api/Toy/GetCategory";
        private readonly string _getCountItemOfCategory = "api/Toy/GetCountItemOfCategory";
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }

        protected Dictionary<string, long> Category { get; set; }

        protected override void OnInit() {
            GetCategory();
        }

        private async void GetCategory() {
            var toyCategory = await Http.GetJsonAsync<List<string>>(_getCategoryApiPath);
            if (toyCategory != null) {
                foreach (var item in toyCategory) {
                    var quantity = await Http.PostJsonAsync<long>(_getCountItemOfCategory, item);

                    if (Category == null) {
                        Category = new Dictionary<string, long>();
                    }

                    Category.Add(item, quantity);
                }
            }
            StateHasChanged();
        }

        protected void FilterByCategory(string category) {
            UriHelper.NavigateTo("/shop/" + category);
        }
    }
}
