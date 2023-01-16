using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;


namespace QTMS.Transactions
{
    public partial class FrmRMSamplingMaster : Form
    {
        #region Variables
        RMSamplingMaster_Class RMSamplingMaster_Class_obj = new RMSamplingMaster_Class();
        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_Obj = new BusinessFacade.Transactions.RMTransaction_Class();
        #endregion

        private static FrmRMSamplingMaster frmRMSamplingMaster_Obj = null;
        public static FrmRMSamplingMaster GetInstance()
        {
            if (frmRMSamplingMaster_Obj == null)
            {
                frmRMSamplingMaster_Obj = new Transactions.FrmRMSamplingMaster();
            }
            return frmRMSamplingMaster_Obj;
        }


        public FrmRMSamplingMaster()
        {
            InitializeComponent();
        }

        private void FrmRMSamplingMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_RMCode();
            cmbRMSamplingRMCode.Focus();
        }
       
        public void Bind_RMCode()
        {
            try
            {
                
                DataSet ds = new DataSet();
                ds = RMSamplingMaster_Class_obj.Select_RMCodeMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRMSamplingRMCode.DataSource = ds.Tables[0];
                    cmbRMSamplingRMCode.DisplayMember = "RMCode";
                    cmbRMSamplingRMCode.ValueMember = "RMCodeID";

                }
                else
                {
                    cmbRMSamplingRMCode.DataSource = ds.Tables[0];
                    cmbRMSamplingRMCode.DisplayMember = "RMCode";
                    cmbRMSamplingRMCode.ValueMember = "RMCodeID";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void cmbRMSamplingRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                if ((cmbRMSamplingRMCode.SelectedValue.ToString() != null) && (cmbRMSamplingRMCode.SelectedValue.ToString() != ""))
                {

                    txtRMSamplingActualNoSegments.Text = "";
                    List.Items.Clear();
                    txtRMSamplingNoOfSegments.Text = "";
                    txtRMSamplingPlantLotNo.Text = "";
                    txtRMSamplingQuantityReceived.Text = "";
                    txtRMSamplingQuantityToBeCompleted.Text = "";
                    cmbRMSamplingSupplierName.Enabled = true;


                    DataSet ds = new DataSet();
                    RMSamplingMaster_Class_obj.rmcodeid = Convert.ToInt64(cmbRMSamplingRMCode.SelectedValue.ToString());
                    ds = RMSamplingMaster_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID();
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["RMSupplierName"] = "--Select--";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        cmbRMSamplingSupplierName.DataSource = ds.Tables[0];
                        cmbRMSamplingSupplierName.DisplayMember = "RMSupplierName";
                        cmbRMSamplingSupplierName.ValueMember = "RMSupplierID";

                    }
                    else
                    {

                        cmbRMSamplingSupplierName.DataSource = ds.Tables[0];
                        cmbRMSamplingSupplierName.DisplayMember = "RMSupplierName";
                        cmbRMSamplingSupplierName.ValueMember = "RMSupplierID";

                    }

                    //DataSet dsAllRecordsRMSampling = new DataSet();
                    //dsAllRecordsRMSampling = RMSamplingMaster_Class_obj.Select_RMSampling_RMCodeID_All();
                    //if (dsAllRecordsRMSampling.Tables[0].Rows.Count > 0)
                    //{
                    //    cmbRMSamplingSupplierName.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["RMSupplierName"].ToString();
                    //    txtRMSamplingActualNoSegments.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                    //    txtRMSamplingNoOfSegments.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["NoOfSegments"].ToString();
                    //    txtRMSamplingPlantLotNo.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["PlantLotNo"].ToString();
                    //    txtRMSamplingQuantityReceived.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["QuantityReceived"].ToString();
                    //    txtRMSamplingQuantityToBeCompleted.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["QuantitySampled"].ToString();
                    //    txtRMSamplingAgentName.Text = dsAllRecordsRMSampling.Tables[0].Rows[0]["RMAgentName"].ToString();
                    //}


                }
                else
                {
                    txtRMSamplingActualNoSegments.Text = "";
                    List.Items.Clear();
                    txtRMSamplingNoOfSegments.Text = "";
                    txtRMSamplingPlantLotNo.Text = "";
                    txtRMSamplingQuantityReceived.Text = "";
                    txtRMSamplingQuantityToBeCompleted.Text = "";
                    cmbRMSamplingSupplierName.Text = "";
                    cmbRMSamplingSupplierName.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void BtnRMExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

                    
        private void BtnRMSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (cmbRMSamplingRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRMSamplingRMCode.SelectedValue == null)
                {
                    MessageBox.Show("Invalid RM Code Selected.Please Select Proper RM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRMSamplingSupplierName.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Supplier Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMSamplingSupplierName.Focus();
                    return;
                }
                if (txtRMSamplingPlantLotNo.Text == "")
                {
                    MessageBox.Show("Please Enter Plant Lot Number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMSamplingPlantLotNo.Focus();
                    return;
                }
                if (txtRMSamplingQuantityReceived.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity Received", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMSamplingQuantityReceived.Focus();
                    return;
                }
                if (txtRMSamplingQuantityToBeCompleted.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity Sampled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMSamplingQuantityToBeCompleted.Focus();
                    return;
                }
                if (txtRMSamplingActualNoSegments.Text == "")
                {
                    MessageBox.Show("Please Enter Actual No of Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMSamplingNoOfSegments.Focus();
                    return;
                }
                if (txtRMSamplingNoOfSegments.Text == "")
                {
                    MessageBox.Show("No of Segments cannot be blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMSamplingNoOfSegments.Focus();
                    return;
                }
                
                RMSamplingMaster_Class_obj.rmcodeid = Convert.ToInt64(cmbRMSamplingRMCode.SelectedValue.ToString());
                RMSamplingMaster_Class_obj.rmsupplierid = Convert.ToInt64(cmbRMSamplingSupplierName.SelectedValue.ToString());
                RMSamplingMaster_Class_obj.plantlotno = txtRMSamplingPlantLotNo.Text.ToString();
                RMSamplingMaster_Class_obj.quantityreceived =txtRMSamplingQuantityReceived.Text.ToString();
                RMSamplingMaster_Class_obj.quantitysampled = txtRMSamplingQuantityToBeCompleted.Text.ToString();
                RMSamplingMaster_Class_obj.actualnoofsegments = Convert.ToInt32(txtRMSamplingActualNoSegments.Text.ToString());
                RMSamplingMaster_Class_obj.noofsegments = Convert.ToInt32(txtRMSamplingNoOfSegments.Text.ToString());

                DataSet ds2 = new DataSet();
                ds2=RMSamplingMaster_Class_obj.Select_RMSampling_ForDuplicate();               

                if (ds2.Tables[0].Rows.Count>0)
                {
                    if(MessageBox.Show("Sampling Already Done...!\n\n Update ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {

                        bool b = RMSamplingMaster_Class_obj.Update_RMSampling();
                        if (b == true)
                        {
                            MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bind_RMCode();
                            BtnRMReset_Click(sender, e);
                        }
                    }                    
                }
                else
                {
                    RMSamplingMaster_Class_obj.Insert_RMSampling();
                    MessageBox.Show("Record Inserted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_RMCode();
                    BtnRMReset_Click(sender, e);    
                }                                                                           
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
            

        private void txtRMSamplingActualNoSegments_Leave(object sender, EventArgs e)
        {
            try
            {
                
                if (txtRMSamplingQuantityToBeCompleted.Text == "")
                {
                    MessageBox.Show("Please Enter The Quantity Sampled Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (txtRMSamplingActualNoSegments.Text == "")
                {
                    MessageBox.Show("Please Enter The Actual No of Segments Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblMessageToBeDiplayed.Text = "";
                lblMessageToBeDiplayed.Visible = true;
                double NoOfSegments;
                NoOfSegments = Convert.ToDouble(txtRMSamplingActualNoSegments.Text.ToString());
                double real = Math.Sqrt(NoOfSegments) ;
                double fraction = real-Math.Floor(real);
                if (fraction <= 0.5)
                {
                    txtRMSamplingNoOfSegments.Text = Convert.ToString(Math.Floor(real)+1);
                }
                else
                {
                    txtRMSamplingNoOfSegments.Text = Convert.ToString(Math.Ceiling(real) + 1);

                }
                
                lblMessageToBeDiplayed.Text = txtRMSamplingQuantityToBeCompleted.Text + "  " + "Samples Collected from" + "  " + txtRMSamplingNoOfSegments.Text + "  " + "Segments" ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void BtnRMReset_Click(object sender, EventArgs e)
        {
            txtRMSamplingActualNoSegments.Text = "";
            txtRMSamplingNoOfSegments.Text = "";
            txtRMSamplingPlantLotNo.Text = "";
            txtRMSamplingQuantityReceived.Text = "";
            txtRMSamplingQuantityToBeCompleted.Text = "";
            List.Items.Clear();
            lblMessageToBeDiplayed.Text = "";
            cmbRMSamplingRMCode.Text = "--Select--";
            cmbRMSamplingSupplierName.Text = "--Select--";
            cmbRMSamplingSupplierName.Enabled = false;          
            
        }

      
        private void BtnRMDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRMSamplingRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RMSamplingMaster_Class_obj.rmcodeid = Convert.ToInt64(cmbRMSamplingRMCode.SelectedValue.ToString());
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = RMSamplingMaster_Class_obj.Delete_RMSampling_RMCodeID();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnRMReset_Click(sender, e);
                   
                        Bind_RMCode();

                    }
                }
            }
            catch 
            {
                MessageBox.Show("Cannot Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbRMSamplingSupplierName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            
            if (cmbRMSamplingSupplierName.Text == "--Select--")
            {
                List.Items.Clear();
            }

            if ((cmbRMSamplingSupplierName.SelectedValue.ToString() != null) && (cmbRMSamplingSupplierName.SelectedValue.ToString() != ""))
            {
                List.Items.Clear();
                DataSet ds = new DataSet();
                RMSamplingMaster_Class_obj.rmcodeid = Convert.ToInt64(cmbRMSamplingRMCode.SelectedValue.ToString());
                RMSamplingMaster_Class_obj.rmsupplierid = Convert.ToInt64(cmbRMSamplingSupplierName.SelectedValue.ToString());
                ds = RMSamplingMaster_Class_obj.Select_RMSupplierAgentMaster_RMCodeId_RMSupplierID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        List.Items.Add(ds.Tables[0].Rows[i]["RMAgentName"].ToString());
                    }

                }
            }
        }

        private void txtRMSamplingQuantityToBeCompleted_Leave(object sender, EventArgs e)
        {
            if (txtRMSamplingQuantityToBeCompleted.Text == "")
            {
                MessageBox.Show("Please Enter The Quantity Sampled Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            lblMessageToBeDiplayed.Text = "";
            if (txtRMSamplingActualNoSegments.Text != "")
            {
                txtRMSamplingActualNoSegments_Leave(sender, e);
            }
        }

      

        private void txtRMSamplingActualNoSegments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

              e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

              e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRMSamplingPlantLotNo_Leave(object sender, EventArgs e)
        {
            RMTransaction_Class_Obj.plantlotno = txtRMSamplingPlantLotNo.Text;
            if (RMTransaction_Class_Obj.Get_If_LotNoExists())
            {
                MessageBox.Show("This lot number exists already.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRMSamplingPlantLotNo.Text = string.Empty;
                txtRMSamplingPlantLotNo.Focus();
            }
        }

             
    }
}