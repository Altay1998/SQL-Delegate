using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForm
{
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            Database db = new Database("mydb");
            string query = $"SELECT ID,Name,Surname FROM myUsers ";
            List<User> users = new List<User>();
            db.SendQuery(query, (x) =>
            {
                db.CanfigurateSQLDataReader(x, (y) =>
                {
                    users.Add(new User
                    {
                        Id = (int)y["ID"],
                        Name = y["Name"].ToString(),
                        Surname = y["Surname"].ToString()
                    });
                });
            });
            dataGridView1.DataSource = users;
        }
    }
}
