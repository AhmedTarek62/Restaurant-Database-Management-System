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
    public partial class BranchTransaction : Form
    {
        public BranchTransaction()
        {
            InitializeComponent();
        }
        Controller controllerObj = new Controller();
        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj.AddBranch_WarehouseTransaction(Int16.Parse(textBox2.Text), Int16.Parse(textBox3.Text), Int16.Parse(textBox4.Text), Convert.ToDateTime(textBox5.Text), Int16.Parse(textBox6.Text), listBox1.GetItemText(listBox1.SelectedItem), Int16.Parse(textBox8.Text));
        }
    }
}
