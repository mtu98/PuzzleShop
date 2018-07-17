using Microsoft.AspNetCore.Blazor.Components;
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

        protected override void OnInit() {
            GetLoginUser();

        }

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
    }
}
