using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        Controller controllerObj = new Controller();

        private void button1_Click(object sender, EventArgs e)
        {
            int privilege = controllerObj.CheckPassword(textBox1.Text, textBox2.Text);
            if(privilege==1)
            {
                ManagerForm ChildForm = new ManagerForm();
                this.Hide();
                ChildForm.Show();
                
            }
            else if (privilege==2)
            {
                CashierPersonForm ChildForm = new CashierPersonForm();
                this.Hide();
                ChildForm.Show();
                
            }
            else if (privilege==3)
            {
                ChefForm ChildForm = new ChefForm();
                this.Hide();
                ChildForm.Show();
                
            }
            else if (privilege == 4)
            {
                SupervisorForm childform = new SupervisorForm();
                this.Hide();
                childform.Show();
            }
            else
            {
                MessageBox.Show("Please enter a correct Username and Password");
            }

        }

    }
}
