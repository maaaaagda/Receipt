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
    public partial class frmReceiptReportViewer : Form
    {
        List<Receipt> _list;
        string _total, _change, _cash, _date;

        public frmReceiptReportViewer(List<Receipt> dataSource, string date, string cash, string change, string total)
        {
            _list = dataSource;
            _total = total;
            _cash = cash;
            _change = change;
            _date = date;
            //InitializeComponent();
        }
        

        private void frmReceiptReportViewer_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_total),
                new Microsoft.Reporting.WinForms.ReportParameter("pCash",_cash),
                new Microsoft.Reporting.WinForms.ReportParameter("pChange",_change),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate",_date)
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
          }
    }
}
