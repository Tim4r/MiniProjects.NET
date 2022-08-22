﻿using SQLDataAccess.Model;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SQLDataAccess.Views
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
        private void EditForm_Load(object sender, System.EventArgs e)
        {
            DataAccess db = new DataAccess();

            data_OverView.DataSource = db.DataTableView();
            data_OverView.Columns["FullInfo"].Visible = false;
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
