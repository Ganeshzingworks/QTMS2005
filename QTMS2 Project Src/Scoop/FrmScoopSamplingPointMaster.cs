using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Scoop_Class;

namespace QTMS.Scoop
{
    public partial class FrmScoopSamplingPointMaster : Form
    {
        public FrmScoopSamplingPointMaster()
        {
            InitializeComponent();
        }
        #region variables
        BusinessFacade.LineSamplingPointMaster_Class obj_LineSamplingPointMaster_Class = new LineSamplingPointMaster_Class();
        #endregion
        #region variable for page scope
        bool Modify; bool delete;
        #endregion
        private static FrmScoopSamplingPointMaster objFrmScoopSamplingPointMaster = null;
        public static FrmScoopSamplingPointMaster GetInstance()
        {
            if (objFrmScoopSamplingPointMaster == null)
            {
                objFrmScoopSamplingPointMaster = new FrmScoopSamplingPointMaster();
            }
            return objFrmScoopSamplingPointMaster;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmScoopSamplingPointMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this); Modify = false; delete = false;
            DsList = new DataSet();
            Bind_List();
            txtSamplingPoint.Focus();
        }
        DataSet DsList;
        private void Bind_List()
        {
            DsList.Clear();
            DsList = obj_LineSamplingPointMaster_Class.Select_SamplingPointMaster();
            lstSamplingPnt.DisplayMember = "SamplingPointName";
            lstSamplingPnt.ValueMember = "SamplingPointId";
            lstSamplingPnt.DataSource = DsList.Tables[0];
           
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtSamplingPoint.Text = string.Empty;
            BtnDelete.Enabled = false;
            Modify = false; 
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSamplingPoint.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter sampling Point..", " message ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj_LineSamplingPointMaster_Class.del = false;
                    obj_LineSamplingPointMaster_Class.samplingName = txtSamplingPoint.Text;
                    if (Modify == false)
                    {
                        if (Existing_Record())
                        {
                            if (obj_LineSamplingPointMaster_Class.Insert_SamplingPointMaster())
                            {
                                MessageBox.Show("Record saved succesfully", " message ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Bind_List();
                            }
                        }
                    }
                    else
                    {
                        if (obj_LineSamplingPointMaster_Class.Update_SamplingPointMaster())
                        {

                            MessageBox.Show("Record updated succesfully", " message ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bind_List();
                        }

                        Modify = false;
                    }
                    BtnReset_Click(sender, e);
                }
            }
            catch
            { 
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstSamplingPnt_DoubleClick(object sender, EventArgs e)
        {
            obj_LineSamplingPointMaster_Class.samplingPointId = Convert.ToInt64(lstSamplingPnt.SelectedValue.ToString());
            txtSamplingPoint.Text = lstSamplingPnt.Text;
            BtnDelete.Enabled = true;
            Modify = true;
        }

        private bool Existing_Record()
        {

            try
            {
                DataRow[] dr = DsList.Tables[0].Select("SamplingPointName ='" + txtSamplingPoint.Text.Trim() + "'");
                int len = dr.Length;
                if (len > 0)
                {
                    MessageBox.Show("Record exist already ...");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult RS = MessageBox.Show("Do you want to delete ?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (RS.ToString() == "Yes")
            {
                obj_LineSamplingPointMaster_Class.del = true;
                obj_LineSamplingPointMaster_Class.samplingName = lstSamplingPnt.Text;
                if (obj_LineSamplingPointMaster_Class.Update_SamplingPointMaster())
                {
                    MessageBox.Show("Record deleted Succesfully..");
                    BtnReset_Click(sender, e);
                    Bind_List();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {           
            string searchString = txtSearch.Text;
            DsList.Tables[0].DefaultView.RowFilter = "SamplingPointName like  '" + searchString + "%'";
            lstSamplingPnt.DisplayMember = "SamplingPointName";
            lstSamplingPnt.ValueMember = "SamplingPointId";
            lstSamplingPnt.DataSource = DsList.Tables[0];
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(lstSamplingPnt.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    obj_LineSamplingPointMaster_Class.samplingPointId = Convert.ToInt64(lstSamplingPnt.SelectedValue.ToString());
                    //txtTestDescription.Text = LstTest.Text;
                    txtSamplingPoint.Text = lstSamplingPnt.Text;
                    BtnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstSamplingPnt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    lstSamplingPnt.Select();
                    lstSamplingPnt.SelectedIndex = lstSamplingPnt.SelectedIndex - 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {
                //  MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    lstSamplingPnt.Select();                 
                    lstSamplingPnt.SelectedIndex = lstSamplingPnt.SelectedIndex + 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
               
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Up)
                {
                    lstSamplingPnt.Select();
                    lstSamplingPnt.SelectedIndex = lstSamplingPnt.SelectedIndex - 1;
                    if (lstSamplingPnt.SelectedIndex == 0)
                    {
                        MessageBox.Show("This is last item", "QTMS");
                    }
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {
               
                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSamplingPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                BtnSave.Focus();
            }
        }
    }
}
