using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.LoginRegister.Logic {
    public class LoginRegisterLogic : BlazorComponent {
        protected User loginUser = new User();
        protected User registerUser = new User();

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected bool ActiveValidate { get; set; }

        protected override void OnInit() {
            ActiveValidate = false;
        }

        protected string processing = "hide";

        protected async void LoginAction() {
            if (!string.IsNullOrEmpty(loginUser.Username) && !string.IsNullOrEmpty(loginUser.Password)) {
                //Http.SendJsonAsync(HttpMethod.Post, "/api/User/Login", loginUser);
                processing = "show";
                User user = null;
                try {
                    user = await Http.SendJsonAsync<User>(HttpMethod.Post, "api/User/Login", loginUser);
                } catch (Exception ex) {
                    Debug.WriteLine("Exception: " + ex.Message);
                }


                UriHelper.NavigateTo(user != null ? "/" : "/loginFail");
                RegisteredFunction.Invoke<bool>("ReloadPage");
                processing = "hide";
            }
        }

        protected async void RegisterAction() {
            processing = "show";

            ActiveValidate = true;
            registerUser.Validate();
            if (!registerUser.HasErrors) {
                var registerSuccess =
                    await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/User/Register", registerUser);
                if (registerSuccess) {
                    UriHelper.NavigateTo("/registerSuccess");
                } else {
                    registerUser.DuplicateUsername = true;
                    registerUser.Validate();
                }
            }
            processing = "hide";

        }
    }
}
