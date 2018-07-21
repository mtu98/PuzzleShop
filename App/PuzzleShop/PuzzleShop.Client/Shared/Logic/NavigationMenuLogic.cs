using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace PuzzleShop.Client.Shared.Logic {
    public class NavigationMenuLogic : BlazorComponent {
        [Parameter]
        protected User LoginUser { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        protected override void OnInit() {
            GetLoginUser();

        }

        protected string SearchValue { get; set; }

        protected async void GetLoginUser() {
            string username = null;
            try {
                username = await Http.GetStringAsync("api/User/GetLoginUser");
            } catch (Exception ex) {
                Debug.WriteLine("Exception: " + ex.Message);
            }


            if (!string.IsNullOrEmpty(username)) {
                LoginUser = new User {
                    Username = username
                };
            }

            this.StateHasChanged();
        }

        protected string Search() {
            if (!string.IsNullOrEmpty(SearchValue)) {
                UriHelper.NavigateTo("/search/" + SearchValue);
            }
            return "return false"; // prevent the form to be submitted
        }
    }
}
