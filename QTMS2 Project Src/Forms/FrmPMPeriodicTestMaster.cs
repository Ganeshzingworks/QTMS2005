using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmPMTestMethodMaster : System.Windows.Forms.Form
    {
        public FrmPMTestMethodMaster()
        {
            InitializeComponent();
        }

        #region Variables
        PMFamilyMaster_Class PMFamilyMaster_Class_obj = new PMFamilyMaster_Class();
        PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class();
        PMPeriodicTestMaster_Class PMPeriodicTestMaster_Class_obj=new PMPeriodicTestMaster_Class();
        private bool Flag = true;
        #endregion

        private static FrmPMTestMethodMaster frmPMTestMethodMaster_Obj = null;

        public static FrmPMTestMethodMaster GetInstance()
        {
            if (frmPMTestMethodMaster_Obj == null)
            {
                frmPMTestMethodMaster_Obj = new Forms.FrmPMTestMethodMaster();
            }
            return frmPMTestMethodMaster_Obj;
        }

        private void FrmPMPeriodicTestMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_PackingFamily();
            Bind_Combo();
            CmbPMFrequency.Text = "--Select--";
            CmbPMInspectionMethod.Text = "--Select--";
        }

        public void Bind_PackingFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;

            ds = PMFamilyMaster_Class_obj.Select_PMFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["PMFamilyName"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbPMFamily.DataSource = ds.Tables[0];
                CmbPMFamily.DisplayMember = "PMFamilyName";
                CmbPMFamily.ValueMember = "PMFamilyID";
            }
        }

        public void Bind_Combo()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = PMTestMaster_Class_obj.Select_PMFGTestMaster();
            dr = ds.Tables[0].NewRow();
            dr["TestName"] = "--Select--";
            dr["TestNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbPMTestMethod.DataSource = ds.Tables[0];
                cmbPMTestMethod.DisplayMember = "TestName";
                cmbPMTestMethod.ValueMember = "TestNo";

            }
        }

        public void Clear_Text()
        {
            // ------Clear Text--------
            txtPMAQL_Standard_Normal.Text = "";
            txtPMAQLZ_Standard_Normal.Text = "";
            txtPMAQLC_Standard_Normal.Text = "";
            txtPMAQLM_Standard_Normal.Text = "";
            txtPMAQLM1_Standard_Normal.Text = "";

            txtPMSampleSize_501_1200_Normal.Text = "";
            txtPMAQL_501_1200_Normal.Text = "";
            txtPMAQLZ_501_1200_Normal.Text = "";
            txtPMAQLC_501_1200_Normal.Text = "";
            txtPMAQLM_501_1200_Normal.Text = "";
            txtPMAQLM1_501_1200_Normal.Text = "";

            txtPMSampleSize_1201_3200_Normal.Text = "";
            txtPMAQL_1201_3200_Normal.Text = "";
            txtPMAQLZ_1201_3200_Normal.Text = "";
            txtPMAQLC_1201_3200_Normal.Text = "";
            txtPMAQLM_1201_3200_Normal.Text = "";
            txtPMAQLM1_1201_3200_Normal.Text = "";

            txtPMSampleSize_3201_10000_Normal.Text = "";
            txtPMAQL_3201_10000_Normal.Text = "";
            txtPMAQLZ_3201_10000_Normal.Text = "";
            txtPMAQLC_3201_10000_Normal.Text = "";
            txtPMAQLM_3201_10000_Normal.Text = "";
            txtPMAQLM1_3201_10000_Normal.Text = "";

            txtPMSampleSize_10001_35000_Normal.Text = "";
            txtPMAQL_10001_35000_Normal.Text = "";
            txtPMAQLZ_10001_35000_Normal.Text = "";
            txtPMAQLC_10001_35000_Normal.Text = "";
            txtPMAQLM_10001_35000_Normal.Text = "";
            txtPMAQLM1_10001_35000_Normal.Text = "";

            txtPMSampleSize_35001_150000_Normal.Text = "";
            txtPMAQL_35001_150000_Normal.Text = "";
            txtPMAQLZ_35001_150000_Normal.Text = "";
            txtPMAQLC_35001_150000_Normal.Text = "";
            txtPMAQLM_35001_150000_Normal.Text = "";
            txtPMAQLM1_35001_150000_Normal.Text = "";

            txtPMSampleSize_150001_5000000_Normal.Text = "";
            txtPMAQL_150001_5000000_Normal.Text = "";
            txtPMAQLZ_150001_5000000_Normal.Text = "";
            txtPMAQLC_150001_5000000_Normal.Text = "";
            txtPMAQLM_150001_5000000_Normal.Text = "";
            txtPMAQLM1_150001_5000000_Normal.Text = "";

            txtPMAQL_Standard_Reinforce.Text = "";
            txtPMAQLZ_Standard_Reinforce.Text = "";
            txtPMAQLC_Standard_Reinforce.Text = "";
            txtPMAQLM_Standard_Reinforce.Text = "";
            txtPMAQLM1_Standard_Reinforce.Text = "";

            txtPMSampleSize_501_1200_Reinforce.Text = "";
            txtPMAQL_501_1200_Reinforce.Text = "";
            txtPMAQLZ_501_1200_Reinforce.Text = "";
            txtPMAQLC_501_1200_Reinforce.Text = "";
            txtPMAQLM_501_1200_Reinforce.Text = "";
            txtPMAQLM1_501_1200_Reinforce.Text = "";

            txtPMSampleSize_1201_3200_Reinforce.Text = "";
            txtPMAQL_1201_3200_Reinforce.Text = "";
            txtPMAQLZ_1201_3200_Reinforce.Text = "";
            txtPMAQLC_1201_3200_Reinforce.Text = "";
            txtPMAQLM_1201_3200_Reinforce.Text = "";
            txtPMAQLM1_1201_3200_Reinforce.Text = "";

            txtPMSampleSize_3201_10000_Reinforce.Text = "";
            txtPMAQL_3201_10000_Reinforce.Text = "";
            txtPMAQLZ_3201_10000_Reinforce.Text = "";
            txtPMAQLC_3201_10000_Reinforce.Text = "";
            txtPMAQLM_3201_10000_Reinforce.Text = "";
            txtPMAQLM1_3201_10000_Reinforce.Text = "";

            txtPMSampleSize_10001_35000_Reinforce.Text = "";
            txtPMAQL_10001_35000_Reinforce.Text = "";
            txtPMAQLZ_10001_35000_Reinforce.Text = "";
            txtPMAQLC_10001_35000_Reinforce.Text = "";
            txtPMAQLM_10001_35000_Reinforce.Text = "";
            txtPMAQLM1_10001_35000_Reinforce.Text = "";

            txtPMSampleSize_35001_150000_Reinforce.Text = "";
            txtPMAQL_35001_150000_Reinforce.Text = "";
            txtPMAQLZ_35001_150000_Reinforce.Text = "";
            txtPMAQLC_35001_150000_Reinforce.Text = "";
            txtPMAQLM_35001_150000_Reinforce.Text = "";
            txtPMAQLM1_35001_150000_Reinforce.Text = "";

            txtPMSampleSize_150001_5000000_Reinforce.Text = "";
            txtPMAQL_150001_5000000_Reinforce.Text = "";
            txtPMAQLZ_150001_5000000_Reinforce.Text = "";
            txtPMAQLC_150001_5000000_Reinforce.Text = "";
            txtPMAQLM_150001_5000000_Reinforce.Text = "";
            txtPMAQLM1_150001_5000000_Reinforce.Text = "";
        }

        private void txtPMAQL_Standard_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_Standard_Normal.Text != "")
            {
                txtPMAQLZ_Standard_Normal.Enabled = false;
                txtPMAQLZ_Standard_Normal.BackColor = Color.Silver;
                txtPMAQLC_Standard_Normal.Enabled = false;
                txtPMAQLC_Standard_Normal.BackColor = Color.Silver;
                txtPMAQLM_Standard_Normal.Enabled = false;
                txtPMAQLM_Standard_Normal.BackColor = Color.Silver;
                txtPMAQLM1_Standard_Normal.Enabled = false;
                txtPMAQLM1_Standard_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_Standard_Normal.Enabled = true;
                txtPMAQLZ_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_Standard_Normal.Enabled = true;
                txtPMAQLC_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_Standard_Normal.Enabled = true;
                txtPMAQLM_Standard_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_Standard_Normal.Enabled = true;
                txtPMAQLM1_Standard_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_501_1200_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_501_1200_Normal.Text != "")
            {
                txtPMAQLZ_501_1200_Normal.Enabled = false;
                txtPMAQLZ_501_1200_Normal.BackColor = Color.Silver;
                txtPMAQLC_501_1200_Normal.Enabled = false;
                txtPMAQLC_501_1200_Normal.BackColor = Color.Silver;
                txtPMAQLM_501_1200_Normal.Enabled = false;
                txtPMAQLM_501_1200_Normal.BackColor = Color.Silver;
                txtPMAQLM1_501_1200_Normal.Enabled = false;
                txtPMAQLM1_501_1200_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_501_1200_Normal.Enabled = true;
                txtPMAQLZ_501_1200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_501_1200_Normal.Enabled = true;
                txtPMAQLC_501_1200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_501_1200_Normal.Enabled = true;
                txtPMAQLM_501_1200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_501_1200_Normal.Enabled = true;
                txtPMAQLM1_501_1200_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_1201_3200_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_1201_3200_Normal.Text != "")
            {
                txtPMAQLZ_1201_3200_Normal.Enabled = false;
                txtPMAQLZ_1201_3200_Normal.BackColor = Color.Silver;
                txtPMAQLC_1201_3200_Normal.Enabled = false;
                txtPMAQLC_1201_3200_Normal.BackColor = Color.Silver;
                txtPMAQLM_1201_3200_Normal.Enabled = false;
                txtPMAQLM_1201_3200_Normal.BackColor = Color.Silver;
                txtPMAQLM1_1201_3200_Normal.Enabled = false;
                txtPMAQLM1_1201_3200_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_1201_3200_Normal.Enabled = true;
                txtPMAQLZ_1201_3200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_1201_3200_Normal.Enabled = true;
                txtPMAQLC_1201_3200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_1201_3200_Normal.Enabled = true;
                txtPMAQLM_1201_3200_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_1201_3200_Normal.Enabled = true;
                txtPMAQLM1_1201_3200_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_3201_10000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_3201_10000_Normal.Text != "")
            {
                txtPMAQLZ_3201_10000_Normal.Enabled = false;
                txtPMAQLZ_3201_10000_Normal.BackColor = Color.Silver;
                txtPMAQLC_3201_10000_Normal.Enabled = false;
                txtPMAQLC_3201_10000_Normal.BackColor = Color.Silver;
                txtPMAQLM_3201_10000_Normal.Enabled = false;
                txtPMAQLM_3201_10000_Normal.BackColor = Color.Silver;
                txtPMAQLM1_3201_10000_Normal.Enabled = false;
                txtPMAQLM1_3201_10000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_3201_10000_Normal.Enabled = true;
                txtPMAQLZ_3201_10000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_3201_10000_Normal.Enabled = true;
                txtPMAQLC_3201_10000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_3201_10000_Normal.Enabled = true;
                txtPMAQLM_3201_10000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_3201_10000_Normal.Enabled = true;
                txtPMAQLM1_3201_10000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_10001_35000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_10001_35000_Normal.Text != "")
            {
                txtPMAQLZ_10001_35000_Normal.Enabled = false;
                txtPMAQLZ_10001_35000_Normal.BackColor = Color.Silver;
                txtPMAQLC_10001_35000_Normal.Enabled = false;
                txtPMAQLC_10001_35000_Normal.BackColor = Color.Silver;
                txtPMAQLM_10001_35000_Normal.Enabled = false;
                txtPMAQLM_10001_35000_Normal.BackColor = Color.Silver;
                txtPMAQLM1_10001_35000_Normal.Enabled = false;
                txtPMAQLM1_10001_35000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_10001_35000_Normal.Enabled = true;
                txtPMAQLZ_10001_35000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_10001_35000_Normal.Enabled = true;
                txtPMAQLC_10001_35000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_10001_35000_Normal.Enabled = true;
                txtPMAQLM_10001_35000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_10001_35000_Normal.Enabled = true;
                txtPMAQLM1_10001_35000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_35001_150000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_35001_150000_Normal.Text != "")
            {
                txtPMAQLZ_35001_150000_Normal.Enabled = false;
                txtPMAQLZ_35001_150000_Normal.BackColor = Color.Silver;
                txtPMAQLC_35001_150000_Normal.Enabled = false;
                txtPMAQLC_35001_150000_Normal.BackColor = Color.Silver;
                txtPMAQLM_35001_150000_Normal.Enabled = false;
                txtPMAQLM_35001_150000_Normal.BackColor = Color.Silver;
                txtPMAQLM1_35001_150000_Normal.Enabled = false;
                txtPMAQLM1_35001_150000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_35001_150000_Normal.Enabled = true;
                txtPMAQLZ_35001_150000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_35001_150000_Normal.Enabled = true;
                txtPMAQLC_35001_150000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_35001_150000_Normal.Enabled = true;
                txtPMAQLM_35001_150000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_35001_150000_Normal.Enabled = true;
                txtPMAQLM1_35001_150000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_150001_5000000_Normal_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_150001_5000000_Normal.Text != "")
            {
                txtPMAQLZ_150001_5000000_Normal.Enabled = false;
                txtPMAQLZ_150001_5000000_Normal.BackColor = Color.Silver;
                txtPMAQLC_150001_5000000_Normal.Enabled = false;
                txtPMAQLC_150001_5000000_Normal.BackColor = Color.Silver;
                txtPMAQLM_150001_5000000_Normal.Enabled = false;
                txtPMAQLM_150001_5000000_Normal.BackColor = Color.Silver;
                txtPMAQLM1_150001_5000000_Normal.Enabled = false;
                txtPMAQLM1_150001_5000000_Normal.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_150001_5000000_Normal.Enabled = true;
                txtPMAQLZ_150001_5000000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLC_150001_5000000_Normal.Enabled = true;
                txtPMAQLC_150001_5000000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM_150001_5000000_Normal.Enabled = true;
                txtPMAQLM_150001_5000000_Normal.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_150001_5000000_Normal.Enabled = true;
                txtPMAQLM1_150001_5000000_Normal.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_Standard_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_Standard_Reinforce.Text != "")
            {
                txtPMAQLZ_Standard_Reinforce.Enabled = false;
                txtPMAQLZ_Standard_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_Standard_Reinforce.Enabled = false;
                txtPMAQLC_Standard_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_Standard_Reinforce.Enabled = false;
                txtPMAQLM_Standard_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_Standard_Reinforce.Enabled = false;
                txtPMAQLM1_Standard_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_Standard_Reinforce.Enabled = true;
                txtPMAQLZ_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_Standard_Reinforce.Enabled = true;
                txtPMAQLC_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_Standard_Reinforce.Enabled = true;
                txtPMAQLM_Standard_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_Standard_Reinforce.Enabled = true;
                txtPMAQLM1_Standard_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_501_1200_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_501_1200_Reinforce.Text != "")
            {
                txtPMAQLZ_501_1200_Reinforce.Enabled = false;
                txtPMAQLZ_501_1200_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_501_1200_Reinforce.Enabled = false;
                txtPMAQLC_501_1200_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_501_1200_Reinforce.Enabled = false;
                txtPMAQLM_501_1200_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_501_1200_Reinforce.Enabled = false;
                txtPMAQLM1_501_1200_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_501_1200_Reinforce.Enabled = true;
                txtPMAQLZ_501_1200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_501_1200_Reinforce.Enabled = true;
                txtPMAQLC_501_1200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_501_1200_Reinforce.Enabled = true;
                txtPMAQLM_501_1200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_501_1200_Reinforce.Enabled = true;
                txtPMAQLM1_501_1200_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_1201_3200_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_1201_3200_Reinforce.Text != "")
            {
                txtPMAQLZ_1201_3200_Reinforce.Enabled = false;
                txtPMAQLZ_1201_3200_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_1201_3200_Reinforce.Enabled = false;
                txtPMAQLC_1201_3200_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_1201_3200_Reinforce.Enabled = false;
                txtPMAQLM_1201_3200_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_1201_3200_Reinforce.Enabled = false;
                txtPMAQLM1_1201_3200_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_1201_3200_Reinforce.Enabled = true;
                txtPMAQLZ_1201_3200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_1201_3200_Reinforce.Enabled = true;
                txtPMAQLC_1201_3200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_1201_3200_Reinforce.Enabled = true;
                txtPMAQLM_1201_3200_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_1201_3200_Reinforce.Enabled = true;
                txtPMAQLM1_1201_3200_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }       

        private void txtPMAQL_3201_10000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_3201_10000_Reinforce.Text != "")
            {
                txtPMAQLZ_3201_10000_Reinforce.Enabled = false;
                txtPMAQLZ_3201_10000_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_3201_10000_Reinforce.Enabled = false;
                txtPMAQLC_3201_10000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_3201_10000_Reinforce.Enabled = false;
                txtPMAQLM_3201_10000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_3201_10000_Reinforce.Enabled = false;
                txtPMAQLM1_3201_10000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_3201_10000_Reinforce.Enabled = true;
                txtPMAQLZ_3201_10000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_3201_10000_Reinforce.Enabled = true;
                txtPMAQLC_3201_10000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_3201_10000_Reinforce.Enabled = true;
                txtPMAQLM_3201_10000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_3201_10000_Reinforce.Enabled = true;
                txtPMAQLM1_3201_10000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_10001_35000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_10001_35000_Reinforce.Text != "")
            {
                txtPMAQLZ_10001_35000_Reinforce.Enabled = false;
                txtPMAQLZ_10001_35000_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_10001_35000_Reinforce.Enabled = false;
                txtPMAQLC_10001_35000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_10001_35000_Reinforce.Enabled = false;
                txtPMAQLM_10001_35000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_10001_35000_Reinforce.Enabled = false;
                txtPMAQLM1_10001_35000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_10001_35000_Reinforce.Enabled = true;
                txtPMAQLZ_10001_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_10001_35000_Reinforce.Enabled = true;
                txtPMAQLC_10001_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_10001_35000_Reinforce.Enabled = true;
                txtPMAQLM_10001_35000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_10001_35000_Reinforce.Enabled = true;
                txtPMAQLM1_10001_35000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_35001_150000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_35001_150000_Reinforce.Text != "")
            {
                txtPMAQLZ_35001_150000_Reinforce.Enabled = false;
                txtPMAQLZ_35001_150000_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_35001_150000_Reinforce.Enabled = false;
                txtPMAQLC_35001_150000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_35001_150000_Reinforce.Enabled = false;
                txtPMAQLM_35001_150000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_35001_150000_Reinforce.Enabled = false;
                txtPMAQLM1_35001_150000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_35001_150000_Reinforce.Enabled = true;
                txtPMAQLZ_35001_150000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_35001_150000_Reinforce.Enabled = true;
                txtPMAQLC_35001_150000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_35001_150000_Reinforce.Enabled = true;
                txtPMAQLM_35001_150000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_35001_150000_Reinforce.Enabled = true;
                txtPMAQLM1_35001_150000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtPMAQL_150001_5000000_Reinforce_TextChanged(object sender, EventArgs e)
        {
            if (txtPMAQL_150001_5000000_Reinforce.Text != "")
            {
                txtPMAQLZ_150001_5000000_Reinforce.Enabled = false;
                txtPMAQLZ_150001_5000000_Reinforce.BackColor = Color.Silver;
                txtPMAQLC_150001_5000000_Reinforce.Enabled = false;
                txtPMAQLC_150001_5000000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM_150001_5000000_Reinforce.Enabled = false;
                txtPMAQLM_150001_5000000_Reinforce.BackColor = Color.Silver;
                txtPMAQLM1_150001_5000000_Reinforce.Enabled = false;
                txtPMAQLM1_150001_5000000_Reinforce.BackColor = Color.Silver;
            }
            else
            {
                txtPMAQLZ_150001_5000000_Reinforce.Enabled = true;
                txtPMAQLZ_150001_5000000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLC_150001_5000000_Reinforce.Enabled = true;
                txtPMAQLC_150001_5000000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM_150001_5000000_Reinforce.Enabled = true;
                txtPMAQLM_150001_5000000_Reinforce.BackColor = Color.WhiteSmoke;
                txtPMAQLM1_150001_5000000_Reinforce.Enabled = true;
                txtPMAQLM1_150001_5000000_Reinforce.BackColor = Color.WhiteSmoke;
            }
        }

        
        private void BtnPMPeriodicTestExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPMPeriodicTestReset_Click(object sender, EventArgs e)
        {
            try
            {
                dgPMPeriodicTest.Rows.Clear();
                CmbPMFamily.Focus();
                cmbPMTestMethod.Text = "--Select--";
                CmbPMFrequency.Text = "--Select--";
                CmbPMInspectionMethod.Text = "--Select--";
                Clear_Text();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        # region "KeyPress events of text boxes"

        private void txtPMSampleSize_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMSampleSize_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLC_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLC_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLC_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_Standard_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_501_1200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_1201_3200_Normal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMSampleSize_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMSampleSize_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQL_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLZ_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }

        }

        private void txtPMAQLC_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLC_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLC_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_Standard_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_501_1200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPMAQLM1_1201_3200_Reinforce_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        #endregion

        private void BtnPMPeriodicAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_Combo();
                CmbPMFrequency.Text = "--Select--";
                CmbPMInspectionMethod.Text = "--Select--";

                Clear_Text();

                //for add 
                Flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPMPeriodicTestSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                if (CmbPMFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select Technical Family", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbPMFamily.Focus();
                    return;
                }

                if (cmbPMTestMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Test Method", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPMTestMethod.Focus();
                    return;
                }
                if (CmbPMFrequency.Text == "--Select--")
                {
                    MessageBox.Show("Select Frequency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbPMFrequency.Focus();
                    return;
                }
                if (CmbPMInspectionMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Inspection Method", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbPMInspectionMethod.Focus();
                    return;
                }
                if (txtPMSampleSize_501_1200_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 501_1200_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_501_1200_Normal.Focus();
                    return;
                }
                if (txtPMSampleSize_1201_3200_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 1201_3200_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_1201_3200_Normal.Focus();
                    return;
                }
                if (txtPMSampleSize_3201_10000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 3201_10000_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_3201_10000_Normal.Focus();
                    return;
                }
                if (txtPMSampleSize_10001_35000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 10001_35000_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_10001_35000_Normal.Focus();
                    return;
                }
                if (txtPMSampleSize_35001_150000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 35001_150000_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_35001_150000_Normal.Focus();
                    return;
                }
                if (txtPMSampleSize_150001_5000000_Normal.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 150001_5000000_Normal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_150001_5000000_Normal.Focus();
                    return;
                }

                if (txtPMSampleSize_501_1200_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 501_1200_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_501_1200_Reinforce.Focus();
                    return;
                }
                if (txtPMSampleSize_1201_3200_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 1201_3200_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_1201_3200_Reinforce.Focus();
                    return;
                }
                if (txtPMSampleSize_3201_10000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 3201_10000_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_3201_10000_Reinforce.Focus();
                    return;
                }
                if (txtPMSampleSize_10001_35000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 10001_35000_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_10001_35000_Reinforce.Focus();
                    return;
                }
                if (txtPMSampleSize_35001_150000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 35001_150000_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_35001_150000_Reinforce.Focus();
                    return;
                }
                if (txtPMSampleSize_150001_5000000_Reinforce.Text == "")
                {
                    MessageBox.Show("Enter Sample Size 150001_5000000_Reinforce", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSampleSize_150001_5000000_Reinforce.Focus();
                    return;
                }
                PMPeriodicTestMaster_Class_obj.createdby = FrmMain.LoginID;
                PMPeriodicTestMaster_Class_obj.modifiedby = FrmMain.LoginID;
                if (Flag == true)
                {
                    DataSet ds = new DataSet();
                    PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());
                    PMPeriodicTestMaster_Class_obj.testno = Convert.ToInt64(cmbPMTestMethod.SelectedValue.ToString());
                    PMPeriodicTestMaster_Class_obj.inspectionMethod = CmbPMInspectionMethod.Text.Trim().ToString();
                    ds = PMPeriodicTestMaster_Class_obj.Select_Existsin_PMFGTestMethodMaster();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Record Exists For \n\nPackingMaterialFamily - " + CmbPMFamily.Text + "\nTest Method - " + cmbPMTestMethod.Text + "\nInspection method - " + CmbPMInspectionMethod.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //DataGrid.Rows.Clear();
                        return;
                    }
                }

                  bool b = false;
                  for (int i = 0; i < 14; i++)
                  {

                      PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());
                      //FinishedGoodMethodMaster_Class_Obj.testno_2 = Convert.ToInt32(DataGrid[11, i].Value);
                      PMPeriodicTestMaster_Class_obj.testno = Convert.ToInt64(cmbPMTestMethod.SelectedValue.ToString());
                      PMPeriodicTestMaster_Class_obj.inspectionMethod = CmbPMInspectionMethod.Text.Trim();
                      PMPeriodicTestMaster_Class_obj.frequency = CmbPMFrequency.Text.Trim();


                      if (i == 0)
                      {
                          //Normal - Standard 

                          PMPeriodicTestMaster_Class_obj.samplesize = 0;

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_Standard_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_Standard_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_Standard_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_Standard_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_Standard_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "Standard";
                      }

                      if (i == 1)
                      {
                          //Normal - 501-1200

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_501_1200_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_501_1200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_501_1200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_501_1200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_501_1200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_501_1200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "501-1200";
                      }

                      if (i == 2)
                      {
                          //Normal - 1201-3200

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_1201_3200_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_1201_3200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_1201_3200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_1201_3200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_1201_3200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_1201_3200_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "1201-3200";
                      }

                      if (i == 3)
                      {
                          //Normal - 3201-10000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_3201_10000_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_3201_10000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_3201_10000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_3201_10000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_3201_10000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_3201_10000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "3201-10000";
                      }

                      if (i == 4)
                      {
                          //Normal - 10000-35000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_10001_35000_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_10001_35000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_10001_35000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_10001_35000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_10001_35000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_10001_35000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "10001-35000";
                      }

                      if (i == 5)
                      {
                          //Normal - 35001-150000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_35001_150000_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_35001_150000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_35001_150000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_35001_150000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_35001_150000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_35001_150000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "35001-150000";
                      }

                      if (i == 6)
                      {
                          //Normal - 150001-5000000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_150001_5000000_Normal.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_150001_5000000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_150001_5000000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_150001_5000000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_150001_5000000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_150001_5000000_Normal.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Normal";

                          PMPeriodicTestMaster_Class_obj.lotsize = "150001-5000000";
                      }

                      if (i == 7)
                      {
                          //reinforce - Standard 

                          PMPeriodicTestMaster_Class_obj.samplesize = 0;

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_Standard_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_Standard_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_Standard_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_Standard_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_Standard_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "Standard";
                      }

                      if (i == 8)
                      {
                          //reinforce - 501-1200

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_501_1200_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_501_1200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_501_1200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_501_1200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_501_1200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_501_1200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "501-1200";
                      }

                      if (i == 9)
                      {

                          //reinforce - 1201-3200

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_1201_3200_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_1201_3200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_1201_3200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_1201_3200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_1201_3200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_1201_3200_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "1201-3200";
                      }

                      if (i == 10)
                      {

                          //reinforce - 3201-10000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_3201_10000_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_3201_10000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_3201_10000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_3201_10000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_3201_10000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_3201_10000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "3201-10000";
                      }

                      if (i == 11)
                      {

                          //reinforce - 10001-35000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_10001_35000_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_10001_35000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_10001_35000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_10001_35000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_10001_35000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_10001_35000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "10001-35000";
                      }

                      if (i == 12)
                      {

                          //reinforce - 35001-150000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_35001_150000_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_35001_150000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_35001_150000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_35001_150000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_35001_150000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_35001_150000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "35001-150000";
                      }

                      if (i == 13)
                      {

                          //reinforce - 150001-5000000

                          PMPeriodicTestMaster_Class_obj.samplesize = Convert.ToInt32(txtPMSampleSize_150001_5000000_Reinforce.Text);

                          PMPeriodicTestMaster_Class_obj.aql = Convert.ToString(txtPMAQL_150001_5000000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlz = Convert.ToString(txtPMAQLZ_150001_5000000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlc = Convert.ToString(txtPMAQLC_150001_5000000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm = Convert.ToString(txtPMAQLM_150001_5000000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.aqlm1 = Convert.ToString(txtPMAQLM1_150001_5000000_Reinforce.Text);
                          PMPeriodicTestMaster_Class_obj.type = "Reinforce";

                          PMPeriodicTestMaster_Class_obj.lotsize = "150001-5000000";
                      }


                      if (Flag == true)
                      {
                          b = PMPeriodicTestMaster_Class_obj.Insert_PMFGTestMethodMaster();
                          
                      }
                      else
                      {
                          b = PMPeriodicTestMaster_Class_obj.Update_tblPMFGTestMaster();
                      }
                  }

                  if (b == true)
                  {
                      if (Flag == true)
                      {
                          MessageBox.Show("Record Inserted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                      }
                      else
                      {
                          MessageBox.Show("Record Modified", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      }
                      BtnPMPeriodicTestReset_Click(sender, e);
                      Fill_dgPMPeriodicTest();
                  }
            }
               
                      
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Fill_dgPMPeriodicTest()
        {
            dgPMPeriodicTest.Rows.Clear();
            DataSet ds = new DataSet();
            ds = PMPeriodicTestMaster_Class_obj.Select_PMFGTestMethodMaster_PMFamilyID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgPMPeriodicTest.Rows.Add();
                    dgPMPeriodicTest["ValPMTestNo", i].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                    dgPMPeriodicTest["ValPMTestMethod", i].Value = ds.Tables[0].Rows[i]["TestName"].ToString();
                    dgPMPeriodicTest["ValPMFrequency", i].Value = ds.Tables[0].Rows[i]["Frequency"].ToString();
                    dgPMPeriodicTest["ValPMInspectionMethod", i].Value = ds.Tables[0].Rows[i]["InspectionMethod"].ToString();
                }
            }
        }

        private void BtnPMPeriodicTestModify_Click(object sender, EventArgs e)
        {
            try
            {
                Flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbPMFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BtnPMPeriodicTestReset_Click(sender, e); 
            if ((CmbPMFamily.SelectedValue.ToString() != null) && (CmbPMFamily.SelectedValue.ToString() != ""))
            {
                //int i = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue.ToString());
                PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());

                Fill_dgPMPeriodicTest();
                Bind_TestCombo();

               
            }
            else if (CmbPMFamily.Text == "--Select--") 
            {
                dgPMPeriodicTest.Rows.Clear();
                BtnPMPeriodicTestReset_Click(sender, e);
            }

        }

        public void Bind_TestCombo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());
            ds = PMPeriodicTestMaster_Class_obj.Select_PMFGTestMaster_PMFGTestMethodMaster_PMFamilyID();
            dr = ds.Tables[0].NewRow();
            dr["TestName"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbPMTestMethod.DataSource = ds.Tables[0];
                cmbPMTestMethod.DisplayMember = "TestName";
                cmbPMTestMethod.ValueMember = "TestNo";
            }
        }

        private void dgPMPeriodicTest_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clear_Text();

            if (dgPMPeriodicTest.Rows.Count > 0)
            {
                PMPeriodicTestMaster_Class_obj = new PMPeriodicTestMaster_Class();
                if ((CmbPMFamily.SelectedValue != null) && (CmbPMFamily.SelectedValue.ToString() != ""))
                {
                    PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());
                }
                if (dgPMPeriodicTest.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    PMPeriodicTestMaster_Class_obj.testname = dgPMPeriodicTest.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //New Change
                    cmbPMTestMethod.SelectedValue = dgPMPeriodicTest.Rows[e.RowIndex].Cells["ValPMTestNo"].Value.ToString();
                    PMPeriodicTestMaster_Class_obj.testno = Convert.ToInt64(dgPMPeriodicTest.Rows[e.RowIndex].Cells["ValPMTestNo"].Value.ToString());
                    //Old Change
                    //cmbPMTestMethod.Text = dgPMPeriodicTest.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //PMPeriodicTestMaster_Class_obj.testno = Convert.ToInt64(cmbPMTestMethod.SelectedValue);
                }
                if (dgPMPeriodicTest.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    PMPeriodicTestMaster_Class_obj.frequency = Convert.ToString(dgPMPeriodicTest.Rows[e.RowIndex].Cells[2].Value);
                    CmbPMFrequency.Text = dgPMPeriodicTest.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                if (dgPMPeriodicTest.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    PMPeriodicTestMaster_Class_obj.inspectionMethod = Convert.ToString(dgPMPeriodicTest.Rows[e.RowIndex].Cells[3].Value);
                    CmbPMInspectionMethod.Text = dgPMPeriodicTest.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                DataSet ds = new DataSet();
                ds = PMPeriodicTestMaster_Class_obj.Select_PMFinishedGoodDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        //---------Normal--------------------
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "Standard")
                        {
                            txtPMAQL_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_Standard_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "501-1200")
                        {
                            txtPMSampleSize_501_1200_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_501_1200_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_501_1200_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_501_1200_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_501_1200_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_501_1200_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "1201-3200")
                        {
                            txtPMSampleSize_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_1201_3200_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "3201-10000")
                        {
                            txtPMSampleSize_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_3201_10000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "10001-35000")
                        {
                            txtPMSampleSize_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_10001_35000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "35001-150000")
                        {
                            txtPMSampleSize_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_35001_150000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Normal" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "150001-5000000")
                        {
                            txtPMSampleSize_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_150001_5000000_Normal.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }


                        //---------Reinforce--------------------

                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "Standard")
                        {
                            txtPMAQL_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_Standard_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "501-1200")
                        {
                            txtPMSampleSize_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_501_1200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "1201-3200")
                        {
                            txtPMSampleSize_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_1201_3200_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "3201-10000")
                        {
                            txtPMSampleSize_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_3201_10000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "10001-35000")
                        {
                            txtPMSampleSize_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_10001_35000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "35001-150000")
                        {
                            txtPMSampleSize_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_35001_150000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "Reinforce" && ds.Tables[0].Rows[i]["LotSize"].ToString() == "150001-5000000")
                        {
                            txtPMSampleSize_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["sampleSize"].ToString();
                            txtPMAQL_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["AQL"].ToString();
                            txtPMAQLZ_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLZ"].ToString();
                            txtPMAQLC_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLC"].ToString();
                            txtPMAQLM_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM"].ToString();
                            txtPMAQLM1_150001_5000000_Reinforce.Text = ds.Tables[0].Rows[i]["AQLM1"].ToString();
                        }
                    }
                }
            }  

            

        }

        private void btnPMPeriodicTestDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbPMFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select Technical Family", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbPMFamily.Focus();
                    return;
                }
                if (cmbPMTestMethod.Text == "--Select--" || CmbPMFrequency.Text == "--Select--" || CmbPMInspectionMethod.Text == "--Select--")
                {
                    MessageBox.Show("Select Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgPMPeriodicTest.Focus();
                    return;
                }

                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PMPeriodicTestMaster_Class_obj.del = 1;

                    //bool b = PMPeriodicTestMaster_Class_obj.Delete_PMFinishedGoodTestDetails();
                    bool b = PMPeriodicTestMaster_Class_obj.Update_tblPMFGTestMethodMaster_Del();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Fill_dgPMPeriodicTest();
                        BtnPMPeriodicTestReset_Click(sender, e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPMFamily_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
      
    }
}

  
