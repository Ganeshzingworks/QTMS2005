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

namespace QTMS.Forms
{
    
    public partial class FrmLineOEEFGMaster : Form
    {
        public FrmLineOEEFGMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        bool Modify = false;
        public bool SaveAs = false;
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        LineOEEFGMaster_Class LineOEEFGMaster_Class_Obj = new LineOEEFGMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        FGGlobalFamilyMaster_Class FGGlobalFamilyMaster_Class_Obj = new FGGlobalFamilyMaster_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = null;
        # endregion

        private static FrmLineOEEFGMaster FrmLineOEEFGMaster_Obj = null;
        public static FrmLineOEEFGMaster GetInstance()
        {
            if(FrmLineOEEFGMaster_Obj ==null)
            {
                FrmLineOEEFGMaster_Obj = new FrmLineOEEFGMaster();
            }
            return FrmLineOEEFGMaster_Obj;
        }

        private void FrmLineOEEFGMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);

                Bind_List();
                Bind_Combo();                
                //Bind_FGGlobalFamily();                
                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        public void Bind_List()
        {
            DataSet ds = new DataSet();
            ds = LineOEEFGMaster_Class_Obj.Select_From_tblLineOEEFGMaster();
            List.DataSource = ds.Tables[0];
            List.DisplayMember = "FGCode";
            List.ValueMember = "FGNo";                     
        }

        public void Bind_Combo()
        {

            DataSet ds = new DataSet();
            DataRow dr;
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTechnicalFamily.DataSource = ds.Tables[0];
                cmbTechnicalFamily.DisplayMember = "TechFamDesc";
                cmbTechnicalFamily.ValueMember = "PKGTechNo";
            }
        }      

       

        public void Bind_FGGlobalFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FGGlobalFamilyMaster_Class_Obj.Select_FGGlobalFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["FGGlobalFamilyName"] = "--Select--";
            dr["FGGlobalFamilyID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
           
            cmbFGGlobalFamily.DataSource = ds.Tables[0];
            cmbFGGlobalFamily.DisplayMember = "FGGlobalFamilyName";
            cmbFGGlobalFamily.ValueMember = "FGGlobalFamilyID";            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
            if (txtFgCode.Text.Trim() == "")
            {
                MessageBox.Show("Enter Fg Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFgCode.Text = "";
                txtFgCode.Focus();
                return false;
            }
            if (txtFgDesc.Text.Trim() == "")
            {
                MessageBox.Show("Enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFgDesc.Text = "";
                txtFgDesc.Focus();
                return false;
            }
            //if (txtFillVolume.Text == "")
            //{
            //    MessageBox.Show("Enter Fill Volume", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFillVolume.Focus();
            //    return false;
            //}

            //if (cmbFGGlobalFamily.SelectedValue == null || cmbFGGlobalFamily.Text == "--Select--")
            //{
            //    MessageBox.Show("Select FG Global Family", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmbFGGlobalFamily.Focus();
            //    return false;
            //}
            if (cmbTechnicalFamily.SelectedValue == null || cmbTechnicalFamily.Text == "--Select--")
            {
                MessageBox.Show("Select Technical Family", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTechnicalFamily.Focus();
                return false;
            }
            

           
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    if (Modify == false)
                    {
                        #region Common to SF and Kit
                        // check FGCode is already exist or not
                        LineOEEFGMaster_Class_Obj.fgcode = txtFgCode.Text.Trim();
                        DataSet ds = new DataSet();
                        ds = LineOEEFGMaster_Class_Obj.Select_From_tblLineOEEFGMaster_By_FGCode();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("FG Code Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFgCode.Focus();
                            return;
                        }

                        LineOEEFGMaster_Class_Obj.fgdesc = txtFgDesc.Text.Trim();
                        LineOEEFGMaster_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                        LineOEEFGMaster_Class_Obj.pkgtechno = Convert.ToInt32(cmbTechnicalFamily.SelectedValue);
                        //LineOEEFGMaster_Class_Obj.fgglobalfamilyid = Convert.ToInt32(cmbFGGlobalFamily.SelectedValue);
                        LineOEEFGMaster_Class_Obj.wip = 0;


                                               
                        LineOEEFGMaster_Class_Obj.fgno = 0;
                        LineOEEFGMaster_Class_Obj.fgno = LineOEEFGMaster_Class_Obj.Insert_tblLineOEEFGMaster();

                        
                        #endregion       
                
                 
 
                        MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        BtnReset_Click(sender, e);
                    

                    }
                    else
                    {
                        // Update Code
                        LineOEEFGMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                        LineOEEFGMaster_Class_Obj.result = Convert.ToInt64(List.SelectedValue.ToString());
                        LineOEEFGMaster_Class_Obj.fgcode = txtFgCode.Text.Trim();
                        LineOEEFGMaster_Class_Obj.fgdesc = txtFgDesc.Text.Trim();
                        LineOEEFGMaster_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                        LineOEEFGMaster_Class_Obj.pkgtechno = Convert.ToInt32(cmbTechnicalFamily.SelectedValue);
                       // LineOEEFGMaster_Class_Obj.fgglobalfamilyid = Convert.ToInt32(cmbFGGlobalFamily.SelectedValue);                        


                        //FGTestMaster_Class_Obj.fgno = LineOEEFGMaster_Class_Obj.fgno;
                        //FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelation();

                        //foreach (DataGridViewRow row in dgTest.Rows)
                        //{
                        //    if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                        //    {
                        //        FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);
                        //        //FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();
                        //    }
                        //}

                        bool b = false;
                        if (MessageBox.Show("Modify this Record ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        { 
                            b = LineOEEFGMaster_Class_Obj.Update_tblLineOEEFGMaster();                            
                        }

                        if (b == true)
                        {                           
                            MessageBox.Show("Record Update Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            txtFgCode.Enabled = true;
                            BtnReset_Click(sender, e);
                        }
                    }
                    Bind_List();
                    SaveAs = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFgCode.Focus();
                Modify = false;
                SaveAs = false;
            }
        }

               

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Modify = false;
            Reset();
            //txtFgCode.Focus();
        }

        private void Reset()
        {
            SaveAs = false;
            BtnDelete.Enabled = false;
            txtFgCode.Text = "";
            txtFillVolume.Text = "";
            txtFgCode.Enabled = true;
            cmbTechnicalFamily.Text = "--Select--";
            cmbFGGlobalFamily.Text = "--Select--";
            txtFgDesc.Text = "";
            
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            txtFgCode.Enabled = false;
            List.Enabled = true;            
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Reset();                
                if (List.SelectedValue == null)
                {
                    return;
                }               

                DataSet ds = new DataSet();
                LineOEEFGMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                ds = LineOEEFGMaster_Class_Obj.STP_SELECT_tblLineOEEFGMaster_FGNo();

                txtFgCode.Text = List.Text;
                txtFgDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();

                PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);
                cmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);

                //if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                //{
                //    cmbFGGlobalFamily.SelectedValue = 0;
                //}
                //else
                //{
                //    cmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                //}

                BtnDelete.Enabled = true;
            }
    
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LineOEEFGMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                if (LineOEEFGMaster_Class_Obj.fgno == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //first delete 
                    LineOEEFGMaster_Class_Obj.Delete_tblLineOEEFGMaster();

                    //We have to clear both tables tblFGLinkSF and tblLineOEEFGMaster                   
                    MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnReset_Click(sender, e);
                    BtnDelete.Enabled = false;
                    Bind_List();
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Modify = false;
                txtFgCode.Focus();
            }
        }

        private void txtFgCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }            
        }
    

        private void txtFgCode_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFgCode.Text = textInfo.ToTitleCase(txtFgCode.Text);
        }

        private void txtFgDesc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFgDesc.Text = textInfo.ToTitleCase(txtFgDesc.Text);
        }

        private void txtFillVolume_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFillVolume.Text = textInfo.ToTitleCase(txtFillVolume.Text);
        }
        
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            SaveAs = true;
            List_DoubleClick(sender, e); 
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }
    
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                List_DoubleClick(sender, e);
        }

       

      
    }
}