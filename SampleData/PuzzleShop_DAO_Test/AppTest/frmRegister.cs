using System;
using System.Windows.Forms;
using PuzzleShop.Shared.Models;
using PuzzleShop.Shared.Models.User;

namespace AppTest
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            ActiveControl = txtUsername;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email))
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

            var userDao = new UserDAO();
            try
            {
                userDao.Register(new User {Username = username, Password = password, FirstName = firstName, LastName = lastName, Email = email});
                MessageBox.Show("Register completed!");
                Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE USERNAME"))
                {
                    MessageBox.Show("Username already used!");
                    return;
                }

                if (!ex.Message.Contains("UNIQUE EMAIL")) throw;
                MessageBox.Show("Email already used!");
            }
        }
    }
}