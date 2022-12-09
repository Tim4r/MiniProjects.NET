using Mushroom_picking.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Mushroom_picking.Views
{
    public partial class AddMushroom : Page
    {
        public AddMushroom()
        {
            InitializeComponent();
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
            DataAccess.InsertMushroom(textBox_nameMushroom.Text, comboBox_nameKingdom.Text, textBox_nameDepartment.Text, textBox_nameGenus.Text, textBox_nameType.Text, comboBox_Edibility.Text, Convert.ToInt32(textBox_weight.Text), Convert.ToInt32(textBox_cost.Text));
            System.Windows.MessageBox.Show("Mushroom successfully saved", "Successfully", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }
    }
}
