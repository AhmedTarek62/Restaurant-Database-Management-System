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
    public partial class CashierCustomerForm : Form
    {
        public CashierCustomerForm()
        {
            InitializeComponent();
        }

        private void CashierCustomerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.projectDataSet.Customer);

        }
    }
}
