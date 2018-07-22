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
    public partial class frmChangeInfo : Form
    {
        public frmChangeInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string FirsName = txtFirstname.Text;
            string LastName = txtLastname.Text;
            string Email = txtEmail.Text;

            UserDAO dao = new UserDAO();

            try
            {
                dao.EditInformation(Username, FirsName, LastName, Email);

                MessageBox.Show("Change complete!");

                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
