using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.ToyCollection;
using Library.OrdersCollection;

namespace Puzzle_Shop
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
            Dictionary<Toy, int> OrderCart = frmDisplayToy.OrderCart;

            var list = OrderCart.ToArray();

            tblOrderCart.DataSource = list;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Dictionary<Toy, int> OrderCart = frmDisplayToy.OrderCart;

            OrdersDAO dao = new OrdersDAO();

            try
            {
                bool result = dao.CreateOrder(frmLogin.AuthorizedUser.Username, OrderCart);

                if (result)
                {
                    MessageBox.Show("Order Complete!");
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
