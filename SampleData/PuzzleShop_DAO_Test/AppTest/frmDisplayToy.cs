using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PuzzleShop.Shared.Models.Toy;

namespace AppTest
{
    public partial class frmDisplayToy : Form
    {
        public frmDisplayToy()
        {
            InitializeComponent();
            LoadData();
            OrderCart = new Dictionary<Toy, int>();
        }

        public static Toy SelectedToy { get; set; }

        public static Dictionary<Toy, int> OrderCart { get; set; }

        public void LoadData()
        {
            var toyDao = new ToyDAO();
            var list = toyDao.AllToys();
            tblToy.DataSource = list;
            var LoggedUser = frmLogin.AuthorizedUser;
            var welcome = $"Welcome {LoggedUser.FirstName} {LoggedUser.LastName}";
            lbWelcome.Text = welcome;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchValue = txtSearch.Text;
            var toyDAO = new ToyDAO();

            var list = toyDAO.FindByName(searchValue);

            tblToy.DataSource = list;
        }

        /// <summary>
        ///  TODO Adapt this with the new method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
//        private void btnToyType_Click(object sender, EventArgs e)
//        {
//            var toyDao = new ToyDAO();
//            List<string> listType = toyDao.GetCategoriesAndQuantities();
//
//            var Type = new Dictionary<string, long>();
//            foreach (var s in listType)
//            {
//                long quantity = toyDao.GetQuantityOfAType(s);
//                Type.Add(s, quantity);
//                MessageBox.Show(s + ": " + quantity);
//            }
//        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var info = new frmAccountInfo();
            info.ShowDialog();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            SelectedToy = (Toy) tblToy.CurrentRow.DataBoundItem;

            var review = new frmAddReview();
            review.ShowDialog();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (!OrderCart.TryGetValue((Toy) tblToy.CurrentRow.DataBoundItem, out var value))
                OrderCart.Add((Toy) tblToy.CurrentRow.DataBoundItem, 1);
            else
                OrderCart[(Toy) tblToy.CurrentRow.DataBoundItem] += 1;
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            var view = new frmViewOrder();
            view.ShowDialog();
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            var history = new frmOrderHistory();
            history.ShowDialog();
        }
    }
}
