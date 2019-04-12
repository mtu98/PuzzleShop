using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.JSInterop;
using PuzzleShop.Shared.Models.User;

namespace PuzzleShop.Client.Pages.UserProfile.Logic
{
    public class ProfileLogic : BlazorComponent
    {
        protected string Processing = "hide";
        [Inject] private HttpClient Http { get; set; }

        [Inject] private IUriHelper UriHelper { get; set; }

        protected User LoginUser { get; set; }


        protected string UpdateUserSuccess { get; set; } = "hide";

        protected string ChangePasswordSuccess { get; set; } = "hide";


        protected override void OnInit()
        {
            GetLoginUser();
        }

        private void StartProcessing()
        {
            Processing = "show";
        }

        private void EndProcessing()
        {
            Processing = "hide";
        }

        private async void GetLoginUser()
        {
            string username = null;
            StartProcessing();
            try
            {
                username = await Http.GetStringAsync("api/User/GetLoginUser");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }


            if (!string.IsNullOrEmpty(username))
                LoginUser = await Http.GetJsonAsync<User>("api/User/GetLoginUserObject");

            EndProcessing();
            StateHasChanged();
        }

        protected async void UpdateUserProfile()
        {
            StartProcessing();
            var result = await Http.PostJsonAsync<bool>("api/User/UpdateProfile", LoginUser);
            if (result) UpdateUserSuccess = "show";
            EndProcessing();
            StateHasChanged();
        }

        protected async void ChangePassword()
        {
            StartProcessing();

            if (!LoginUser.Password.Equals(LoginUser.ConfirmedPassword))
            {
                await JSRuntime.Current.InvokeAsync<bool>("alertMsg", "Confirm password must match with password!");
            }
            else
            {
                var result = await Http.PostJsonAsync<bool>("api/User/ChangePassword", LoginUser);
                if (result)
                {
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