using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.UserCollection;
using Library;

namespace Puzzle_Shop
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

            string OldPassword = txtOld.Text;

            UserDAO dao = new UserDAO();
            
            if(!MD5Hash.VerifyMD5Hash(OldPassword, dao.GetInfomation(frmLogin.AuthorizedUser.Username).PasswordHash))
            {
                MessageBox.Show("Old password not match!");
                return;
            }

            string NewPassword = txtNew.Text;
            string ConfirmPassword = txtConfirm.Text;

            if (!NewPassword.Equals(ConfirmPassword)){
                MessageBox.Show("Confirm Password must match!");
                return;
            }

            try
            {
                dao.ChangePassword(frmLogin.AuthorizedUser.Username, NewPassword);

                MessageBox.Show("Password Changed!");

                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
