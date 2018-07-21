using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PuzzleShop.Client.Pages.ToyDetail.Logic {
    public class ToyDetailLogic : BlazorComponent {

        [Parameter]
        protected string ToyId { get; set; }

        [Parameter]
        protected List<Toy> ToyList { get; set; }

        protected Toy CurrentToy { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        protected override void OnParametersSet() {
            if (string.IsNullOrEmpty(ToyId)) {
                return;
            }
            CurrentToy = ToyList.SingleOrDefault(toy => toy._id.Equals(ToyId));
            CurrentToy.Quantity = 1;
            //StateHasChanged();
        }

        protected override void OnAfterRender() {
            if (CurrentToy != null) {
                // generate large image url
                var splittedUrl = CurrentToy.PhotoURL.Split('/', '\\');
                var imageName = "large-" + splittedUrl.Last();
                var largeImageUrl = "";
                for (int i = 0; i < splittedUrl.Length - 1; ++i) {
                    largeImageUrl += splittedUrl[i] + "/";
                }

                largeImageUrl += imageName;
                //RegisteredFunction.Invoke<bool>("ZoomImage", "#toy-img-zoom", largeImageUrl);
                RegisteredFunction.Invoke<bool>("ZoomImage", "#toy-img-zoom");
            }
        }

        protected void ChangeValue(string inputId, int offsetValue) {
            if (CurrentToy.Quantity + offsetValue <= 0) {
                return;
            }
            CurrentToy.Quantity += offsetValue;
        }

        protected async Task<string> AddToCart() {
            await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/Cart/AddToCart", CurrentToy);
            return "return false";
        }
    }
}
