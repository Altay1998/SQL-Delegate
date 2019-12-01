using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForm
{
    public class Validator
    {
        public static bool isValidTexboxes(GroupBox gb)
        {
            foreach (var item in gb.Controls)
            {
                if(item is TextBox)
                {
                    TextBox txbx = (item as TextBox);
                    if (String.IsNullOrEmpty(txbx.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
