using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Newtonsoft.Json;
using PuzzleShop.Shared.Models.Cart;
using PuzzleShop.Shared.Models.Toy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.ViewCart.Logic {
    public class ViewCartLogic : BlazorComponent {

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        protected Cart Cart { get; set; }

        protected override void OnInit() {
            GetCart();
        }

        protected async void GetCart() {
            var cartJson = await Http.GetStringAsync("api/Cart/GetCart");
            if (string.IsNullOrEmpty(cartJson)) {
                return;
            }

            try {
                var toyList = JsonConvert.DeserializeObject<List<KeyValuePair<Toy, int>>>(cartJson);
                if (toyList != null) {
                    Cart = new Cart(toyList.ToDictionary(item => item.Key, item => item.Value));
                    StateHasChanged();

                }
            } catch (Exception ex) {
                Debug.WriteLine("ViewCartLogic GetCart " + ex.Message);
                throw;
            }
        }

        protected string ChangeValue(Toy toy, int offset) {
            if (Cart[toy] + offset > 0) {
                Cart[toy] = Cart[toy] + offset;
            }

            return "return null";
        }
    }
}
