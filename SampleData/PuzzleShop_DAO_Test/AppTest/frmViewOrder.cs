using System;
using System.Linq;
using System.Windows.Forms;
using PuzzleShop.Shared.Models.Order;

namespace AppTest
{
    public partial class frmViewOrder : Form
    {
        public frmViewOrder()
        {
            InitializeComponent();

            loadData();
        }


        public void loadData()
        {
            var OrderCart = frmDisplayToy.OrderCart;

            var list = OrderCart.ToArray();

            tblOrderCart.DataSource = list;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var OrderCart = frmDisplayToy.OrderCart;

            var dao = new OrdersDAO();

            var result = dao.CreateOrder(frmLogin.AuthorizedUser.Username, OrderCart);

            if (result)
            {
                MessageBox.Show("Order Complete!");
                Close();
            }
        }
    }
}