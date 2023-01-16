using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Threading;
using System.Globalization;
using QTMS.Tools;


namespace QTMS.Forms
{
    public partial class FrmPMFamilyMaster : System.Windows.Forms.Form
    {
        public FrmPMFamilyMaster()
        {
            InitializeComponent();
        }
        DataSet dsList = new DataSet();

        #region Variables
        bool modify = false;
        PMFamilyMaster_Class PMFamilyMaster_Class_obj = new PMFamilyMaster_Class();
        DimensionParaMaster_Class DimensionParaMaster_Class_obj = new DimensionParaMaster_Class();
        #endregion

        private static FrmPMFamilyMaster frmPMFamilyMaster_Obj = null;
        public static FrmPMFamilyMaster GetInstance()
        {
            if (frmPMFamilyMaster_Obj == null)
            {
                frmPMFamilyMaster_Obj = new Forms.FrmPMFamilyMaster();
            }
            return frmPMFamilyMaster_Obj;
        }

        private void btnPMFamilyExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPMFamilyReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtPMFamilyCDCVersion.Text = "";
            txtPMFamilyCOCFrequency.Text = "";
            txtPMFamilyName.Text = "";
            modify = false;
            btnPMFamilyDelete.Enabled = false;
            for (int i = 0; i < chkLstParameterName.Items.Count; i++)
            {
                chkLstParameterName.SetItemChecked(i, false);
            }
        }

        private void FrmPMFamilyMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_List();
            BindDimensionPara_List();
        }


        private void btnPMFamilyModify_Click(object sender, EventArgs e)
        {
            List_DoubleClick(sender, e);
            modify = true;
        }

        private void btnPMFamilySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPMFamilyName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMFamilyName.Focus();
                    return;

                }
               
                if (txtPMFamilyCOCFrequency.Text.Trim() == "")
                {
                    MessageBox.Show("Enter COC Frequency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMFamilyCOCFrequency.Focus();
                    return;

                }
                if (txtPMFamilyCDCVersion.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Version ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMFamilyCDCVersion.Focus();
                    return;

                }

                PMFamilyMaster_Class_obj.createdby = FrmMain.LoginID;
                PMFamilyMaster_Class_obj.modifiedby = FrmMain.LoginID;
                if (modify == false)
                {
                    PMFamilyMaster_Class_obj.pmfamilyname = txtPMFamilyName.Text.ToString();
                    PMFamilyMaster_Class_obj.cdcversion = txtPMFamilyCDCVersion.Text.ToString();
                    PMFamilyMaster_Class_obj.cocfrequency = Convert.ToInt32(txtPMFamilyCOCFrequency.Text.ToString());
                    PMFamilyMaster_Class_obj.pmfamilyid = PMFamilyMaster_Class_obj.Insert_PMFamilyMaster();
                    
                    for (int i = 0; i < chkLstParameterName.Items.Count; i++)
                    {
                        if (chkLstParameterName.GetItemChecked(i) == true)
                        {
                            chkLstParameterName.SetSelected(i, true);
                            int paraId = Convert.ToInt32(chkLstParameterName.SelectedValue);
                            PMFamilyMaster_Class_obj.dimensionParaID = paraId;
                            PMFamilyMaster_Class_obj.Insert_PMFamilyDimensionParaRelation();
                        }
                    }
                    if (PMFamilyMaster_Class_obj.pmfamilyid > 0)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnPMFamilyReset_Click(sender, e);
                        Bind_List();

                    }
                }
                else
                {
                    if (txtPMFamilyName.Text.ToString() == "")
                    {
                        MessageBox.Show("Family Name cannot be blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPMFamilyName.Focus();
                        return;
                    }
                    PMFamilyMaster_Class_obj.pmfamilyid=Convert.ToInt64(List.SelectedValue.ToString());
                    PMFamilyMaster_Class_obj.pmfamilyname = txtPMFamilyName.Text.ToString();
                    PMFamilyMaster_Class_obj.cdcversion = txtPMFamilyCDCVersion.Text.ToString();
                    PMFamilyMaster_Class_obj.cocfrequency = Convert.ToInt32(txtPMFamilyCOCFrequency.Text.ToString());
                    bool bupdate=PMFamilyMaster_Class_obj.Update_PMFamilyMaster();
                    //first delete the record in tblPMFamilyDimensionParaRelation then insert the record related PM Family
                    PMFamilyMaster_Class_obj.Delete_PMFamilyDimensionParaRelation();
                    for (int i = 0; i < chkLstParameterName.Items.Count; i++)
                    {
                        if (chkLstParameterName.GetItemChecked(i) == true)
                        {
                            chkLstParameterName.SetSelected(i, true);
                            int paraId = Convert.ToInt32(chkLstParameterName.SelectedValue);
                            PMFamilyMaster_Class_obj.dimensionParaID = paraId;
                            PMFamilyMaster_Class_obj.Insert_PMFamilyDimensionParaRelation();
                        }
                    }

                    if (bupdate == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Bind_List();
                        modify = false;
                        btnPMFamilyReset_Click(sender, e);
                    }
                }


            }
            catch 
            {
                MessageBox.Show("Same Family Name Already Exists","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //txtPMFamilyName.Text = "";

            }
        }

        public void Bind_List()
        {
            try
            {
                
                dsList = PMFamilyMaster_Class_obj.Select_PMFamilyMaster();
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "PMFamilyName";
                    List.ValueMember = "PMFamilyID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindDimensionPara_List()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DimensionParaMaster_Class_obj.Select_DimensionParaMaster();
                
                chkLstParameterName.DataSource = dt;
                chkLstParameterName.DisplayMember = "DimensionParaName";
                chkLstParameterName.ValueMember = "DimensionParaID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPMFamilyDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PMFamilyMaster_Class_obj.pmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());

                if (PMFamilyMaster_Class_obj.pmfamilyid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = PMFamilyMaster_Class_obj.Delete_PMFamilyMaster();

                       PMFamilyMaster_Class_obj.Delete_PMFamilyDimensionParaRelation();

                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnPMFamilyReset_Click(sender, e);
                            Bind_List();
                            modify = false;
                            btnPMFamilyDelete.Enabled = false;
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Cannot Delete the Record","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            //txtSearch.Text = Convert.ToString(List.Text);
            DataSet ds = new DataSet();
            PMFamilyMaster_Class_obj.pmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
            ds = PMFamilyMaster_Class_obj.Select_PMFamilyMaster_PMFamilyID();
            txtPMFamilyCDCVersion.Text = ds.Tables[0].Rows[0]["CDCVersion"].ToString();
            txtPMFamilyCOCFrequency.Text = ds.Tables[0].Rows[0]["COCFrequency"].ToString();
            txtPMFamilyName.Text = List.Text.ToString();
            DataTable dt = new DataTable();
            dt = PMFamilyMaster_Class_obj.Select_PMFamilyDimensionParaRelation_PMFamilyID();

            for (int i = 0; i < chkLstParameterName.Items.Count; i++)
            {
                chkLstParameterName.SetItemChecked(i, false);
            }
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < chkLstParameterName.Items.Count; i++)
                {
                    object Items = chkLstParameterName.Items[i];
                    if (Convert.ToInt64((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt32(dr["DimensionParaID"]))
                    {
                        chkLstParameterName.SetItemChecked(i, true);
                    }
                }
            }


            btnPMFamilyDelete.Enabled = true;
        }

        private void txtPMFamilyCOCFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMFamilyName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPMFamilyName.Text = textInfo.ToTitleCase(txtPMFamilyName.Text.Trim());
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "PMFamilyName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "PMFamilyName";
            List.ValueMember = "PMFamilyID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                DataSet ds = new DataSet();
                PMFamilyMaster_Class_obj.pmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = PMFamilyMaster_Class_obj.Select_PMFamilyMaster_PMFamilyID();
                txtPMFamilyCDCVersion.Text = ds.Tables[0].Rows[0]["CDCVersion"].ToString();
                txtPMFamilyCOCFrequency.Text = ds.Tables[0].Rows[0]["COCFrequency"].ToString();
                txtPMFamilyName.Text = List.Text.ToString();
                btnPMFamilyDelete.Enabled = true;
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
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
                //   MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //  MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                DataSet ds = new DataSet();
                PMFamilyMaster_Class_obj.pmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = PMFamilyMaster_Class_obj.Select_PMFamilyMaster_PMFamilyID();
                txtPMFamilyCDCVersion.Text = ds.Tables[0].Rows[0]["CDCVersion"].ToString();
                txtPMFamilyCOCFrequency.Text = ds.Tables[0].Rows[0]["COCFrequency"].ToString();
                txtPMFamilyName.Text = List.Text.ToString();
                btnPMFamilyDelete.Enabled = true;
            }
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

    }
}