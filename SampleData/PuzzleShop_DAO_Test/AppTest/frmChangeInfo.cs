using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.User;

namespace AppTest
{
    public partial class frmChangeInfo : Form
    {
        public frmChangeInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var firsName = txtFirstname.Text;
            var lastName = txtLastname.Text;
            var email = txtEmail.Text;

            var dao = new UserDAO();

            dao.EditInformation(username, firsName, lastName, email);

            MessageBox.Show("Change complete!");

            Close();
        }
    }
}