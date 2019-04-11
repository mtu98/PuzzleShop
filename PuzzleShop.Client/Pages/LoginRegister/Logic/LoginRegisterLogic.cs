using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Diagnostics;
using System.Net.Http;
using PuzzleShop.Shared.Models.User;

namespace PuzzleShop.Client.Pages.LoginRegister.Logic {
    public class LoginRegisterLogic : BlazorComponent {
        protected User LoginUser = new User();
        protected User RegisterUser = new User();

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected bool ActiveValidate { get; set; }

        protected override void OnInit() {
            ActiveValidate = false;
        }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        protected async void LoginAction() {
            if (!string.IsNullOrEmpty(LoginUser.Username) && !string.IsNullOrEmpty(LoginUser.Password)) {
                //Http.SendJsonAsync(HttpMethod.Post, "/api/User/Login", loginUser);
                StartProcessing();
                User user = null;
                try {
                    user = await Http.SendJsonAsync<User>(HttpMethod.Post, "api/User/Login", LoginUser);
                } catch (Exception ex) {
                    Debug.WriteLine("Exception: " + ex.Message);
                }


                UriHelper.NavigateTo(user != null ? "/" : "/loginFail");
                await JSRuntime.Current.InvokeAsync<bool>("autoReloadPage");
                EndProcessing();
            }
        }

        protected async void RegisterAction() {
            Processing = "show";

            ActiveValidate = true;
            RegisterUser.Validate();
            if (!RegisterUser.HasErrors) {
                var registerSuccess =
                    await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/User/Register", RegisterUser);
                if (registerSuccess) {
                    UriHelper.NavigateTo("/registerSuccess");
                } else {
                    RegisterUser.DuplicateUsername = true;
                    RegisterUser.Validate();
                }
            }
            Processing = "hide";

        }
    }
}
