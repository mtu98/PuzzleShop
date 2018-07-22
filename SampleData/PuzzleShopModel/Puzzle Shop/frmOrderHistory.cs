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
    public partial class frmOrderHistory : Form
    {
        public frmOrderHistory()
        {
            InitializeComponent();

            loadData();
        }


        public void loadData()
        {
            OrdersDAO dao = new OrdersDAO();

            List<Dictionary<Toy, int>> list = new List<Dictionary<Toy, int>>();

            try
            {
                list = dao.GetAllOrders(frmLogin.AuthorizedUser.Username);
            }
            catch (Exception)
            {

                throw;
            }

            tblOrderHistory.DataSource = list;
        }
    }
}
