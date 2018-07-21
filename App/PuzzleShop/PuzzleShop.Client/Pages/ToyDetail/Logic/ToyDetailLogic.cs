using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleShop.Client.Pages.ToyDetail.Logic {
    public class ToyDetailLogic : BlazorComponent {

        [Parameter]
        protected string ToyId { get; set; }

        [Parameter]
        protected List<Toy> ToyList { get; set; }

        protected Toy CurrentToy { get; set; }

        protected override void OnParametersSet() {
            if (string.IsNullOrEmpty(ToyId)) {
                return;
            }
            CurrentToy = ToyList.SingleOrDefault(toy => toy._id.Equals(ToyId));
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
    }
}
