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
    public partial class FrmPackingFamilyMaster : Form
    {
        DataSet dsList = new DataSet();
        public FrmPackingFamilyMaster()
        {
            InitializeComponent();
        }

        #region Varibles
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        bool Modify = false;
        #endregion

        private static FrmPackingFamilyMaster frmPackingFamilyMaster_Obj = null;
        public static FrmPackingFamilyMaster GetInstance()
        {
            if (frmPackingFamilyMaster_Obj == null)
            {
                frmPackingFamilyMaster_Obj = new FrmPackingFamilyMaster();
            }
            return frmPackingFamilyMaster_Obj;
        }

        private void FrmPackingFamilyMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            txtTechnicalFamily.Focus();
            Bind_List();
            CmbType.Text = "--Select--";
        }
        public void Bind_List()
        {

            dsList = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "TechFamDesc";
            List.ValueMember = "PKGTechNo";            
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTechnicalFamily.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Family Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTechnicalFamily.Focus();
                    return;

                }
                if (CmbType.Text == "--Select--")
                {
                    MessageBox.Show("Enter Type Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbType.Focus();
                    return;

                }
                if (txtVersionNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Version No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVersionNo.Focus();
                    return;

                }
                if (Modify == false)
                {
                    PackingFamilyMaster_Class_Obj.techfamdesc = txtTechnicalFamily.Text.Trim();
                    PackingFamilyMaster_Class_Obj.type = CmbType.Text;
                    PackingFamilyMaster_Class_Obj.versionno = txtVersionNo.Text.Trim();
                    bool b = PackingFamilyMaster_Class_Obj.Insert_tblPkgFamilyMaster();
                    if (b == true)
                    {   
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                else
                {
                    PackingFamilyMaster_Class_Obj.techfamdesc = txtTechnicalFamily.Text.Trim();
                    PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(List.SelectedValue.ToString());
                    PackingFamilyMaster_Class_Obj.type = CmbType.Text;
                    PackingFamilyMaster_Class_Obj.versionno = txtVersionNo.Text.Trim();
                    if (PackingFamilyMaster_Class_Obj.pkgtechno == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = PackingFamilyMaster_Class_Obj.Update_tblPkgFamilyMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                BtnReset_Click(sender, e);
                
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //  txtSearch.Text = Convert.ToString(List.Text);
                //Modify = true;
                DataSet ds = new DataSet();
                PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(List.SelectedValue.ToString());
                ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTechnicalFamily.Text = List.Text;
                    CmbType.Text = ds.Tables[0].Rows[0]["pktype"].ToString();
                    txtVersionNo.Text = ds.Tables[0].Rows[0]["VersionNo"].ToString();
                    BtnDelete.Enabled = true;
                }
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
				PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(List.SelectedValue.ToString());
                if (PackingFamilyMaster_Class_Obj.pkgtechno > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = PackingFamilyMaster_Class_Obj.Delete_tblPkgFamilyMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            BtnReset_Click(sender,e);
                        }
                    }
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry You Can't Delete This Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            PackingFamilyMaster_Class_Obj.pkgtechno = 0;
            txtTechnicalFamily.Text = "";
            CmbType.Text = "--Select--";
            txtVersionNo.Text = "";
            txtTechnicalFamily.Focus();
            BtnDelete.Enabled = false;
            Modify = false;            
            Bind_List();
        }

        private void txtTechnicalFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Only 0-9 and a-z and A-Z allowed
            //if (e.KeyChar != Convert.ToChar(8))
            //{
            //    if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //    {

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txtTechnicalFamily_Leave(object sender, EventArgs e)
        {

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTechnicalFamily.Text = textInfo.ToTitleCase(txtTechnicalFamily.Text);	

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "TechFamDesc like  '" + searchString + "%'  ";

            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "TechFamDesc";
            List.ValueMember = "PKGTechNo";   
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    //Modify = true;
                    DataSet ds = new DataSet();
                    PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTechnicalFamily.Text = List.Text;
                        CmbType.Text = ds.Tables[0].Rows[0]["pktype"].ToString();
                        txtVersionNo.Text = ds.Tables[0].Rows[0]["VersionNo"].ToString();
                        BtnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
  
            try
            {
            if (e.KeyCode == Keys.Down)
            {
                List.Select();
                List.SelectedIndex = List.SelectedIndex + 1;
            }
            }
            catch(ArgumentOutOfRangeException exAOR)
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
                List.Select();
                List.SelectedIndex = List.SelectedIndex - 1;
            }
        }
        catch (ArgumentOutOfRangeException exAOR)
        {

            MessageBox.Show("This is last item", "QTMS");
        }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    //Modify = true;
                    DataSet ds = new DataSet();
                    PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTechnicalFamily.Text = List.Text;
                        CmbType.Text = ds.Tables[0].Rows[0]["pktype"].ToString();
                        txtVersionNo.Text = ds.Tables[0].Rows[0]["VersionNo"].ToString();
                        BtnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            try
            {
                PackingFamilyMaster_Class objPackingFamilyMaster_Class = new PackingFamilyMaster_Class();
                DataSet ds = new DataSet();
                ds = objPackingFamilyMaster_Class.Select_All_Record_tblPkgFamilyMaster();
               
                 ExportToExcel objExport = new ExportToExcel();
                 objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}