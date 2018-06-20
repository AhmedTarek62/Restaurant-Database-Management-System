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
    public partial class ManagerForm : Form
    {
        Controller controllerObj = new Controller();
        public ManagerForm()
        {
            InitializeComponent();
        }





        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                SupplierInsertionForm childform = new SupplierInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 1)
            {
                SupplyInsertionForm childform = new SupplyInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 2)
            {
                EmployeeInsertionForm childform = new EmployeeInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 3)
            {
                BranchInsertionForm childform = new BranchInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 4)
            {
                WarehouseInsertionForm childform = new WarehouseInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 5)
            {
                WorksAt_BrInsertionForm childform = new WorksAt_BrInsertionForm();
                childform.Show();
            }
            else if (listBox1.SelectedIndex == 6)
            {
                WorksAt_WHInsertionForm childform = new WorksAt_WHInsertionForm();
                childform.Show();
            }
        }

        private void totalIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalIncomeMenuStripForm childform = new TotalIncomeMenuStripForm();
            childform.Show();
        }

        private void suppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostUsedItemMenuStripForm childform = new MostUsedItemMenuStripForm();
            childform.Show();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.WorksAtWH' table. You can move, or remove it, as needed.
            this.worksAtWHTableAdapter.Fill(this.projectDataSet.WorksAtWH);
            // TODO: This line of code loads data into the 'projectDataSet.WorksAtBr' table. You can move, or remove it, as needed.
            this.worksAtBrTableAdapter.Fill(this.projectDataSet.WorksAtBr);
            // TODO: This line of code loads data into the 'projectDataSet.Warehouse' table. You can move, or remove it, as needed.
            this.warehouseTableAdapter.Fill(this.projectDataSet.Warehouse);
            // TODO: This line of code loads data into the 'projectDataSet.Branch_Has' table. You can move, or remove it, as needed.
            this.branch_HasTableAdapter.Fill(this.projectDataSet.Branch_Has);
            // TODO: This line of code loads data into the 'projectDataSet.Branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.projectDataSet.Branch);
            // TODO: This line of code loads data into the 'projectDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.projectDataSet.Employee);
            // TODO: This line of code loads data into the 'projectDataSet.Supply' table. You can move, or remove it, as needed.
            this.supplyTableAdapter.Fill(this.projectDataSet.Supply);
            // TODO: This line of code loads data into the 'projectDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.projectDataSet.Supplier);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Supplier;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 1)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Supply;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 2)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Employee;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Branch;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 4)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.Warehouse;
                dataGridView1.Refresh();
            }

            else if (listBox1.SelectedIndex == 5)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.WorksAtBr;
                dataGridView1.Refresh();
            }
            else if (listBox1.SelectedIndex == 6)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = projectDataSet.WorksAtWH;
                dataGridView1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.WorksAtWH' table. You can move, or remove it, as needed.
            this.worksAtWHTableAdapter.Fill(this.projectDataSet.WorksAtWH);
            // TODO: This line of code loads data into the 'projectDataSet.WorksAtBr' table. You can move, or remove it, as needed.
            this.worksAtBrTableAdapter.Fill(this.projectDataSet.WorksAtBr);
            // TODO: This line of code loads data into the 'projectDataSet.Warehouse' table. You can move, or remove it, as needed.
            this.warehouseTableAdapter.Fill(this.projectDataSet.Warehouse);
            // TODO: This line of code loads data into the 'projectDataSet.Branch_Has' table. You can move, or remove it, as needed.
            this.branch_HasTableAdapter.Fill(this.projectDataSet.Branch_Has);
            // TODO: This line of code loads data into the 'projectDataSet.Branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.projectDataSet.Branch);
            // TODO: This line of code loads data into the 'projectDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.projectDataSet.Employee);
            // TODO: This line of code loads data into the 'projectDataSet.Supply' table. You can move, or remove it, as needed.
            this.supplyTableAdapter.Fill(this.projectDataSet.Supply);
            // TODO: This line of code loads data into the 'projectDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.projectDataSet.Supplier);
            dataGridView1.Refresh();
        }

        private void activeCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveCustomersForm childform = new ActiveCustomersForm();
            childform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj.UpdateRawMaterialPrice(Int16.Parse(textBox1.Text), Int16.Parse(textBox2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
