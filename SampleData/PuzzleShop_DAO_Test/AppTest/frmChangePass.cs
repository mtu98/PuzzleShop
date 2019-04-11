using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.User;
using Utils;

namespace AppTest
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
            txtOld.PasswordChar = '*';
            txtNew.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var oldPassword = txtOld.Text;

            var dao = new UserDAO();

            if (!MD5Hash.VerifyMD5Hash(oldPassword,
                dao.GetUserByUsername(frmLogin.AuthorizedUser.Username).PasswordHash))
            {
                MessageBox.Show("Old password not match!");
                return;
            }

            var newPassword = txtNew.Text;
            var confirmPassword = txtConfirm.Text;

            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Confirm Password must match!");
                return;
            }

            dao.ChangePassword(frmLogin.AuthorizedUser.Username, newPassword);

            MessageBox.Show("Password Changed!");

            Close();
        }
    }
}