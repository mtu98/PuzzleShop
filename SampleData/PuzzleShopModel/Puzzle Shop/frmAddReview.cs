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

namespace Puzzle_Shop
{
    public partial class frmAddReview : Form
    {
        public frmAddReview()
        {
            InitializeComponent();
        }

        private void btnRate_Click(object sender, EventArgs e)
        {

            string Name = txtName.Text;
            string Email = txtEmail.Text;
            string Title = txtTitle.Text;
            string Content = txtContent.Text;
            int Rate = int.Parse(txtRate.Text);
            Toy reviewToy = frmDisplayToy.SelectedToy;

            ToyDAO dao = new ToyDAO();
            try
            {
                dao.ReviewAToy(reviewToy, Name, Email, Title, Content, Rate);

                MessageBox.Show("Thanks!");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
