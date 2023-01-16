using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmPMTestMaster : System.Windows.Forms.Form
    {
        public FrmPMTestMaster()
        {
            InitializeComponent();
        }
        #region Variables
        bool Modify = false;
        PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class(); 
        #endregion

        DataSet dsList = new DataSet();

        private static FrmPMTestMaster frmPMTestMaster_Obj = null;
        public static FrmPMTestMaster GetInstance()
        {
            if (frmPMTestMaster_Obj == null)
            {
                frmPMTestMaster_Obj = new Forms.FrmPMTestMaster();
            }
            return frmPMTestMaster_Obj;
        }

       

        private void BtnPMTestExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPMTestReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtPMTestName.Text = "";
            txtPMDescription.Text = "";
            chkDimensionTest.Checked = false;
            txtPMTestName.Focus();
            BtnPMTestDelete.Enabled = false;
            Modify = false;
        }

        private void BtnPMTestModify_Click(object sender, EventArgs e)
        {
            Modify = true;
            LstTest_DoubleClick(sender, e);
            
        }

        private void txtPMTestName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPMTestName.Text = textInfo.ToTitleCase(txtPMTestName.Text);
        }

        private void txtPMDescription_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPMDescription.Text = textInfo.ToTitleCase(txtPMDescription.Text);
        }

        private void BtnPMTestSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPMTestName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Test Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPMTestName.Focus();
                    return;

                }
                if (chkDimensionTest.Checked)
                    PMTestMaster_Class_obj.dimensionTest = 1;
                else
                    PMTestMaster_Class_obj.dimensionTest = 0;
                PMTestMaster_Class_obj.createdby = FrmMain.LoginID;
                PMTestMaster_Class_obj.modifiedby = FrmMain.LoginID;
                if (Modify == false)
                {
                    PMTestMaster_Class_obj.testname = txtPMTestName.Text.Trim();
                    PMTestMaster_Class_obj.testdesc = txtPMDescription.Text.Trim();
                    
                    bool b = PMTestMaster_Class_obj.Insert_PMFGTestMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Inserted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnPMTestReset_Click(sender, e);
                        Bind_List();
                    }


                }

                else
                {
                    PMTestMaster_Class_obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    PMTestMaster_Class_obj.testname = txtPMTestName.Text.Trim();
                    PMTestMaster_Class_obj.testdesc = txtPMDescription.Text.Trim();
                    bool b1 = PMTestMaster_Class_obj.Update_PMFGTestMaster_TestNo();
                    if(b1==true)
                    {
                        MessageBox.Show("Record Updated Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        BtnPMTestReset_Click(sender,e);
                        Bind_List();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPMTestMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_List();
        }

        public void Bind_List()
        {
            try
            {
               
                dsList = PMTestMaster_Class_obj.Select_PMFGTestMaster();
                if (dsList.Tables[0].Rows.Count > 0)
                {
                    LstTest.DataSource = dsList.Tables[0];
                    LstTest.DisplayMember = "TestName";
                    LstTest.ValueMember = "TestNo";

                }
                else
                {
                    LstTest.DataSource = dsList.Tables[0];
                    LstTest.DisplayMember = "TestName";
                    LstTest.ValueMember = "TestNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LstTest_DoubleClick(object sender, EventArgs e)
        {
           // txtSearch.Text = Convert.ToString(LstTest.Text);
            DataSet ds = new DataSet();
            txtPMTestName.Text = LstTest.Text.ToString();
            PMTestMaster_Class_obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
            ds=PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();
            txtPMDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();
            if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                    chkDimensionTest.Checked = true;
                else
                    chkDimensionTest.Checked = false;
            }
            else
                chkDimensionTest.Checked = false;

            BtnPMTestDelete.Enabled = true;
        }

        private void BtnPMTestDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (PMTestMaster_Class_obj.testno != 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PMTestMaster_Class_obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                        bool b = PMTestMaster_Class_obj.Delete_PMFGTestMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPMTestName.Text = "";
                            txtPMDescription.Text = "";
                            txtPMTestName.Focus();
                            BtnPMTestDelete.Enabled = false;
                            Bind_List();

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "TestName like  '" + searchString + "%'";
            LstTest.DataSource = dsList.Tables[0];

            LstTest.DisplayMember = "TestName";
            LstTest.ValueMember = "TestNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtSearch.Text = Convert.ToString(LstTest.Text);
                DataSet ds = new DataSet();
                txtPMTestName.Text = LstTest.Text.ToString();
                PMTestMaster_Class_obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();
                txtPMDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();
                BtnPMTestDelete.Enabled = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex + 1;
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
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex - 1;
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

        private void LstTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(LstTest.Text);
                DataSet ds = new DataSet();
                txtPMTestName.Text = LstTest.Text.ToString();
                PMTestMaster_Class_obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();
                txtPMDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();
                BtnPMTestDelete.Enabled = true;
            }
        }

    }
}