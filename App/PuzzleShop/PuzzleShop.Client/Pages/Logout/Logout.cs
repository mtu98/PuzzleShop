using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.Logout {
    [RouteAttribute("/logout")]
    public class Logout : BlazorComponent {
        [Inject]
        private IUriHelper UriHelper { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        protected override void OnInit() {
            LogoutAction();
        }

        private async void LogoutAction() {
            await Http.DeleteAsync("api/User/Logout");
            UriHelper.NavigateTo("/");
        }
    }
}
