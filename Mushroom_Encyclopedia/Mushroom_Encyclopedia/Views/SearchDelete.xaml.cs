using Mushroom_Encyclopedia.Connection;
using System;
using System.Windows;
using System.Windows.Forms;

namespace Mushroom_Encyclopedia.Views
{
    public partial class SearchDelete : Window
    {
        public SearchDelete()
        {
            InitializeComponent();

            CheckUserRoleID();
            CheckSearchTextBox();
            CheckSelectedRowTextBox();
            CheckDataGridEmpty();
            button_Reload.IsEnabled = false;
        }
        private void CheckSearchTextBox()
        {
            if (textBox_Search.Text.Length > 0)
            {
                button_Search.IsEnabled = true;
                button_Clear.IsEnabled = true;
            }
            else
            {
                button_Search.IsEnabled = false;
                button_Clear.IsEnabled = false;
            }
        }
        private void CheckSelectedRowTextBox()
        {
            if (textBox_SelectedRow.Text.Length > 0)
                button_Delete.IsEnabled = true;
            else
                button_Delete.IsEnabled = false;
        }
        private void CheckDataGridEmpty()
        {
            if (MushroomGrid.ItemsSource == null)
                textBox_SelectedRow.IsEnabled = false;
            else
                textBox_SelectedRow.IsEnabled = true;
        }
        private void CheckUserRoleID()
        {
            switch (DataAccess.userRoleID)
            {
                case 1:
                    StackPanel_ID.Visibility = Visibility.Hidden;
                    StackPanel_AddDelete.Visibility = Visibility.Hidden;
                    button_Reload.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    StackPanel_ID.Visibility = Visibility.Hidden;
                    button_Delete.Visibility = Visibility.Hidden;
                    button_Reload.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        private void ViewData()
        {
            MushroomGrid.ItemsSource = DataAccess.DataTableView();
            button_ViewAll.IsEnabled = false;
            CheckDataGridEmpty();
        }

        private void TextBox_DataChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CheckSearchTextBox();
        }
        private void TextBox_SelectedRow_DataChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CheckSelectedRowTextBox();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            ViewData();
            button_Reload.IsEnabled = false;
        }
        private void LogOut_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow BackToLogIn = new MainWindow();
            Close();
            BackToLogIn.Show();
        }
        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            MushroomGrid.ItemsSource = DataAccess.SearchMushroom(textBox_Search.Text);
            button_ViewAll.IsEnabled = true;
        }
        private void Crear_Btn_Click(object sender, RoutedEventArgs e)
        {
            textBox_Search.Clear();
            CheckSearchTextBox();
        }
        private void ViewAll_Btn_Click(object sender, RoutedEventArgs e)
        {
            ViewData();
        }
        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddMushroom();
        }
        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBox_SelectedRow.Text, out int number) && DataAccess.DeletePeople(Convert.ToInt32(textBox_SelectedRow.Text)))
            {
                System.Windows.MessageBox.Show("Data successfully deleted", "Successfully", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                textBox_SelectedRow.Clear();
                CheckSelectedRowTextBox();
                button_Reload.IsEnabled = true;
            }
            else
                System.Windows.MessageBox.Show("The mushroom hasn't been deleted!\n(The entered ID doesn't exist)", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
        }
    }
}
