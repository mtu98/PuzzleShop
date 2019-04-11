using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.User;

namespace AppTest
{
    public partial class frmAccountInfo : Form
    {
        public frmAccountInfo()
        {
            InitializeComponent();

            txtUsername.ReadOnly = true;
            txtFirstname.ReadOnly = true;
            txtLastname.ReadOnly = true;
            txtEmail.ReadOnly = true;

            loadData();
        }


        public void loadData()
        {
            var username = frmLogin.AuthorizedUser.Username;

            var dao = new UserDAO();
            var LoggedUser = dao.GetUserByUsername(username);

            txtUsername.Text = LoggedUser.Username;
            txtFirstname.Text = LoggedUser.FirstName;
            txtLastname.Text = LoggedUser.LastName;
            txtEmail.Text = LoggedUser.Email;
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            var change = new frmChangeInfo();
            change.ShowDialog();

            loadData();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var change = new frmChangePass();
            change.ShowDialog();
        }
    }
}