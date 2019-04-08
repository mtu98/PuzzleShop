using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
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

        protected bool AddSuccess { get; set; } = false;

        protected string[] RatingLevel = new[] {
            "☆☆☆☆☆",
            "★☆☆☆☆",
            "★★☆☆☆",
            "★★★☆☆",
            "★★★★☆",
            "★★★★★"
        };

        protected Review ToyReview { get; set; } = new Review();

        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }

        protected override void OnParametersSet() {
            if (string.IsNullOrEmpty(ToyId)) {
                return;
            }
            CurrentToy = ToyList.SingleOrDefault(toy => toy._id.Equals(ToyId));
            if (CurrentToy != null) {
                CurrentToy.Quantity = 1;
                if (CurrentToy.Review == null) {
                    CurrentToy.Review = new Review[0];
                }
            }
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
                JSRuntime.Current.InvokeAsync<bool>("zoomImage", "#toy-img-zoom");
                JSRuntime.Current.InvokeAsync<bool>("activateStarRating");
            }
        }

        protected void ChangeValue(int offsetValue) {
            if (CurrentToy.Quantity + offsetValue <= 0) {
                return;
            }
            CurrentToy.Quantity += offsetValue;
        }

        protected string AddingItemDisplay { get; set; } = "none";

        protected async Task<string> AddToCart() {
            AddingItemDisplay = "inline-block";
            await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/Cart/AddToCart", CurrentToy);
            AddingItemDisplay = "none";
            AddSuccess = true;
            return "return false";
        }

        protected int GetAverageRatingLevel() {
            if (CurrentToy?.Review == null || CurrentToy.Review.Length == 0) {
                return 0;
            }

            var totalRating = 0;
            foreach (var review in CurrentToy.Review) {
                totalRating += review.Star;
            }

            return totalRating / CurrentToy.Review.Length;
        }

        protected async void WriteReview() {
            //ToyReview.Date = DateTime.Now.ToString("F"); // Tuesday, 22 August 2006 06:30:07
            var simpleToyReview = new SimpleToyReview(CurrentToy, ToyReview);
            await Http.SendJsonAsync(HttpMethod.Post, "api/Toy/WriteReview", simpleToyReview);
        }

        protected void AlertMsg(string msg) {
            JSRuntime.Current.InvokeAsync<bool>("alertMsg", msg);
        }

        protected void SetStarReview(int star) {
            ToyReview.Star = star;
        }
    }
}
