using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models.Toy;

namespace AppTest
{
    public partial class frmAddReview : Form
    {
        public frmAddReview()
        {
            InitializeComponent();
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var title = txtTitle.Text;
            var content = txtContent.Text;
            var rate = int.Parse(txtRate.Text);
            var reviewToy = frmDisplayToy.SelectedToy;

            var dao = new ToyDAO();
            dao.ReviewAToy(reviewToy._id, name, email, title, content, rate);

            MessageBox.Show("Thanks!");
            Close();
        }
    }
}