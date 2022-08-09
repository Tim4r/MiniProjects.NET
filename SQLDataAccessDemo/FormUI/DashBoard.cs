using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormUI
{
    public partial class DashBoard : Form
    {
        List<Person> people = new List<Person>();
        public DashBoard()
        {
            InitializeComponent();
        }
        
        private void UpdateBinding()
        {
            peopleFoundListbox.DataSource = people;
            peopleFoundListbox.DisplayMember = "FullInfo";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            people = db.GetPeople(LastNameText.Text);
            UpdateBinding();
        }
    }
}
