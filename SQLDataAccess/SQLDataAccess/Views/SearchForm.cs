using SQLDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SQLDataAccess.Views
{
    public partial class SearchForm : Form
    {
        public List<Person> NewPeople = new List<Person>();
        public SearchForm()
        {
            InitializeComponent();
        }
        private void SearchForm_Load(object sender, System.EventArgs e)
        {
            ViewData();
            CheckSearchTextBox();
        }
        private void ViewData()
        {
            data_OverView.DataSource = DataAccess.DataTableView();
            data_OverView.Columns["FullInfo"].Visible = false;
            data_OverView.Columns["ID"].Visible = false;
            data_OverView.Columns["DefaultPeople"].Visible = false;
            data_OverView.BackgroundColor = data_OverView.DefaultCellStyle.BackColor;
            viewButton.Enabled = false;
        }
        private void CheckSearchTextBox()
        {
            if (searchTextBox.Text.Length > 0)
            {
                clearButton.Enabled = true;
                searchButton.Enabled = true;
            } else
            {
                clearButton.Enabled = false;
                searchButton.Enabled = false;
            }
        }
        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            data_OverView.DataSource = DataAccess.SearchPeople(searchTextBox.Text);
            viewButton.Enabled = true;
        }
        private void ClearButton_Click(object sender, System.EventArgs e)
        {
            searchTextBox.Clear();
            CheckSearchTextBox();
        }
        private void ViewButton_Click(object sender, System.EventArgs e)
        {
            ViewData();
        }
        private void SaveChangesButton_Click(object sender, System.EventArgs e) // Доработка
        {

            var LocalNewPeople = new List<Person>(data_OverView.RowCount);

            for (int index = 0; index < data_OverView.RowCount; index++)
            {
                var SelectedRow = data_OverView.Rows[index];
                var person = (Person)SelectedRow.DataBoundItem;

                LocalNewPeople.Add(person);
            }
            NewPeople = new List<Person>(LocalNewPeople);

            DataAccess.UpdatePeople(NewPeople);
        }
        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            int CelectedUser_ID = Convert.ToInt32(data_OverView.SelectedCells[0].Value);
            DataAccess.DeletePeople(CelectedUser_ID);
            MessageBox.Show("Data successfully deleted", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewData();
        }
        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to exit?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
            else
                e.Cancel = true;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckSearchTextBox();
        }
    }
}
