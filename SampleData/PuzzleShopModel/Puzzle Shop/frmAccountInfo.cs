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

namespace Puzzle_Shop
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
            string username = frmLogin.AuthorizedUser.Username;

            UserDAO dao = new UserDAO();
            User LoggedUser = dao.GetInfomation(username);

            txtUsername.Text = LoggedUser.Username;
            txtFirstname.Text = LoggedUser.FirstName;
            txtLastname.Text = LoggedUser.LastName;
            txtEmail.Text = LoggedUser.Email;

        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {

            frmChangeInfo change = new frmChangeInfo();
            change.ShowDialog();

            loadData();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePass change = new frmChangePass();
            change.ShowDialog();

        }
    }
}
