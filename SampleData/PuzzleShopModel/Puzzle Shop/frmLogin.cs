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
using Library.UserCollection;

namespace Puzzle_Shop
{
    public partial class frmLogin : Form
    {

        public static User AuthorizedUser { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            UserDAO userDao = new UserDAO();

            try
            {
                AuthorizedUser = userDao.checkLogin(Username, Password);

                MessageBox.Show($"Logged as {AuthorizedUser.FirstName}");
                if (AuthorizedUser != null)
                {
                    this.Hide();
                    frmDisplayToy main = new frmDisplayToy();
                    main.ShowDialog();
                    this.Close();
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
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }
    }
}
