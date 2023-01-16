using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using QTMS.Tools;



namespace QTMS.Forms
{
    public partial class FrmFinishedGoodMethodMaster_New : Form
    {
        public FrmFinishedGoodMethodMaster_New()
        {
            InitializeComponent();
        }
        # region Varibles
        FinishedGoodMethodMaster_Class FinishedGoodMethodMaster_Class_Obj = new FinishedGoodMethodMaster_Class();
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = new FGTestMaster_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class(); 
        private bool Flag=true;

        # endregion

        private static FrmFinishedGoodMethodMaster_New frmFinishedGoodMethodMaster_New_Obj = null;
        public static FrmFinishedGoodMethodMaster_New GetInstance()
        {
            if (frmFinishedGoodMethodMaster_New_Obj == null)
            {
                frmFinishedGoodMethodMaster_New_Obj = new FrmFinishedGoodMethodMaster_New();
            }
            return frmFinishedGoodMethodMaster_New_Obj;
        }

        private void FrmFinishedGoodMethodMaster_New_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_PackingFamily();
            Bind_Combo();      
            cmbTestMethod.Text = "--Select--";
            CmbFrequency.Text = "--Select--";
            CmbInspectionMethod.Text = "--Select--";
        }

        public void Fill_dataGridView1()
        {
            dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();            
            ds = FGTestMaster_Class_Obj.Select_FinishGoodDetails_PKGTechNo();
            if (ds.Tables[0].Rows.Count > 0)
            {                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();                    
                    dataGridView1["TestMethod", i].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                    dataGridView1["Fre", i].Value = ds.Tables[0].Rows[i]["Frequency"].ToString();
                    dataGridView1["Ins", i].Value = ds.Tables[0].Rows[i]["InspectionMethod"].ToString();
                    dataGridView1["TestNo", i].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                }
            }
        }

        
        public void Bind_TestCombo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            FGTestMaster_Class_Obj.pkgtechno = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue);
            ds = FGTestMaster_Class_Obj.Select_tblTestMaster_tblFinishGoodDetails();            
            dr = ds.Tables[0].NewRow();
            dr["Test"] = "--Select--";
            dr["TestNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTestMethod.DataSource = ds.Tables[0];
                cmbTestMethod.DisplayMember = "Test";
                cmbTestMethod.ValueMember = "TestNo";
            }
        }
        public void Bind_Combo()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = FGTestMaster_Class_Obj.Select_tblTestMaster_Packing();
            dr = ds.Tables[0].NewRow();
            dr["Test"] = "--Select--";
            dr["TestNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTestMethod.DataSource = ds.Tables[0];
                cmbTestMethod.DisplayMember = "Test";
                cmbTestMethod.ValueMember = "TestNo";

            }
        }
        public void Bind_PackingFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            FGTestMaster_Class_Obj.pkgtechno = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue);
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbPackingTechnicalFamily.DataSource = ds.Tables[0];
                CmbPackingTechnicalFamily.DisplayMember = "TechFamDesc";
                CmbPackingTechnicalFamily.ValueMember = "PKGTechNo";
            }
        }

        private void CmbPackingTechnicalFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BtnReset_Click(sender, e);
            if ((CmbPackingTechnicalFamily.SelectedValue.ToString() != null) && (CmbPackingTechnicalFamily.SelectedValue.ToString() != ""))
            {
                //int i = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue.ToString());
                FGTestMaster_Class_Obj.pkgtechno = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue);
                Fill_dataGridView1();
                Bind_TestCombo();
            }
            else if (CmbPackingTechnicalFamily.Text == "--Select--") 
            {
                dataGridView1.Rows.Clear();
            }

        }


        private void txtAQL_Standard_Normal_TextChanged(object sender, EventArgs e)
            {
            if (txtAQL_Standard_Normal.Text != "")
            {
                txtAQLZ_Standard_Normal.Enabled = false;
                txtAQLZ_Standard_Normal.BackColor = Color.Silver;
                txtAQLC_Standard_Normal.Enabled = false;
                txtAQLC_Standard_Normal.BackColor = Color.Silver;
                txtAQLM_Standard_Normal.Enabled = false;
                txtAQLM_Standard_Normal.BackColor = Color.Silver;
                txtAQLM1_Standard_Normal.Enabled = false;
                txtAQLM1_Standard_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_Standard_Normal.Enabled = true;
                txtAQLZ_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtAQLC_Standard_Normal.Enabled = true;
                txtAQLC_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM_Standard_Normal.Enabled = true;
                txtAQLM_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM1_Standard_Normal.Enabled = true;
                txtAQLM1_Standard_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtAQL_Standard_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtAQL_Standard_Reinforce.Text != "")
            {
                txtAQLZ_Standard_Reinforce.Enabled = false;
                txtAQLZ_Standard_Reinforce.BackColor = Color.Silver;
                txtAQLC_Standard_Reinforce.Enabled = false;
                txtAQLC_Standard_Reinforce.BackColor = Color.Silver;
                txtAQLM_Standard_Reinforce.Enabled = false;
                txtAQLM_Standard_Reinforce.BackColor = Color.Silver;
                txtAQLM1_Standard_Reinforce.Enabled = false;
                txtAQLM1_Standard_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_Standard_Reinforce.Enabled = true;
                txtAQLZ_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLC_Standard_Reinforce.Enabled = true;
                txtAQLC_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM_Standard_Reinforce.Enabled = true;
                txtAQLM_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM1_Standard_Reinforce.Enabled = true;
                txtAQLM1_Standard_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtAQL_80_35000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtAQL_81_35000_Normal.Text != "")
            {
                txtAQLZ_81_35000_Normal.Enabled = false;
                txtAQLZ_81_35000_Normal.BackColor = Color.Silver;
                txtAQLC_81_35000_Normal.Enabled = false;
                txtAQLC_81_35000_Normal.BackColor = Color.Silver;
                txtAQLM_81_35000_Normal.Enabled = false;
                txtAQLM_81_35000_Normal.BackColor = Color.Silver;
                txtAQLM1_81_35000_Normal.Enabled = false;
                txtAQLM1_81_35000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_81_35000_Normal.Enabled = true;
                txtAQLZ_81_35000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLC_81_35000_Normal.Enabled = true;
                txtAQLC_81_35000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM_81_35000_Normal.Enabled = true;
                txtAQLM_81_35000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM1_81_35000_Normal.Enabled = true;
                txtAQLM1_81_35000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtAQL_35001_500000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtAQL_35001_500000_Normal.Text != "")
            {
                txtAQLZ_35001_500000_Normal.Enabled = false;
                txtAQLZ_35001_500000_Normal.BackColor = Color.Silver;
                txtAQLC_35001_500000_Normal.Enabled = false;
                txtAQLC_35001_500000_Normal.BackColor = Color.Silver;
                txtAQLM_35001_500000_Normal.Enabled = false;
                txtAQLM_35001_500000_Normal.BackColor = Color.Silver;
                txtAQLM1_35001_500000_Normal.Enabled = false;
                txtAQLM1_35001_500000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_35001_500000_Normal.Enabled = true;
                txtAQLZ_35001_500000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLC_35001_500000_Normal.Enabled = true;
                txtAQLC_35001_500000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM_35001_500000_Normal.Enabled = true;
                txtAQLM_35001_500000_Normal.BackColor = Color.WhiteSmoke;
                txtAQLM1_35001_500000_Normal.Enabled = true;
                txtAQLM1_35001_500000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtAQL_80_35000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtAQL_81_35000_Reinforce.Text != "")
            {
                txtAQLZ_81_35000_Reinforce.Enabled = false;
                txtAQLZ_81_35000_Reinforce.BackColor = Color.Silver;
                txtAQLC_81_35000_Reinforce.Enabled = false;
                txtAQLC_81_35000_Reinforce.BackColor = Color.Silver;
                txtAQLM_81_35000_Reinforce.Enabled = false;
                txtAQLM_81_35000_Reinforce.BackColor = Color.Silver;
                txtAQLM1_81_35000_Reinforce.Enabled = false;
                txtAQLM1_81_35000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_81_35000_Reinforce.Enabled = true;
                txtAQLZ_81_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLC_81_35000_Reinforce.Enabled = true;
                txtAQLC_81_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM_81_35000_Reinforce.Enabled = true;
                txtAQLM_81_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM1_81_35000_Reinforce.Enabled = true;
                txtAQLM1_81_35000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtAQL_35001_500000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtAQL_35001_500000_Reinforce.Text != "")
            {
                txtAQLZ_35001_500000_Reinforce.Enabled = false;
                txtAQLZ_35001_500000_Reinforce.BackColor = Color.Silver;
                txtAQLC_35001_500000_Reinforce.Enabled = false;
                txtAQLC_35001_500000_Reinforce.BackColor = Color.Silver;
                txtAQLM_35001_500000_Reinforce.Enabled = false;
                txtAQLM_35001_500000_Reinforce.BackColor = Color.Silver;
                txtAQLM1_35001_500000_Reinforce.Enabled = false;
                txtAQLM1_35001_500000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtAQLZ_35001_500000_Reinforce.Enabled = true;
                txtAQLZ_35001_500000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLC_35001_500000_Reinforce.Enabled = true;
                txtAQLC_35001_500000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM_35001_500000_Reinforce.Enabled = true;
                txtAQLM_35001_500000_Reinforce.BackColor = Color.WhiteSmoke;
                txtAQLM1_35001_500000_Reinforce.Enabled = true;
                txtAQLM1_35001_500000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbPackingTechnicalFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select Technical Family", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbPackingTechnicalFamily.Focus();
                    return;
                }

                if (cmbTestMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Test Method", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTestMethod.Focus();
                    return;
                }
                if (CmbFrequency.Text == "--Select--")
                {
                    MessageBox.Show("Select Frequency", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFrequency.Focus();
                    return;
                }
                if (CmbInspectionMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Inspection Method", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbInspectionMethod.Focus();
                    return;
                }
                if (txtSampleSize_81_35000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSampleSize_81_35000_Normal.Focus();
                    return;
                }
                if (txtSampleSize_35001_500000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSampleSize_35001_500000_Normal.Focus();
                    return;
                }

                if (txtSampleSize_81_35000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSampleSize_81_35000_Reinforce.Focus();
                    return;
                }
                if (txtSampleSize_35001_500000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSampleSize_35001_500000_Reinforce.Focus();
                    return;
                }

                if (Flag == true)
                {
                    DataSet ds = new DataSet();
                    FinishedGoodMethodMaster_Class_Obj.pkgTechNo_1 = Convert.ToInt64(CmbPackingTechnicalFamily.SelectedValue);
                    FinishedGoodMethodMaster_Class_Obj.testno_2 = Convert.ToInt32(cmbTestMethod.SelectedValue.ToString());
                    FinishedGoodMethodMaster_Class_Obj.inspectionMethod_3 = CmbInspectionMethod.Text.Trim();
                    ds = FinishedGoodMethodMaster_Class_Obj.Select_Existsin_tblFinishGoodDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Record Exists For \n\nPackingTechnicalFamily - " + CmbPackingTechnicalFamily.Text + "\nTest Method - " + cmbTestMethod.Text + "\nInspection method - " + CmbInspectionMethod.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //DataGrid.Rows.Clear();
                        return;
                    }
                }
                 

                bool b = false;
                for (int i = 0; i < 6; i++)
                {
                    FinishedGoodMethodMaster_Class_Obj.pkgTechNo_1 = Convert.ToInt64(CmbPackingTechnicalFamily.SelectedValue);
                    //FinishedGoodMethodMaster_Class_Obj.testno_2 = Convert.ToInt32(DataGrid[11, i].Value);
                    FinishedGoodMethodMaster_Class_Obj.testno_2 = Convert.ToInt32(cmbTestMethod.SelectedValue.ToString());
                    FinishedGoodMethodMaster_Class_Obj.inspectionMethod_3 = CmbInspectionMethod.Text.Trim();
                    FinishedGoodMethodMaster_Class_Obj.frequency = CmbFrequency.Text.Trim();

                    FinishedGoodMethodMaster_Class_Obj.torquemin = txtMin.Text.Trim();
                    FinishedGoodMethodMaster_Class_Obj.torquemax = txtMax.Text.Trim();
                    
                    if (i == 0)
                    {                        
                        //Normal - Standard 

                        FinishedGoodMethodMaster_Class_Obj.samplesize = 0;

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_Standard_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_Standard_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_Standard_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_Standard_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_Standard_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Normal";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "Standard";
                    }
                    
                    if (i == 1)
                    {
                        //Normal - 81-35000

                        FinishedGoodMethodMaster_Class_Obj.samplesize = Convert.ToInt32(txtSampleSize_81_35000_Normal.Text);

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_81_35000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_81_35000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_81_35000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_81_35000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_81_35000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Normal";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "81-35000";
                    }
                    
                    if (i == 2)
                    {
                        //Normal - 35001-500000

                        FinishedGoodMethodMaster_Class_Obj.samplesize = Convert.ToInt32(txtSampleSize_35001_500000_Normal.Text);

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_35001_500000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_35001_500000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_35001_500000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_35001_500000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_35001_500000_Normal.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Normal";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "35001-500000";
                    }
                   
                    if (i == 3)
                    {
                        //reinforce - Standard 

                        FinishedGoodMethodMaster_Class_Obj.samplesize = 0;

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_Standard_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_Standard_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_Standard_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_Standard_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_Standard_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Reinforce";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "Standard";
                    }
                   
                    if (i == 4)
                    {
                        //reinforce - 81-35000

                        FinishedGoodMethodMaster_Class_Obj.samplesize = Convert.ToInt32(txtSampleSize_81_35000_Reinforce.Text);

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_81_35000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_81_35000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_81_35000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_81_35000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_81_35000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Reinforce";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "81-35000";
                    }                   

                    if (i == 5)
                    {

                        //reinforce - 35001-500000

                        FinishedGoodMethodMaster_Class_Obj.samplesize = Convert.ToInt32(txtSampleSize_35001_500000_Reinforce.Text);

                        FinishedGoodMethodMaster_Class_Obj.aql = Convert.ToString(txtAQL_35001_500000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlz = Convert.ToString(txtAQLZ_35001_500000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlc = Convert.ToString(txtAQLC_35001_500000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm = Convert.ToString(txtAQLM_35001_500000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.aqlm1 = Convert.ToString(txtAQLM1_35001_500000_Reinforce.Text);
                        FinishedGoodMethodMaster_Class_Obj.type_11 = "Reinforce";

                        FinishedGoodMethodMaster_Class_Obj.lotsize_12 = "35001-500000";
                    }
                    if (Flag == true)
                    {
                        b = FinishedGoodMethodMaster_Class_Obj.Insert_tblFinishedGoodMethodMaster();
                    }
                    else
                    {
                        b = FinishedGoodMethodMaster_Class_Obj.Update_tblFinishedGoodMethodMaster();
                    }
                }



                if (b == true)
                {
                    if (Flag == true)
                    {
                        MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record Modified Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    BtnReset_Click(sender, e);

                    Fill_dataGridView1();                       
                    
                }
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                CmbPackingTechnicalFamily.Focus();
                //CmbPackingTechnicalFamily.Text = "--Select--";
                cmbTestMethod.Text = "--Select--";
                CmbFrequency.Text = "--Select--";
                CmbInspectionMethod.Text = "--Select--";
                //dataGridView1.Rows.Clear();
                Clear_Text();               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clear_Text();

            if (dataGridView1.Rows.Count > 0)
            {
                 FGTestMaster_Class_Obj = new FGTestMaster_Class();
                if ((CmbPackingTechnicalFamily.SelectedValue != null) && (CmbPackingTechnicalFamily.SelectedValue.ToString()!=""))
                {
                    FGTestMaster_Class_Obj.pkgtechno = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    FGTestMaster_Class_Obj.testname = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    cmbTestMethod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //FGTestMaster_Class_Obj.testno = Convert.ToInt64(cmbTestMethod.SelectedValue);
                    cmbTestMethod_SelectionChangeCommitted(sender, e);
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    FGTestMaster_Class_Obj.frequency = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    CmbFrequency.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    CmbInspectionMethod.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    FGTestMaster_Class_Obj.testno = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                }
                DataSet ds = new DataSet();
                ds = FGTestMaster_Class_Obj.Select_FinisnedGoodDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (ds.Tables[0].Rows[i]["TorqueMin"] is System.DBNull)
                        {
                            
                        }
                        else
                        {                            
                            txtMin.Text = ds.Tables[0].Rows[i]["TorqueMin"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["TorqueMax"] is System.DBNull)
                        {
                            
                        }
                        else
                        {                            
                            txtMax.Text = ds.Tables[0].Rows[i]["TorqueMax"].ToString();
                        }

                        //---------Normal--------------------
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString()=="Standard")
                        {                            
                            txtAQL_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "81-35000")
                        {
                            txtSampleSize_81_35000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtAQL_81_35000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_81_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_81_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_81_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_81_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if(ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "35001-500000")
                        {
                            txtSampleSize_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtAQL_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_35001_500000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }

                        //---------Reinforce--------------------

                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "Standard")
                        {
                            txtAQL_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "81-35000")
                        {
                            txtSampleSize_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtAQL_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_81_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }

                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "35001-500000")
                        {
                            txtSampleSize_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtAQL_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtAQLZ_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtAQLC_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtAQLM_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtAQLM1_35001_500000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                    }
                }
            }  

        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_Combo();
                CmbFrequency.Text = "--Select--";
                CmbInspectionMethod.Text = "--Select--";

                Clear_Text();

                //for add 
                Flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                if ((CmbPackingTechnicalFamily.SelectedValue.ToString() != null) && (CmbPackingTechnicalFamily.SelectedValue.ToString() != ""))
                {
                    Bind_TestCombo();
                }

                //Clear_Text();

                //for modify
                Flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbPackingTechnicalFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select Technical Family", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbPackingTechnicalFamily.Focus();
                    return;
                }
                if (cmbTestMethod.Text == "--Select--" || CmbFrequency.Text == "--Select--" || CmbInspectionMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Record", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Focus();
                    return;
                }             

                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FGTestMaster_Class_Obj.del = 1;

                    //bool b = FGTestMaster_Class_Obj.Delete_FinisnedGoodDetails();
                    bool b = FGTestMaster_Class_Obj.Update_tblFinishGoodDetails_Del();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Fill_dataGridView1();                       
                        BtnReset_Click(sender, e);                 
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear_Text()
        {
            // ------Clear Text--------
            txtAQL_Standard_Normal.Text = "";
            txtAQLZ_Standard_Normal.Text="";
            txtAQLC_Standard_Normal.Text = "";
            txtAQLM_Standard_Normal.Text = "";
            txtAQLM1_Standard_Normal.Text = "";

            txtSampleSize_81_35000_Normal.Text = "";
            txtAQL_81_35000_Normal.Text = "";
            txtAQLZ_81_35000_Normal.Text = "";
            txtAQLC_81_35000_Normal.Text = "";
            txtAQLM_81_35000_Normal.Text = "";
            txtAQLM1_81_35000_Normal.Text = "";

            txtSampleSize_35001_500000_Normal.Text = "";
            txtAQL_35001_500000_Normal.Text = "";
            txtAQLZ_35001_500000_Normal.Text = "";
            txtAQLC_35001_500000_Normal.Text = "";
            txtAQLM_35001_500000_Normal.Text = "";
            txtAQLM1_35001_500000_Normal.Text = "";

            txtAQL_Standard_Reinforce.Text = "";
            txtAQLZ_Standard_Reinforce.Text = "";
            txtAQLC_Standard_Reinforce.Text = "";
            txtAQLM_Standard_Reinforce.Text = "";
            txtAQLM1_Standard_Reinforce.Text = "";

            txtSampleSize_81_35000_Reinforce.Text = "";
            txtAQL_81_35000_Reinforce.Text = "";
            txtAQLZ_81_35000_Reinforce.Text = "";
            txtAQLC_81_35000_Reinforce.Text = "";
            txtAQLM_81_35000_Reinforce.Text = "";
            txtAQLM1_81_35000_Reinforce.Text = "";

            txtSampleSize_35001_500000_Reinforce.Text = "";
            txtAQL_35001_500000_Reinforce.Text = "";
            txtAQLZ_35001_500000_Reinforce.Text = "";
            txtAQLC_35001_500000_Reinforce.Text = "";
            txtAQLM_35001_500000_Reinforce.Text = "";
            txtAQLM1_35001_500000_Reinforce.Text = "";

            txtMin.Text = "";
            txtMax.Text = "";

        }

        #region "KeyPress events of text boxes"

        private void txtAQL_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtSampleSize_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQL_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_80_35000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtSampleSize_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQL_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_35001_500000_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQL_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtSampleSize_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQL_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_80_35000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtSampleSize_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQL_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLZ_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLC_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtAQLM1_35001_500000_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        #endregion 

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void cmbTestMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                DataSet ds = new DataSet();
                TestMaster_Class_Obj.testno = Convert.ToInt32(cmbTestMethod.SelectedValue);
                ds = TestMaster_Class_Obj.Select_tblWAMethodType_TestNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["AnalysisType"].ToString() == "Torque")
                        {
                            txtMin.Enabled = true;
                            txtMin.BackColor = Color.White;
                            txtMax.Enabled = true;
                            txtMax.BackColor = Color.White;
                            break;
                        }
                        else
                        {
                            txtMin.Enabled = false;
                            txtMin.BackColor = Color.Silver;
                            txtMax.Enabled = false;
                            txtMax.BackColor = Color.Silver;
                        }
                    }
                }
                else
                {
                    txtMin.Enabled = false;
                    txtMin.BackColor = Color.Silver;
                    txtMax.Enabled = false;
                    txtMax.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
       
    }
}