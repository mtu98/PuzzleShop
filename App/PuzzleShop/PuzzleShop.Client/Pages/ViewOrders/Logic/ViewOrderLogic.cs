using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using PuzzleShop.Shared.Models.Order;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace PuzzleShop.Client.Pages.ViewOrders.Logic {
    public class ViewOrderLogic : BlazorComponent {

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        protected List<Orders> OrderList { get; set; }

        protected override void OnInit() {
            GetOrders();
        }

        protected async void GetOrders() {
            StartProcessing();
            var username = await Http.GetStringAsync("api/User/GetLoginUser");
            OrderList = await Http.PostJsonAsync<List<Orders>>("api/Order/GetOrder", username);
            EndProcessing();
            ShowAll = "show";
            StateHasChanged();
        }

        protected string Processing = "hide";

        private void StartProcessing() {
            Processing = "show";
        }

        private void EndProcessing() {
            Processing = "hide";
        }

        protected string ParseOrderStatus(int status) {
            switch (status) {
                case -1: return "Pending";
                case 0: return "Processing";
                case 1: return "Complete";
            }

            return "";
        }

        protected string ShowAll { get; set; } = "show";

        protected Orders SelectedOrder { get; set; }

        protected int IndexSelectedOrder { get; set; }

        protected string SelectOrder(Orders order) {
            Debug.WriteLine("==> order date " + order.OrderDate);
            IndexSelectedOrder = OrderList.IndexOf(order) + 1;
            SelectedOrder = order;
            ShowAll = "hide";
            StateHasChanged();
            return "return false";
        }

        protected void BackToOrderHistory() {
            ShowAll = "show";
            StateHasChanged();
        }
    }
}


