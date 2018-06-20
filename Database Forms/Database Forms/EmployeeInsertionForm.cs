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
    public partial class EmployeeInsertionForm : Form
    {
        public EmployeeInsertionForm()
        {
            InitializeComponent();
        }
        Controller controllerObj=new Controller();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Gender = false;
            if (listBox1.SelectedIndex == 0)
            {
                Gender = false;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                Gender = true;
            }
            int no_of_rows = controllerObj.AddEmployee(textBox1.Text, textBox2.Text, textBox3.Text, Gender, Int16.Parse(textBox4.Text), textBox5.Text, textBox6.Text, textBox7.Text, Int16.Parse(textBox8.Text), textBox9.Text, Int16.Parse(textBox10.Text));
            if (no_of_rows == 0)
            {
                MessageBox.Show("Insertion Failed");
            }
            else
            {
                MessageBox.Show("Insertion succeeded");
            }
        }
    }
}
