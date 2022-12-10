using Mushroom_Encyclopedia.Connection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Mushroom_Encyclopedia.Views
{
    public partial class AddMushroom : Page
    {
        public AddMushroom()
        {
            InitializeComponent();
        }
        private void Clear_All()
        {
            textBox_nameMushroom.Clear();
            comboBox_Edibility.Items.Clear();
            textBox_weight.Clear();
            textBox_cost.Clear();
            comboBox_nameKingdom.Items.Clear();
            textBox_nameDepartment.Clear();
            textBox_nameGenus.Clear();
            textBox_nameType.Clear();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Window win = (Window)Parent;
            win.Close();

            SearchDelete searchDelete = new SearchDelete();
            searchDelete.Show();
        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBox_weight.Text, out int weight) && int.TryParse(textBox_cost.Text, out int cost))
            {
                DataAccess.InsertMushroom(textBox_nameMushroom.Text, comboBox_nameKingdom.Text, textBox_nameDepartment.Text, textBox_nameGenus.Text, textBox_nameType.Text, comboBox_Edibility.Text, Convert.ToInt32(textBox_weight.Text), Convert.ToInt32(textBox_cost.Text));
                System.Windows.MessageBox.Show("Mushroom successfully saved", "Successfully", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                Clear_All();
            }
            else
                System.Windows.MessageBox.Show("The mushroom hasn't been added!\n(The weight and/or cost is specified incorrectly)", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
        }
    }
}
