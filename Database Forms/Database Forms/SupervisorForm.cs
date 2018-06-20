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
    public partial class SupervisorForm : Form
    {
        public SupervisorForm()
        {
            InitializeComponent();
        }
        Controller controllerObj = new Controller();
        private void SupervisorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Branch_Has;
                dataGridView1.Refresh();
            }
            else if(listBox1.SelectedIndex == 1)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.BranchGets;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 2)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.WarehouseHas;
                
            }
        }

        private void SupervisorForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Cust_Order' table. You can move, or remove it, as needed.
            this.cust_OrderTableAdapter.Fill(this.projectDataSet.Cust_Order);
            // TODO: This line of code loads data into the 'projectDataSet.WarehouseHas' table. You can move, or remove it, as needed.
            this.warehouseHasTableAdapter.Fill(this.projectDataSet.WarehouseHas);
            // TODO: This line of code loads data into the 'projectDataSet.BranchGets' table. You can move, or remove it, as needed.
            this.branchGetsTableAdapter.Fill(this.projectDataSet.BranchGets);
            // TODO: This line of code loads data into the 'projectDataSet.Branch_Has' table. You can move, or remove it, as needed.
            this.branch_HasTableAdapter.Fill(this.projectDataSet.Branch_Has);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BranchTransaction childform = new BranchTransaction();
            childform.Show();
        }
    }
}
