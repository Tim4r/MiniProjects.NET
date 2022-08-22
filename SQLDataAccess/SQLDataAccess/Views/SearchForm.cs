using SQLDataAccess.Model;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SQLDataAccess.Views
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        private void SearchForm_Load(object sender, System.EventArgs e)
        {
            ViewData();
        }
        private void ViewData()
        {
            DataAccess db = new DataAccess();
            data_OverView.DataSource = db.DataTableView();
            data_OverView.Columns["FullInfo"].Visible = false;
        }


        private void EditToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
        private void DeleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
        

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            DataAccess db = new DataAccess();
            data_OverView.DataSource = db.SearchPeople(searchTextBox.Text);
            clearButton.Enabled = true;
        }
        private void ClearButton_Click(object sender, System.EventArgs e)
        {
            searchTextBox.Clear();
            clearButton.Enabled = false;
        }
        private void ViewButton_Click(object sender, System.EventArgs e)
        {
            ViewData();
        }
        private void SaveChangesButton_Click(object sender, System.EventArgs e)
        {
           
        }
        private void DeleteButton_Click(object sender, System.EventArgs e)
        {

        }
        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to exit?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
            else
                e.Cancel = true;
        }
    }
}
