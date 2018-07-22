using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Library.ToyCollection;
using Library.UserCollection;

namespace Puzzle_Shop
{
    public partial class frmDisplayToy : Form
    {

        public static Toy SelectedToy { get; set; }

        public static Dictionary<Toy,int> OrderCart { get; set; }

        

        public frmDisplayToy()
        {
            InitializeComponent();
            loadData();
            OrderCart = new Dictionary<Toy, int>();
        }

        public void loadData()
        {
            ToyDAO toyDao = new ToyDAO();
            List<Toy> list = toyDao.AllToys();
            tblToy.DataSource = list;
            User LoggedUser = frmLogin.AuthorizedUser;
            string welcome = $"Welcome {LoggedUser.FirstName} {LoggedUser.LastName}";
            lbWelcome.Text = welcome;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            ToyDAO toyDAO = new ToyDAO();

            List<Toy> list = toyDAO.FindToys(searchValue);

            tblToy.DataSource = list;
        }

        private void btnToyType_Click(object sender, EventArgs e)
        {
            ToyDAO toyDao = new ToyDAO();
            List<string> listType = toyDao.GetAllToyType();

            Dictionary<string, long> Type = new Dictionary<string, long>();
            foreach (string s in listType)
            {
                long quantity = toyDao.GetQuantityOfAType(s);
                Type.Add(s, quantity);
                MessageBox.Show(s + ": " + quantity);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmAccountInfo info = new frmAccountInfo();
            info.ShowDialog();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            SelectedToy = (Toy)tblToy.CurrentRow.DataBoundItem;

            frmAddReview review = new frmAddReview();
            review.ShowDialog();


        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if(!OrderCart.TryGetValue((Toy)tblToy.CurrentRow.DataBoundItem, out int value)){
                OrderCart.Add((Toy)tblToy.CurrentRow.DataBoundItem, 1);
            }
            else
            {
                OrderCart[(Toy)tblToy.CurrentRow.DataBoundItem] += 1;
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            frmViewOrder view = new frmViewOrder();
            view.ShowDialog();
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            frmOrderHistory history = new frmOrderHistory();
            history.ShowDialog();
        }
    }
}
