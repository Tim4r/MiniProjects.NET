using System.Windows;
using Mushroom_Encyclopedia.Connection;
using Mushroom_Encyclopedia.Views;

namespace Mushroom_Encyclopedia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSighIn_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.LogIn(textBox_login.Text, textBox_password.Text))
            {
                DataAccess.userRoleID = DataAccess.GetRoleID(textBox_login.Text, textBox_password.Text);
                SearchDelete searchDelete = new SearchDelete();
                Hide();
                searchDelete.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_login.Clear();
                textBox_password.Clear();
            }
        }
    }
}
