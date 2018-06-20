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
    public partial class ChefForm : Form
    {
        Controller controllerObj = new Controller();
        public ChefForm()
        {
            InitializeComponent();
        }
        
        private void menuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemsForm ChildForm = new MenuItemsForm();
            ChildForm.Show();
        }

        private void ChefForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = controllerObj.ViewOrderListAndStatus(Int16.Parse(textBox1.Text));
            dataGridView1.Refresh();
        }

    }
}
