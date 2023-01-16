using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;

namespace QTMS.Mettler
{
    public partial class FrmMettler : Form
    {
        public FrmMettler()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();

        private void FrmMettler_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["FGTLFID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}