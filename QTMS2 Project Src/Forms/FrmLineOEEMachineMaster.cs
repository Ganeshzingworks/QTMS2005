using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Transactions;

namespace QTMS.Forms
{
    public partial class FrmLineOEEMachineMaster : Form
    {
        public FrmLineOEEMachineMaster()
        {
            InitializeComponent();
        }

        # region Varibles
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        LineOEEMachineMaster_Class LineOEEMachineMaster_Class_Obj = new LineOEEMachineMaster_Class();
        Comman_Class Comman_Class_Obj = new Comman_Class();
        bool Modify = false;
        #endregion

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineOEEMachineMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            CmbLineNo.Focus();
            Bind_LineNo();
            Bind_List();
        }
        DataSet dsList = new DataSet();
        public void Bind_List()
        {
            try
            {

                dsList = LineOEEMachineMaster_Class_Obj.Select_tblLineOEEMachineMaster();

                LstTest.DataSource = dsList.Tables[0];
                LstTest.DisplayMember = "MachineName";
                LstTest.ValueMember = "Mid";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Bind Line No from line No master
        /// </summary>
        DataSet Lineds;
        public void Bind_LineNo()
        {
            Lineds = new DataSet();
            DataRow dr;
            Lineds = LineMaster_Class_Obj.Select_LineMaster();
            dr = Lineds.Tables[0].NewRow();
            dr["LineDesc"] = "--Select--";
            dr["LNo"] = "0";
            Lineds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbLineNo.DataSource = Lineds.Tables[0];
                CmbLineNo.DisplayMember = "LineDesc";
                CmbLineNo.ValueMember = "LNo";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(CmbLineNo.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Line No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbLineNo.Focus();
                    return;
                }
                if (txtMachineName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Emter Machine Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMachineName.Focus();
                    return;
                }


                if (Modify == false)
                {
                    LineOEEMachineMaster_Class_Obj.Lno = Convert.ToInt64(CmbLineNo.SelectedValue);
                    LineOEEMachineMaster_Class_Obj.MachineName = txtMachineName.Text.Trim();
                    LineOEEMachineMaster_Class_Obj.Active = 1;
                    LineOEEMachineMaster_Class_Obj.CreatedBy = FrmMain.LoginID;

                    DataTable DtExist = LineOEEMachineMaster_Class_Obj.tblLineOEEMachineMaster_RecordExist();
                    if (DtExist.Rows.Count > 0)
                    {
                        if (DtExist.Rows[0]["Active"].ToString() == "1")
                            MessageBox.Show("Record allready exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (MessageBox.Show("Record allready exist.\r\n in delete record Do you want Active this record.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                long mid = Convert.ToInt64(DtExist.Rows[0]["Mid"].ToString());
                                bool b = LineOEEMachineMaster_Class_Obj.tblLineOEEMachineMaster_Activate(mid);
                                if (b == true)
                                {
                                    MessageBox.Show("Record Active Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BtnReset_Click(sender, e);
                                }
                            }
                        }
                    }
                    else
                    {
                        bool result = LineOEEMachineMaster_Class_Obj.tblLineOEEMachineMaster_Insert();
                        if (result == true)
                        {
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
                else
                {
                    LineOEEMachineMaster_Class_Obj.Lno = Convert.ToInt64(CmbLineNo.SelectedValue);
                    LineOEEMachineMaster_Class_Obj.MachineName = txtMachineName.Text.Trim();
                    LineOEEMachineMaster_Class_Obj.Mid = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    if (LineOEEMachineMaster_Class_Obj.Mid == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = LineOEEMachineMaster_Class_Obj.tblLineOEEMachineMaster_Update();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "MachineName like  '" + searchString + "%'";
            LstTest.DataSource = dsList.Tables[0];

            LstTest.DisplayMember = "MachineName";
            LstTest.ValueMember = "Mid";
        }

        private void LstTest_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                Modify = true;
                DataTable ds = new DataTable();
                LineOEEMachineMaster_Class_Obj.Mid = Convert.ToInt64(LstTest.SelectedValue.ToString());
               
                ds = LineOEEMachineMaster_Class_Obj.Select_tblLineOEEMachineMaster_ByMid();
                if (ds.Rows.Count > 0)
                {
                    CmbLineNo.SelectedValue = Convert.ToInt64(ds.Rows[0]["Lno"].ToString());
                    txtMachineName.Text = ds.Rows[0]["MachineName"].ToString();
                }
                BtnDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            CmbLineNo.SelectedValue = 0;
            txtMachineName.Text = "";
            CmbLineNo.Focus();
            BtnDelete.Enabled = false;
            Modify = false;
            BtnDelete.Enabled = false;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            LstTest.Enabled = true;
            Modify = true;
            LstTest_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LineOEEMachineMaster_Class_Obj.Mid = Convert.ToInt64(LstTest.SelectedValue.ToString());
                LineOEEMachineMaster_Class_Obj.CreatedBy = FrmMain.LoginID;
                if (LineOEEMachineMaster_Class_Obj.Mid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = LineOEEMachineMaster_Class_Obj.tblLineOEEMachineMaster_Delete();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("sorry You Can't Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Modify = false;
                
            }
        }

       
        
    }
}