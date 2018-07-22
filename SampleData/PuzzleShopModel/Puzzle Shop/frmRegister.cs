using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.UserCollection;

namespace Puzzle_Shop
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            this.ActiveControl = txtUsername;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Email = txtEmail.Text;

            if ( string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please fill in the form!");
                return;
            }
                

            //Regex emailCheck = new Regex("[A - Za - z0 - 9_.,]{ 1,30}\\@[A-Za-z0-9]{1,20}\\.[A-Za-z0-9_.,]{1,20}");
            //if (emailCheck.IsMatch(Email)){
            //    errEmail.Text = "";
            //}
            //else
            //{
            //    errEmail.Text = "Invalid Email!";
            //    return;
            //}

            UserDAO userDao = new UserDAO();
            try
            {
                userDao.register(Username, Password, FirstName, LastName, Email);
                MessageBox.Show("Register completed!");
                this.Close();
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("UNIQUE USERNAME"))
                {
                    MessageBox.Show("Username already used!");
                    return;
                }
                else if (ex.Message.Contains("UNIQUE EMAIL"))
                {
                    MessageBox.Show("Email already used!");
                    return;
                }
                throw;
            }
        }
    }
}
