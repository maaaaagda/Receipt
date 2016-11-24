using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt1
{
    public partial class PrintReceipt : Form
    {
        int order = 1;
        double total = 0;
        public PrintReceipt()
        {
            InitializeComponent();
        }

        private void PrintReceipt_Load(object sender, EventArgs e)
        {
            receiptBindingSource.DataSource = new List<Receipt>();
        }

       

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProdName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                Receipt obj = new Receipt1.Receipt ///rzutowanie
                {
                    Id = order++,
                    ProductName = txtProdName.Text,
                    Price = Convert.ToDouble(txtPrice.Text),
                    Quantity = Convert.ToInt32(txtQuantity.Text)
                };
                total = obj.Price * obj.Quantity;
                receiptBindingSource.Add(obj);
                receiptBindingSource.MoveLast();
                txtProdName.Text = String.Empty;
                txtPrice.Text = String.Empty;
                txtTotal.Text = String.Format("{0}$", total);


            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            Receipt obj = receiptBindingSource.Current as Receipt;
            if (obj != null)
            {
                total -= obj.Price * obj.Quantity;
                txtTotal.Text = String.Format("{0}$", total);
            }
            receiptBindingSource.RemoveCurrent();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
             
    }
}
