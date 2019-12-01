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
    public partial class Form1 : Form
    {
        Database db;
        User user;
        public Form1()
        {
            InitializeComponent();
            db = new Database("mydb");
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (Validator.isValidTexboxes(groupBox1))
            {
                string query = $"INSERT INTO myUsers(Name,Surname,Password)" +
                    $"VALUES('{txbx_name.Text}' , '{txbx_surname.Text}','{txbx_pass.Text}')";
                db.SendQuery(query, (x) =>
                {
                    x.ExecuteNonQuery();
                });
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            if (Validator.isValidTexboxes(groupBox2))
            {
                string query = $"SELECT ID FROM myUsers WHERE  Name ='{txbx_userLogin.Text}' and Password = '{txbx_pass_login.Text}'";
                db.SendQuery(query, (x) =>
                {
                    db.CanfigurateSQLDataReader(x, (y) =>
                    {
                        user = new User
                        {
                            Id = (int)y["ID"],
                        };
                        NewForm frm = new NewForm();
                        frm.ShowDialog();
                    });
                });
            }
        }
    }
}
