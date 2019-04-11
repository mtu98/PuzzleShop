using System.Collections.Generic;
using System.Windows.Forms;
using PuzzleShop.Shared.Models.Order;

namespace AppTest
{
    public partial class frmOrderHistory : Form
    {
        public frmOrderHistory()
        {
            InitializeComponent();

            loadData();
        }


        public void loadData()
        {
            var dao = new OrdersDAO();

            var list = new List<Orders>();

            list = dao.GetAllOrders(frmLogin.AuthorizedUser.Username);

            tblOrderHistory.DataSource = list;
        }
    }
}