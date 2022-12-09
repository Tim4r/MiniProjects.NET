using Mushroom_picking.Connection;
using Mushroom_picking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace Mushroom_picking.Views
{
    public partial class SearchDelete : Window
    {
        public SearchDelete()
        {
            InitializeComponent();

            CheckSearchTextBox();
            CheckSelectedRowTextBox();
            CheckDataGridEmpty();
        }
        private void ViewData()
        {
            MushroomGrid.ItemsSource = DataAccess.DataTableView();
            //.Where(p=>p.NameMushroom == "Volodko").ToList();
            button_ViewAll.IsEnabled = false;
            CheckDataGridEmpty();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddMushroom();
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            Mushroom SelectedMushroom = (Mushroom)MushroomGrid.SelectedCells[0].Item;
            DataAccess.DeletePeople(SelectedMushroom.ID);
            System.Windows.MessageBox.Show("Data successfully deleted", "Successfully", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)(MessageBoxButton)MessageBoxIcon.Information);
        }

        private void ViewAll_Btn_Click(object sender, RoutedEventArgs e)
        {
            ViewData();
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
            //MushroomGrid.ItemsSource = DataAccess.Global_Mushrooms.Where(p => p.Cost == 23).ToList();
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
                button_DeleteRow.IsEnabled = true;
            else
                button_DeleteRow.IsEnabled = false;
        }

        private void CheckDataGridEmpty()
        {
            if (MushroomGrid.ItemsSource == null)
                textBox_SelectedRow.IsEnabled = false;
            else
                textBox_SelectedRow.IsEnabled = true;
        }

        private void TextBox_DataChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CheckSearchTextBox();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.InsertUpdateDataTable();
        }

        private void LogOut_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow BackToLogIn = new MainWindow();
            Close();
            BackToLogIn.Show();
        }

        private void TextBox_SelectedRow_DataChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CheckSelectedRowTextBox();
        }
    }
}
