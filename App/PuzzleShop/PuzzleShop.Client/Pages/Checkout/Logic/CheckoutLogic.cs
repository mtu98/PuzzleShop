using Microsoft.AspNetCore.Blazor;
using PuzzleShop.Client.Pages.ViewCart.Logic;

namespace PuzzleShop.Client.Pages.Checkout.Logic {
    public class CheckoutLogic : ViewCartLogic {
        protected async void CheckoutOrder() {
            var username = await Http.GetStringAsync("api/User/GetLoginUser");
            if (username == null) {
                UriHelper.NavigateTo("/login");
            } else {
                var result = await Http.PostJsonAsync<bool>("", null);
                UriHelper.NavigateTo(result ? "/checkoutSuccess" : "/checkoutFail");
            }
        }
    }
}
