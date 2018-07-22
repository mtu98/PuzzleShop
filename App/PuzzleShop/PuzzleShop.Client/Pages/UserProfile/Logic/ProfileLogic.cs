using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.UserProfile.Logic {
    public class ProfileLogic : BlazorComponent {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        protected User LoginUser { get; set; }


        protected override void OnInit() {
            GetLoginUser();
        }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        protected async void GetLoginUser() {
            string username = null;
            StartProcessing();
            try {
                username = await Http.GetStringAsync("api/User/GetLoginUser");
            } catch (Exception ex) {
                Debug.WriteLine("Exception: " + ex.Message);
            }


            if (!string.IsNullOrEmpty(username)) {
                LoginUser = await Http.GetJsonAsync<User>("api/User/GetLoginUserObject");
            }

            EndProcessing();
            this.StateHasChanged();
        }


        protected string UpdateUserSuccess { get; set; } = "hide";

        protected async void UpdateUserProfile() {
            StartProcessing();
            var result = await Http.PostJsonAsync<bool>("api/User/UpdateProfile", LoginUser);
            if (result) {
                UpdateUserSuccess = "show";
            }
            EndProcessing();
            StateHasChanged();
        }

        protected string ChangePasswordSuccess { get; set; } = "hide";

        protected async void ChangePassword() {
            StartProcessing();

            if (!LoginUser.Password.Equals(LoginUser.ConfirmedPassword)) {
                RegisteredFunction.Invoke<bool>("AlertMsg", "Confirm password must match with password!");
            } else {
                var result = await Http.PostJsonAsync<bool>("api/User/ChangePassword", LoginUser);
                if (result) {
                    LoginUser.Password = "";
                    LoginUser.ConfirmedPassword = "";
                    ChangePasswordSuccess = "show";
                }
            }

            EndProcessing();
            StateHasChanged();
        }


    }
}
