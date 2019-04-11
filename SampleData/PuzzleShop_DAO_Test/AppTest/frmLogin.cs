using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.User;

namespace AppTest
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        public static User AuthorizedUser { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            var userDao = new UserDAO();

            try
            {
                AuthorizedUser = userDao.CheckLogin(username, password);

                MessageBox.Show($"Logged as {AuthorizedUser.FirstName}");
                if (AuthorizedUser != null)
                {
                    Hide();
                    var main = new frmDisplayToy();
                    main.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Login fail!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Login failed!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var register = new frmRegister();
            register.ShowDialog();
        }
    }
}