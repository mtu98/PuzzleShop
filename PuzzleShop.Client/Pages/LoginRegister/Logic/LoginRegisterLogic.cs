using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.JSInterop;
using PuzzleShop.Shared.Models.User;

namespace PuzzleShop.Client.Pages.LoginRegister.Logic
{
    public class LoginRegisterLogic : BlazorComponent
    {
        protected readonly User LoginUser = new User();
        protected readonly User RegisterUser = new User();

        protected string Processing = "hide";

        [Inject] private IUriHelper UriHelper { get; set; }

        [Inject] private HttpClient Http { get; set; }

        protected bool ActiveValidate { get; set; }

        protected override void OnInit()
        {
            ActiveValidate = false;
        }

        private void StartProcessing()
        {
            Processing = "show";
        }

        private void EndProcessing()
        {
            Processing = "hide";
        }

        protected async void LoginAction()
        {
            if (!string.IsNullOrEmpty(LoginUser.Username) && !string.IsNullOrEmpty(LoginUser.Password))
            {
                //Http.SendJsonAsync(HttpMethod.Post, "/api/User/Login", loginUser);
                StartProcessing();
                User user = null;
                try
                {
                    user = await Http.SendJsonAsync<User>(HttpMethod.Post, "api/User/Login", LoginUser);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }


                UriHelper.NavigateTo(user != null ? "/" : "/loginFail");
                await JSRuntime.Current.InvokeAsync<bool>("autoReloadPage");
                EndProcessing();
            }
        }

        protected async void RegisterAction()
        {
            StartProcessing();
            ActiveValidate = true;
            RegisterUser.Validate();
            if (!RegisterUser.HasErrors)
            {
                var registerSuccess =
                    await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/User/Register", RegisterUser);
                if (registerSuccess)
                {
                    UriHelper.NavigateTo("/registerSuccess");
                }
                else
                {
                    RegisterUser.DuplicateUsername = true;
                    RegisterUser.Validate();
                }
            }
            EndProcessing();
        }
    }
}