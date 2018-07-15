using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.LoginRegister.Logic {
    public class LoginLogic : BlazorComponent {
        protected User user = new User();

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected async void LoginAction() {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password)) {
                //Http.SendJsonAsync(HttpMethod.Post, "/api/User/Login", user);
                var checkLogin = await Http.SendJsonAsync<bool>(HttpMethod.Post, "api/User/Login", user);
                UriHelper.NavigateTo(checkLogin ? "/loginSuccess" : "/loginFail");
            }
        }
    }
}
