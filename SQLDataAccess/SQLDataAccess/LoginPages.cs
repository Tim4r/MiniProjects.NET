using SQLDataAccess.Model;
using SQLDataAccess.Views;
using System;
using System.Windows.Forms;

namespace SQLDataAccess
{
    public partial class LoginPages : Form
    {
        public LoginPages()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            if (db.LogIn(userNameText.Text, passwordText.Text))
            {
                SearchForm Search_Form = new SearchForm();
                Hide();
                Search_Form.Show();
            } else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameText.Clear();
                passwordText.Clear();
            }
        }
    }
}
