using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PuzzleShop.Client.Shared.Logic
{
    public class ToyCategoryLogic : BlazorComponent
    {
        private const string GetCategoryApi = "api/toys/category";
        [Inject] private HttpClient Http { get; set; }

        [Inject] private IUriHelper UriHelper { get; set; }

        protected Dictionary<string, long> Categories { get; set; }

        protected override void OnInit()
        {
            GetCategories();
        }

        private async void GetCategories()
        {
            var jsonResponse = await Http.GetStringAsync(GetCategoryApi);
            if (jsonResponse != null)
            {
                // init dict
                Categories = new Dictionary<string, long>();
                // deserialize and add to dict
                JsonConvert.DeserializeObject<List<JObject>>(jsonResponse)
                    .ForEach(ele => Categories.Add(ele.Properties().First().Name, long.Parse(ele.Properties().First().Value.ToString())));
            }
            StateHasChanged();
        }

        protected void FilterByCategory(string category)
        {
            UriHelper.NavigateTo($"/shop/{category}");
        }
    }
}