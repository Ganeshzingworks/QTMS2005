using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;

namespace QTMS.Transactions
{
    public partial class FrmRMTransactionModification : Form
    {
        public FrmRMTransactionModification()
        {
            InitializeComponent();
        }
        #region Variables

        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_obj = new BusinessFacade.Transactions.RMTransaction_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_obj = new BusinessFacade.Transactions.Comman_Class();
        #endregion

        private void FrmRMTransactionCorrection_Load(object sender, EventArgs e)
        {
            Bind_RMDetails();
        }

        public void Bind_RMDetails()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = RMTransaction_Class_obj.Select_RMTransactionDone();
                DataRow dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRMDetails.DataSource = ds.Tables[0];
                    cmbRMDetails.DisplayMember = "Details";
                    cmbRMDetails.ValueMember = "RMTransID";

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void cmbRMDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
       
       
       
       
    }
}