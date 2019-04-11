using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.Cart;
using PuzzleShop.Shared.Models.Toy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PuzzleShop.Client.Shared.Logic
{
    public class NavigationMenuLogic : BlazorComponent
    {
        private readonly string _getTypeApiPath = "api/toys/type";

        [Parameter] protected User LoginUser { get; set; }

        [Inject] private HttpClient Http { get; set; }

        [Inject] private IUriHelper UriHelper { get; set; }

        protected override void OnInit()
        {
            GetLoginUser();
            GetCategory();
        }

        private async void GetCategory()
        {
            var jsonResponse = await Http.GetStringAsync(_getTypeApiPath);
            CategoryList = JsonConvert.DeserializeObject<List<JObject>>(jsonResponse).Properties().Select(j => j.Name).ToList();
            StateHasChanged();
        }

        protected List<string> CategoryList { get; set; }

        protected string SearchValue { get; set; }

        protected Cart Cart { get; set; }

        protected async void GetLoginUser()
        {
            string username = null;
            try
            {
                username = await Http.GetStringAsync("api/User/GetLoginUser");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }


            if (!string.IsNullOrEmpty(username))
            {
                LoginUser = new User
                {
                    Username = username
                };
            }

            StateHasChanged();
        }

        protected string Search()
        {
            if (!string.IsNullOrEmpty(SearchValue))
            {
                UriHelper.NavigateTo("/search/" + SearchValue);
            }

            return "return false"; // prevent the form to be submitted
        }

        protected double GetPriceOfCart()
        {
            if (Cart == null)
            {
                return 0;
            }

            double price = 0;
            foreach (var item in Cart)
            {
                price += item.Key.Price * item.Value;
            }

            return price;
        }

        protected int GetTotalItemQuantityInCart()
        {
            if (Cart == null)
            {
                return 0;
            }

            int quantity = 0;
            foreach (var item in Cart)
            {
                quantity += item.Value;
            }

            return quantity;
        }

        protected async void GetCart()
        {
            var cartJson = await Http.GetStringAsync("api/Cart/GetCart");
            if (string.IsNullOrEmpty(cartJson))
            {
                Cart = null;
                StateHasChanged();
                return;
            }

            try
            {
                var toyList = JsonConvert.DeserializeObject<List<KeyValuePair<Toy, int>>>(cartJson);
                if (toyList != null)
                {
                    Cart = new Cart(toyList.ToDictionary(item => item.Key, item => item.Value));
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("NavigationMenuLogic GetCart " + ex.Message);
                throw;
            }
        }

        protected string ViewCart()
        {
            UriHelper.NavigateTo("/viewCart");
            return "return false";
        }

        protected string Processing = "hide";

        private void StartProcessing()
        {
            Processing = "show";
        }

        private void EndProcessing()
        {
            Processing = "hide";
        }

        protected async Task<string> RemoveItem(string toyId)
        {
            StartProcessing();
            await Http.PostJsonAsync<bool>("api/Cart/RemoveItem", toyId);
            GetCart();
            EndProcessing();
            StateHasChanged();
            return "return false";
        }
    }
}