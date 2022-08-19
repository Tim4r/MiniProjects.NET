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
            DataAccess db = new DataAccess();

            data_OverView.DataSource = db.DataTableView();
            data_OverView.Columns["FullInfo"].Visible = false;
        }
        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Ansver = MessageBox.Show("Are you sure you want to exit?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ansver == DialogResult.Yes) { Application.Exit(); }

        }
        private void EditToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
    }
}
