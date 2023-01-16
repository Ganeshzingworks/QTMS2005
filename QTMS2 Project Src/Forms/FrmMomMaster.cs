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
using System.Text.RegularExpressions;


namespace QTMS.Forms
{

    public partial class FrmMOMMaster : Form
    {
        public FrmMOMMaster()
        {
            InitializeComponent();

        }


        # region Varibles



        bool modify = false;
        bool click = false;
        int momid;
        string tmpstring;
        string checkformula = "";
        string checkvessel = "";
        string checkannexTank = "";
        string safetysymbol = "";
        string accessoris = "";
        double pno = 0;
        int NPS;
        int cnt = 0;
        //int detailID;
        int result1 = 0;
        Double srno;
        int result = 0;
        string tmp = "";
        string oldmomno;
        bool SaveAs = false;
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        VesselMaster_Class VesselMaster_Class_obj = new VesselMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.MomMaster_Class objMomMaster_Class = new MomMaster_Class();
        SafetySymbol_Class SafetySymbol_Class_obj = new SafetySymbol_Class();

        DataSet dsList = new DataSet();

        # endregion

        private static FrmMOMMaster frmFormulaNoMaster_Obj = null;
        public static FrmMOMMaster GetInstance()
        {
            if (frmFormulaNoMaster_Obj == null)
            {
                frmFormulaNoMaster_Obj = new FrmMOMMaster();
            }
            return frmFormulaNoMaster_Obj;
        }

        private void FrmFormulaMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                Bind_List();
                Bind_CmbFormulaNo();
                Bind_vessel();
                Bind_Tank();
                txtMomNo.Focus();

                ////Bind_cmbMomno();
                ////cmbMOMNo.Focus();

                Bind_Saftyacc();
                Bind_SaftySymbols();
                Bind_Emulsifer();
                Bind_Impeller();
                Bind_scrapper();
                Bind_Vac();

                tabMom.TabPages.Remove(MOMPorcess);
                tabMom.TabPages.Remove(MOMFooter);

                clear();

                if (GlobalVariables.utypeid == 1)
                    ChkIndestrial.Enabled = true;
                if (GlobalVariables.utypeid == 21)
                    ChkUp.Enabled = true;
                if (GlobalVariables.utypeid == 22)
                    ChkSHE.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        public void Bind_List()
        {

            BusinessFacade.MomMaster_Class objMomMaster_Class = new MomMaster_Class();

            dsList = objMomMaster_Class.SELECT_tblMOMMaster();


            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cmbMOMNo.DataSource = ds.Tables[0];
            //    cmbMOMNo.DisplayMember = "MOMNo";
            //    cmbMOMNo.ValueMember = "MOMNo";
            //}

            //dsList = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "MOMNo";
            List.ValueMember = "MOMId";
            //Bind_FormulaNo();
        }



        DataSet dsFormulaDetails = new DataSet();
        public void Bind_CmbFormulaNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            dsFormulaDetails = ds;

            if (ds.Tables[0].Rows.Count > 0)
            {

                checkedListFormulano.DataSource = ds.Tables[0];
                checkedListFormulano.DisplayMember = "FormulaNo";
                checkedListFormulano.ValueMember = "FNo";
            }
        }

        public void Bind_vessel()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = VesselMaster_Class_obj.Select_tblVesselMaster();

            if (ds.Tables[0].Rows.Count > 0)
            {

                cheklistVessel.DataSource = ds.Tables[0];
                cheklistVessel.DisplayMember = "VslDesc";
                cheklistVessel.ValueMember = "VesselNo";
            }
        }

        public void Bind_Tank()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = VesselMaster_Class_obj.Select_tblAnnexTankMaster();

            if (ds.Tables[0].Rows.Count > 0)
            {

                checkedListAnnexTank.DataSource = ds.Tables[0];
                checkedListAnnexTank.DisplayMember = "AnnexTankDesc";
                checkedListAnnexTank.ValueMember = "AnnexTankNo";
            }
        }

        public void Bind_cmbMomno()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            BusinessFacade.MomMaster_Class objMomMaster_Class = new MomMaster_Class();

            ds = objMomMaster_Class.SELECT_tblMOMMaster();


            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbMOMNo.DataSource = ds.Tables[0];
                cmbMOMNo.DisplayMember = "MOMNo";
                cmbMOMNo.ValueMember = "MOMNo";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListFormulano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListFormulano_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (!RestrictAtListIteration)
            {
                if (Convert.ToBoolean(e.NewValue))
                {
                    lstTankDesc.Add(checkedListFormulano.Text);
                }
                else
                {
                    lstTankDesc.Remove(checkedListFormulano.Text);
                }
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {


        }

        public void clear()
        {

            txtMomNo.Text = "";
            txtAdjustmentquantity.Text = " ";
            cmbMOMNo.Focus();
            //   cmbMOMNo.Text = "SELECT";
            cmbMOMNo.Refresh();

            txtBatchSize.Text = "";
            txtProductDescription.Text = "";
            txtIQPreparedby.Text = "";
            txtIQAcceptedby.Text = "";
            txtUPAcceptedby.Text = "";
            txtSHEAcceptedby.Text = "";
            DtpIQDate.Checked = false;
            DtpUPAcceptedDate.Checked = false;
            DtpUPAcceptedDate.Checked = false;
            DtpSHEAcceptedDate.Checked = false;

            txtISODocumentNo.Text = "";
            txtReferenceDoc.Text = "";
            txtReason.Text = "";
            cheklistVessel.ClearSelected();
            checkedListAnnexTank.ClearSelected();
            checkedListFormulano.ClearSelected();
            for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
            {
                if (checkedListAnnexTank.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedListAnnexTank.SetItemChecked(i, false);


                }
            }
            for (int i = 0; i < checkedListFormulano.Items.Count; i++)
            {
                if (checkedListFormulano.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedListFormulano.SetItemChecked(i, false);
                }
            }

            for (int i = 0; i < cheklistVessel.Items.Count; i++)
            {
                if (cheklistVessel.GetItemCheckState(i) == CheckState.Checked)
                {
                    cheklistVessel.SetItemChecked(i, false);


                }

            }


        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

            modify = true;

            btnSaveAsNew.Enabled = false;
            BtnDelete.Enabled = false;
            txtBatchSize.Focus();

            SaveAs = false;
            //BtnDelete.Enabled = true;

        }

        private void cmbMOMNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            cmbMOMNo.Refresh();

            if (cmbMOMNo.Text != "SELECT")
            {


                BtnModify.Enabled = true;
                BtnDelete.Enabled = true;

                btnSaveAsNew.Enabled = true;
                //   modify = true;

                btnsave.Enabled = true;
                objMomMaster_Class.momno = cmbMOMNo.SelectedValue.ToString();
                oldmomno = cmbMOMNo.SelectedValue.ToString();

                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();
                int momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());
                DataSet ds1 = new DataSet();
                objMomMaster_Class.momid = momid;
                ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds1;
            }








            // split FormulaNo here and shows check list 
            string frno = ds.Tables[0].Rows[0]["FormulaNo"].ToString();
            string[] frno1 = frno.Split(',');

            for (int i = 0; i < checkedListFormulano.Items.Count; i++)
            {
                for (int j = 0; j < frno1.Length; j++)
                {
                    lstTankDesc.Add(frno1[j].ToString());
                    if (checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) == frno1[j].ToString())
                    {
                        checkedListFormulano.SetItemChecked(i, true);
                    }
                }
            }


            string VesselId = ds.Tables[0].Rows[0]["VesselId"].ToString();
            string[] VesselId1 = VesselId.Split(',');

            for (int i = 0; i < cheklistVessel.Items.Count; i++)
            {
                for (int j = 0; j < VesselId1.Length; j++)
                {
                    if (cheklistVessel.GetItemText(cheklistVessel.Items[i]) == VesselId1[j].ToString())
                    {
                        cheklistVessel.SetItemChecked(i, true);
                    }
                }
            }


            string AnnexTank = ds.Tables[0].Rows[0]["AnnexTankId"].ToString();
            string[] AnnexTank1 = AnnexTank.Split(',');

            for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
            {
                for (int j = 0; j < AnnexTank1.Length; j++)
                {
                    if (checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) == AnnexTank1[j].ToString())
                    {
                        checkedListAnnexTank.SetItemChecked(i, true);
                    }
                }
            }






            txtBatchSize.Text = ds.Tables[0].Rows[0]["BatchSize"].ToString();

            // txtMOMNo.Text = ds.Tables[0].Rows[0]["MOMNo"].ToString();

            txtProductDescription.Text = ds.Tables[0].Rows[0]["ProductDescription"].ToString();

            txtIQPreparedby.Text = ds.Tables[0].Rows[0]["IQualityPreparedBy"].ToString();

            txtIQAcceptedby.Text = ds.Tables[0].Rows[0]["IQualityAcceptedBy"].ToString();

            txtUPAcceptedby.Text = ds.Tables[0].Rows[0]["UPAcceptedBy"].ToString();


            txtSHEAcceptedby.Text = ds.Tables[0].Rows[0]["SHEAcceptedBy"].ToString();


            // txtDocumentsAssoociated.Text = ds.Tables[0].Rows[0]["DocumentsAssoociated"].ToString();


            //   txtEquipments.Text = ds.Tables[0].Rows[0]["Equipmentstobeused"].ToString();


            txtReason.Text = ds.Tables[0].Rows[0]["ReasonforIssue"].ToString();

            txtReferenceDoc.Text = ds.Tables[0].Rows[0]["ReferenceDocument"].ToString();

            txtISODocumentNo.Text = ds.Tables[0].Rows[0]["ISODocumentNo"].ToString();









            if (Convert.ToDateTime(ds.Tables[0].Rows[0]["IQualityDate"]) == Convert.ToDateTime("1/1/1900"))
            {
                DtpIQDate.Value = Comman_Class_Obj.Select_ServerDate();

                DtpIQDate.Checked = false;
            }
            else
            {
                DtpIQDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["IQualityDate"].ToString());
                DtpIQDate.Checked = true;

            }



            if (Convert.ToDateTime(ds.Tables[0].Rows[0]["UPAcceptedByDate"]) == Convert.ToDateTime("1/1/1900"))
            {
                DtpUPAcceptedDate.Value = Comman_Class_Obj.Select_ServerDate();

                DtpUPAcceptedDate.Checked = false;
            }
            else
            {
                DtpUPAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["UPAcceptedByDate"].ToString());
                DtpUPAcceptedDate.Checked = true;

            }
            if (Convert.ToDateTime(ds.Tables[0].Rows[0]["SHEAcceptedByDate"]) == Convert.ToDateTime("1/1/1900"))
            {
                DtpSHEAcceptedDate.Value = Comman_Class_Obj.Select_ServerDate();

                DtpSHEAcceptedDate.Checked = false;
            }
            else
            {
                DtpSHEAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["SHEAcceptedByDate"].ToString());
                DtpSHEAcceptedDate.Checked = true;

            }

        }

        private void button26_Click(object sender, EventArgs e)
        {







        }

        public void Bind_SaftySymbols()
        {
            DataRow dr;
            DataSet ds = new DataSet();


            ds = SafetySymbol_Class_obj.Select_SafetySymbol_symb();

            if (ds.Tables[0].Rows.Count > 0)
            {

                checklistSafetysymbol.DataSource = ds.Tables[0];

                checklistSafetysymbol.DisplayMember = "Safetysign";
                checklistSafetysymbol.ValueMember = "SymID";
                checklistSafetysymbol.Text = "select";
            }
        }

        public void Bind_Saftyacc()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = SafetySymbol_Class_obj.Select_SafetySymbol_acc();
            if (ds.Tables[0].Rows.Count > 0)
            {

                checklistAccessory.DataSource = ds.Tables[0];
                checklistAccessory.DisplayMember = "SymName";
                checklistAccessory.ValueMember = "SymID";
            }
        }

        public void Bind_scrapper()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Scrapper();

            dr = ds.Tables[0].NewRow();
            dr["Timefield"] = "--Select--";
            dr["Timefield"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);


            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbScarpper.DataSource = ds.Tables[0];
                cmbScarpper.DisplayMember = "Timefield";
                cmbScarpper.ValueMember = "Timefield";
            }
        }
        public void Bind_Impeller()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Impeller();

            dr = ds.Tables[0].NewRow();
            dr["Timefield"] = "--Select--";
            dr["Timefield"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbImpeller.DataSource = ds.Tables[0];
                cmbImpeller.DisplayMember = "Timefield";
                cmbImpeller.ValueMember = "Timefield";
            }
        }

        public void Bind_Emulsifer()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Emulsifier();

            dr = ds.Tables[0].NewRow();
            dr["Timefield"] = "--Select--";
            dr["Timefield"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbemulsifer.DataSource = ds.Tables[0];
                cmbemulsifer.DisplayMember = "Timefield";
                cmbemulsifer.ValueMember = "Timefield";
            }
        }

        public void Bind_Vac()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            //  cmbVaC.Items.Insert(0, "hi");

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Vac();

            dr = ds.Tables[0].NewRow();
            dr["Timefield"] = "--Select--";
            dr["Timefield"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbVaC.DataSource = ds.Tables[0];
                cmbVaC.DisplayMember = "Timefield";
                cmbVaC.ValueMember = "Timefield";
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {

            if (txtMomNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter MOM No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMomNo.Focus();
                return;
            }


            if (modify == false)
            {
                if (momid > 0)
                {
                    tabMom.TabPages.Remove(MOMtab);
                    tabMom.TabPages.Remove(MOMFooter);
                    tabMom.TabPages.Add(MOMPorcess);
                    return;
                }


                objMomMaster_Class.momno = txtMomNo.Text.Trim();
                DataSet ds = new DataSet();
                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    MessageBox.Show("MOMNo is  Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    txtMomNo.Focus();
                    ////btnSaveAsNew.Enabled = false;
                    ////// tabMom.SelectedIndex = 0;
                    ////// FrmFormulaMaster_Load(sender, e);

                    ////tabMom.TabPages.Remove(MOMFooter);
                    ////tabMom.TabPages.Add(MOMtab);
                    ////tabMom.SelectedTab = MOMtab;
                    //////Bind_cmbMomno();
                    ////BtnDelete.Enabled = false;
                    ////BtnModify.Enabled = false;
                    ////clear();
                    ////txtMomNo.Focus();
                    return;
                }


                // generate string for formula
                for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                {
                    if (checkedListFormulano.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkformula += checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) + ",";
                    }
                }
                checkformula = checkformula.TrimEnd(',');

                // generate string for vessel 

                for (int i = 0; i < cheklistVessel.Items.Count; i++)
                {
                    if (cheklistVessel.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkvessel += cheklistVessel.GetItemText(cheklistVessel.Items[i]) + ",";
                    }
                }
                checkvessel = checkvessel.TrimEnd(',');

                //generate string for AnnexTank 

                for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
                {
                    if (checkedListAnnexTank.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkannexTank += checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) + ",";
                    }
                }
                checkannexTank = checkannexTank.TrimEnd(',');

                //  objMomMaster_Class.formulaNo = CmbFormulaNo.Text.ToString();
                //   objMomMaster_Class.documentsAssoociated = txtDocumentsAssoociated.Text;
                // objMomMaster_Class.equipmentstobeused = txtEquipments.Text;
                objMomMaster_Class.formulaNo = checkformula;


                // objMomMaster_Class.fno = Convert.ToInt32(checkedListFormulano.SelectedValue.ToString());
                objMomMaster_Class.batchSize = txtBatchSize.Text;

                objMomMaster_Class.productDescription = txtProductDescription.Text;
                objMomMaster_Class.iQualityPreparedBy = txtIQPreparedby.Text;
                objMomMaster_Class.iQualityAcceptedBy = txtIQAcceptedby.Text;
                objMomMaster_Class.upAcceptedBy = txtUPAcceptedby.Text;
                objMomMaster_Class.sheAcceptedBy = txtSHEAcceptedby.Text;
                objMomMaster_Class.iSODocumentNo = txtISODocumentNo.Text;
                objMomMaster_Class.referenceDocument = txtReferenceDoc.Text;
                objMomMaster_Class.reasonforIssue = txtReason.Text;
                objMomMaster_Class.vesselId = checkvessel;
                objMomMaster_Class.annexTankId = checkannexTank;

                if (DtpIQDate.Checked == true)
                {
                    objMomMaster_Class.iQualityDate = Convert.ToDateTime(DtpIQDate.Value.ToShortDateString());
                }
                else
                {

                    objMomMaster_Class.iQualityDate = Convert.ToDateTime("1/1/1900");

                }
                if (DtpUPAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime(DtpUPAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                if (DtpSHEAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime(DtpSHEAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                momid = Convert.ToInt32(objMomMaster_Class.Insert_MOMMaster());

                if (momid > 0)
                {
                    tabMom.TabPages.Remove(MOMtab);
                    tabMom.TabPages.Remove(MOMFooter);
                    tabMom.TabPages.Add(MOMPorcess);
                }
            }
            else
            {

                // generate string for formula
                for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                {
                    if (checkedListFormulano.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkformula += checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) + ",";
                    }
                }
                checkformula = checkformula.TrimEnd(',');

                // generate string for vessel 

                for (int i = 0; i < cheklistVessel.Items.Count; i++)
                {
                    if (cheklistVessel.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkvessel += cheklistVessel.GetItemText(cheklistVessel.Items[i]) + ",";
                    }
                }
                checkvessel = checkvessel.TrimEnd(',');

                //generate string for AnnexTank 

                for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
                {
                    if (checkedListAnnexTank.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkannexTank += checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) + ",";
                    }
                }
                checkannexTank = checkannexTank.TrimEnd(',');

                //  objMomMaster_Class.formulaNo = CmbFormulaNo.Text.ToString();
                //   objMomMaster_Class.documentsAssoociated = txtDocumentsAssoociated.Text;
                // objMomMaster_Class.equipmentstobeused = txtEquipments.Text;
                objMomMaster_Class.formulaNo = checkformula;
                objMomMaster_Class.momid = momid;
                objMomMaster_Class.momno = txtMomNo.Text.Trim();
                // objMomMaster_Class.fno = Convert.ToInt32(checkedListFormulano.SelectedValue.ToString());
                objMomMaster_Class.batchSize = txtBatchSize.Text;

                objMomMaster_Class.productDescription = txtProductDescription.Text;
                objMomMaster_Class.iQualityPreparedBy = txtIQPreparedby.Text;
                objMomMaster_Class.iQualityAcceptedBy = txtIQAcceptedby.Text;
                objMomMaster_Class.upAcceptedBy = txtUPAcceptedby.Text;
                objMomMaster_Class.sheAcceptedBy = txtSHEAcceptedby.Text;
                objMomMaster_Class.iSODocumentNo = txtISODocumentNo.Text;
                objMomMaster_Class.referenceDocument = txtReferenceDoc.Text;
                objMomMaster_Class.reasonforIssue = txtReason.Text;
                objMomMaster_Class.vesselId = checkvessel;
                objMomMaster_Class.annexTankId = checkannexTank;

                if (DtpIQDate.Checked == true)
                {
                    objMomMaster_Class.iQualityDate = Convert.ToDateTime(DtpIQDate.Value.ToShortDateString());
                }
                else
                {

                    objMomMaster_Class.iQualityDate = Convert.ToDateTime("1/1/1900");

                }
                if (DtpUPAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime(DtpUPAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                if (DtpSHEAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime(DtpSHEAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                objMomMaster_Class.UPDATE_tblMOMMaster();

                tabMom.TabPages.Remove(MOMtab);
                tabMom.TabPages.Remove(MOMFooter);
                tabMom.TabPages.Add(MOMPorcess);

                List<MomMaster_Class> fill = new List<MomMaster_Class>();
                DataSet ds1 = new DataSet();
                ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();

                for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                {

                    objMomMaster_Class = new MomMaster_Class();
                    objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                    objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                    objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                    objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                    string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                    string HTMLCode = tmpstring;

                    HTMLCode = HTMLCode.Replace("\n", " ");

                    // Remove tab spaces
                    HTMLCode = HTMLCode.Replace("\t", " ");

                    // Remove multiple white spaces from HTML
                    HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                    // Remove HEAD tag
                    HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                        , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    // Remove any JavaScript
                    HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                      , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    // Replace special characters like &, <, >, " etc.
                    StringBuilder sbHTML = new StringBuilder(HTMLCode);
                    // Note: There are many more special characters, these are just
                    // most common. You can add new characters in this arrays if needed
                    string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                    string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                    for (int j = 0; j < OldWords.Length; j++)
                    {
                        sbHTML.Replace(OldWords[j], NewWords[j]);
                    }

                    // Check if there are line breaks (<br>) or paragraph (<p>)
                    sbHTML.Replace("<br>", "\n<br>");
                    sbHTML.Replace("<br ", "\n<br ");
                    sbHTML.Replace("<p ", "\n<p ");

                    // Finally, remove all HTML tags and return plain text
                    txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                     sbHTML.ToString(), "<[^>]*>", "");




                    objMomMaster_Class.processDesc = txtprocessdesc.Text;
                    objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                    objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                    objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                    objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                    objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                    objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                    objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                    objMomMaster_Class.IsUpdate = 1;

                    objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);
                    objMomMaster_Class.detailId = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                    fill.Add(objMomMaster_Class);

                }

                fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });

                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = fill;
                li = fill;

            }




            #region Adding new code for MOM master 08-12-2017
            /*

            Bind_Saftyacc();
            Bind_SaftySymbols();
            Bind_Emulsifer();
            Bind_Impeller();
            Bind_scrapper();
            Bind_Vac();
            tabMom.TabPages.Remove(MOMtab);
            tabMom.TabPages.Remove(MOMFooter);
            tabMom.TabPages.Add(MOMPorcess);
        

         //   tabMom.TabPages.Add(MOMPorcess);
                    
               

              tabMom.SelectedIndex = tabMom.SelectedIndex + 1;
        

          if (SaveAs == true)

          {
              modify = false;

          
          
          }
            //if (modify == true  )
            //{



                List<MomMaster_Class> fill = new List<MomMaster_Class>();
                DataSet ds = new DataSet();
                if (SaveAs == true)
                {
                    objMomMaster_Class.momno = oldmomno;
                    ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());

                    DataSet ds1 = new DataSet();


                    ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();


                    for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                    {

                        objMomMaster_Class = new MomMaster_Class();
                        objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                        objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                        objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                        objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                        string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                        string HTMLCode = tmpstring;

                        HTMLCode = HTMLCode.Replace("\n", " ");

                        // Remove tab spaces
                        HTMLCode = HTMLCode.Replace("\t", " ");

                        // Remove multiple white spaces from HTML
                        HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                        // Remove HEAD tag
                        HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                            , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Remove any JavaScript
                        HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                          , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Replace special characters like &, <, >, " etc.
                        StringBuilder sbHTML = new StringBuilder(HTMLCode);
                        // Note: There are many more special characters, these are just
                        // most common. You can add new characters in this arrays if needed
                        string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                        string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                        for (int j = 0; j < OldWords.Length; j++)
                        {
                            sbHTML.Replace(OldWords[j], NewWords[j]);
                        }

                        // Check if there are line breaks (<br>) or paragraph (<p>)
                        sbHTML.Replace("<br>", "\n<br>");
                        sbHTML.Replace("<br ", "\n<br ");
                        sbHTML.Replace("<p ", "\n<p ");

                        // Finally, remove all HTML tags and return plain text
                        txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                         sbHTML.ToString(), "<[^>]*>", "");




                        objMomMaster_Class.processDesc = txtprocessdesc.Text;
                        objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                        objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                        objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                        objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                        objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                        objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                        objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                        objMomMaster_Class.IsUpdate = 1;

                        objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                        fill.Add(objMomMaster_Class);

                    }

                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });

                    dataGridView1.DataSource = null;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = fill;
                    li = fill;            


                }

                else if (modify == true)
                {
                    objMomMaster_Class.momno = cmbMOMNo.Text;
                    ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());

                    DataSet ds1 = new DataSet();


                    ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();


                    for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                    {

                        objMomMaster_Class = new MomMaster_Class();
                        objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                        objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                        objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                        objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                        string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                        string HTMLCode = tmpstring;

                        HTMLCode = HTMLCode.Replace("\n", " ");

                        // Remove tab spaces
                        HTMLCode = HTMLCode.Replace("\t", " ");

                        // Remove multiple white spaces from HTML
                        HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                        // Remove HEAD tag
                        HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                            , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Remove any JavaScript
                        HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                          , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Replace special characters like &, <, >, " etc.
                        StringBuilder sbHTML = new StringBuilder(HTMLCode);
                        // Note: There are many more special characters, these are just
                        // most common. You can add new characters in this arrays if needed
                        string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                        string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                        for (int j = 0; j < OldWords.Length; j++)
                        {
                            sbHTML.Replace(OldWords[j], NewWords[j]);
                        }

                        // Check if there are line breaks (<br>) or paragraph (<p>)
                        sbHTML.Replace("<br>", "\n<br>");
                        sbHTML.Replace("<br ", "\n<br ");
                        sbHTML.Replace("<p ", "\n<p ");

                        // Finally, remove all HTML tags and return plain text
                        txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                         sbHTML.ToString(), "<[^>]*>", "");




                        objMomMaster_Class.processDesc = txtprocessdesc.Text;
                        objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                        objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                        objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                        objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                        objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                        objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                        objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                        objMomMaster_Class.IsUpdate = 1;

                        objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                        fill.Add(objMomMaster_Class);





                    }



                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });




                    dataGridView1.DataSource = null;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = fill;
                    li = fill;



                }

                else
                    if (oldmomno == cmbMOMNo.Text)
                    {

                        ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                        momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());

                        DataSet ds1 = new DataSet();


                        ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();


                        for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                        {

                            objMomMaster_Class = new MomMaster_Class();
                            objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                            objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                            objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                            objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                            string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                            string HTMLCode = tmpstring;

                            HTMLCode = HTMLCode.Replace("\n", " ");

                            // Remove tab spaces
                            HTMLCode = HTMLCode.Replace("\t", " ");

                            // Remove multiple white spaces from HTML
                            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                            // Remove HEAD tag
                            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                            // Remove any JavaScript
                            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                            // Replace special characters like &, <, >, " etc.
                            StringBuilder sbHTML = new StringBuilder(HTMLCode);
                            // Note: There are many more special characters, these are just
                            // most common. You can add new characters in this arrays if needed
                            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                            string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                            for (int j = 0; j < OldWords.Length; j++)
                            {
                                sbHTML.Replace(OldWords[j], NewWords[j]);
                            }

                            // Check if there are line breaks (<br>) or paragraph (<p>)
                            sbHTML.Replace("<br>", "\n<br>");
                            sbHTML.Replace("<br ", "\n<br ");
                            sbHTML.Replace("<p ", "\n<p ");

                            // Finally, remove all HTML tags and return plain text
                            txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                             sbHTML.ToString(), "<[^>]*>", "");




                            objMomMaster_Class.processDesc = txtprocessdesc.Text;
                            objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                            objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                            objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                            objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                            objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                            objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                            objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                            objMomMaster_Class.IsUpdate = 1;

                            objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                            fill.Add(objMomMaster_Class);

                        }

                        fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                        fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });
                        
                        dataGridView1.DataSource = null;
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = fill;
                        li = fill;

                    }
                    else
                    {
                         //List<MomMaster_Class>

                      //  li.Remove(objMomMaster_Class);
                        objMomMaster_Class = null;
                        fill.Remove(objMomMaster_Class);
                        li.Remove(objMomMaster_Class);
                       
                        dataGridView1.DataSource = null;
                    }           



            */
            #endregion
        }

        private void btntab2next_Click(object sender, EventArgs e)
        {

            tabMom.SelectedIndex = tabMom.SelectedIndex + 1;

        }

        private void btnPrevioustab3_Click(object sender, EventArgs e)
        {
            tabMom.SelectedIndex = tabMom.SelectedIndex - 1;
        }

        private void cmbImpeller_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<MomMaster_Class> li = new List<MomMaster_Class>();

        private void btnadd_Click(object sender, EventArgs e)
        {
            cnt = cnt + 1;

            objMomMaster_Class.dummysrno = cnt;

            dataGridView1.AutoGenerateColumns = false;

            if (lblisupdate.Text == "1" || lblisnew.Text == "0")
            {


                for (int i = 0; i < li.Count; i++)
                {
                    if (i == Convert.ToInt32(lblrowupdateID.Text))
                    {
                        objMomMaster_Class = li[i];
                    }
                }

                objMomMaster_Class.IsUpdate = 1;
                if (lblisupdate.Text == "1" && lblisnew.Text == "1")
                {
                    objMomMaster_Class.IsUpdate = 0;
                    objMomMaster_Class.momid = momid;
                }

            }
            else
            {

                objMomMaster_Class = new MomMaster_Class();
                objMomMaster_Class.IsUpdate = 0;
                objMomMaster_Class.momid = momid;
            }

            if (cmbdesc.SelectedIndex >= 0 || cmbdesc.SelectedText != "")
            {
                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {
                    if (checklistSafetysymbol.GetItemCheckState(i) == CheckState.Checked)
                    {
                        safetysymbol += checklistSafetysymbol.GetItemText(checklistSafetysymbol.Items[i]) + ",";
                    }
                }


                safetysymbol = safetysymbol.TrimEnd(',');


                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {
                    if (checklistAccessory.GetItemCheckState(i) == CheckState.Checked)
                    {


                        accessoris += checklistAccessory.GetItemText(checklistAccessory.Items[i]) + ",";
                    }
                }

                accessoris = accessoris.TrimEnd(',');


                //objMomMaster_Class.detailID = Convert.ToInt32(lblDetailID.Text.Trim());
                objMomMaster_Class.srNo = Convert.ToDouble(txtSrNo.Text.Trim());
                objMomMaster_Class.printSequenceNo = Convert.ToInt32(txtPrintSquenceNo.Text);
                if (cmbdesc.Text.ToString() == "Note")
                {
                    NPS = 0;
                }
                else
                    if (cmbdesc.Text.ToString() == "Process")
                    {

                        NPS = 1;


                    }


                    else
                    {


                        NPS = 2;



                    }

                objMomMaster_Class.isNoteProSubPro = NPS;

                tmpstring = kaireeHTMLEditor1.Text;
                tmpstring = tmpstring.Replace("<STRONG>", "<B>");
                tmpstring = tmpstring.Replace("</STRONG>", "</B>");
                tmpstring = tmpstring.Replace("<EM>", "<I>");
                tmpstring = tmpstring.Replace("</EM>", "</I>");


                //                
                //objMomMaster_Class.processDesc = kaireeHTMLEditor1.Text;


                string HTMLCode = tmpstring;

                HTMLCode = HTMLCode.Replace("\n", " ");

                // Remove tab spaces
                HTMLCode = HTMLCode.Replace("\t", " ");

                // Remove multiple white spaces from HTML
                HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                // Remove HEAD tag
                HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                    , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Remove any JavaScript
                HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                  , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Replace special characters like &, <, >, " etc.
                StringBuilder sbHTML = new StringBuilder(HTMLCode);
                // Note: There are many more special characters, these are just
                // most common. You can add new characters in this arrays if needed
                string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                for (int i = 0; i < OldWords.Length; i++)
                {
                    sbHTML.Replace(OldWords[i], NewWords[i]);
                }

                // Check if there are line breaks (<br>) or paragraph (<p>)
                sbHTML.Replace("<br>", "\n<br>");
                sbHTML.Replace("<br ", "\n<br ");
                sbHTML.Replace("<p ", "\n<p ");

                // Finally, remove all HTML tags and return plain text
                txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                 sbHTML.ToString(), "<[^>]*>", "");

                objMomMaster_Class.processDesc = txtprocessdesc.Text;
                objMomMaster_Class.htmlProcessDesc = tmpstring;


                //  objMomMaster_Class.processDesc = txtprocessdesc.Text;
                txtprocessdesc.Text = "";

                if (Convert.ToString(cmbScarpper.SelectedValue) == "--Select--")
                    objMomMaster_Class.scrapper = "";
                else
                    objMomMaster_Class.scrapper = Convert.ToString(cmbScarpper.SelectedValue);
                if (Convert.ToString(cmbImpeller.SelectedValue) == "--Select--")
                    objMomMaster_Class.impeller = "";
                else
                    objMomMaster_Class.impeller = Convert.ToString(cmbImpeller.SelectedValue);
                if (Convert.ToString(cmbemulsifer.SelectedValue) == "--Select--")
                    objMomMaster_Class.emulsifer = "";
                else
                    objMomMaster_Class.emulsifer = Convert.ToString(cmbemulsifer.SelectedValue);
                if (Convert.ToString(cmbVaC.SelectedValue) == "--Select--")
                    objMomMaster_Class.vac = "";
                else
                    objMomMaster_Class.vac = Convert.ToString(cmbVaC.SelectedValue);

                objMomMaster_Class.symb = safetysymbol;


                objMomMaster_Class.accsessories = accessoris;


                if (lblisupdate.Text == "1")
                {
                }
                else
                {
                    li.Add(objMomMaster_Class);
                }
                li.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                li.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = li;



                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {
                    if (checklistSafetysymbol.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checklistSafetysymbol.SetItemChecked(i, false);


                    }
                }
                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {
                    if (checklistAccessory.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checklistAccessory.SetItemChecked(i, false);


                    }
                }




                //cmbScarpper.Text = "select";
                checklistAccessory.ClearSelected();
                checklistSafetysymbol.ClearSelected();
                kaireeHTMLEditor1.Clear();

                cmbemulsifer.Text = "--Select--";
                cmbImpeller.Text = "--Select--";
                cmbScarpper.Text = "--Select--";
                cmbVaC.Text = "--Select--";
                safetysymbol = "";
                accessoris = "";

                //txtprocessdesc.Text = "";
                btnadd.Text = "ADD";
                if (btnadd.Text == "ADD")
                {
                    btcancel.Enabled = false;

                }

                int result1 = 0;
                lblisupdate.Text = "0";
                cmbdesc.Text = null;
                cmbdesc.Focus();


                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {
                    if (checklistSafetysymbol.GetItemChecked(i))
                    {
                        checklistSafetysymbol.SetItemChecked(i, false);
                        checklistSafetysymbol.ClearSelected();
                    }
                }

                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {
                    if (checklistAccessory.GetItemChecked(i))
                    {
                        checklistAccessory.SetItemChecked(i, false);
                        checklistAccessory.ClearSelected();
                    }
                }

            }
            else

                MessageBox.Show("Select Process /SubProcess");
            cmbdesc.Focus();






        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmbdesc_SelectionChangeCommitted(object sender, EventArgs e)
        {





            result1 = 0;
            if (cmbdesc.SelectedItem.ToString() == "Note")
            {
                NPS = 0;

            }
            else
                if (cmbdesc.SelectedItem.ToString() == "Process")
                {

                    NPS = 1;


                }


                else
                {

                    NPS = 2;


                }

            /// Put Track  for Process and Sub Process 


            if (NPS == 0)
            {

                srno = 0;

            }

            else

                if (NPS == 1)
                {

                    foreach (MomMaster_Class obj in li)
                    {
                        if (obj.isNoteProSubPro == 1)
                        {

                            pno = obj.srNo + 1;


                        }

                    }
                    if (pno == 0)
                    {
                        srno = 1;
                    }

                    else if (objMomMaster_Class.srNo == pno)
                    {
                        string s = objMomMaster_Class.srNo.ToString();
                        srno = Convert.ToInt32(s.Split(new char[] { '.' })[0]) + 1;

                    }
                    else
                    {
                        srno = pno;
                    }
                }
                else
                {
                    int subproccnt = 0;
                    int proccnt = 0;
                    double procsrno = 0; ;
                    foreach (MomMaster_Class obj in li)
                    {

                        if (obj.isNoteProSubPro == 1)
                        {

                            ++proccnt;
                            procsrno = obj.srNo;

                        }
                    }

                    double procsrno1 = procsrno;

                    foreach (MomMaster_Class obj in li)
                    {
                        if (obj.isNoteProSubPro == 2)
                        {
                            string s = obj.srNo.ToString();
                            int d = Convert.ToInt32(s.Split(new char[] { '.' })[0]);
                            if (d == proccnt)
                                pno = Convert.ToDouble(Convert.ToDecimal(obj.srNo) + Convert.ToDecimal(0.1));
                            else
                                if (proccnt == 0)
                                {
                                    pno = Convert.ToDouble(Convert.ToDecimal(obj.srNo) + Convert.ToDecimal(0.1));
                                }
                                else
                                    if ((Convert.ToInt32(procsrno1)) > proccnt)
                                    {
                                        pno = procsrno1 + 0.1;
                                        proccnt = Convert.ToInt32(procsrno1);
                                        procsrno1 = 0;


                                    }
                                    else
                                    {
                                        pno = proccnt + 0.1;
                                    }


                            subproccnt++;

                        }
                    }




                    if (pno == 0)
                    {
                        if (proccnt > 0)
                        {
                            srno = proccnt + 0.1;
                        }
                        else
                        {
                            srno = 1.1;
                        }
                    }
                    else
                    {
                        if (subproccnt == 0)
                        {
                            pno = pno + 0.1;
                            srno = pno;
                        }
                        else
                        {


                            srno = pno;
                        }
                    }

                }

            foreach (MomMaster_Class thing in li)
            {
                result1 = Math.Max(result1, thing.printSequenceNo);
            }

            //if (result1 == 0)
            //{
            //    result1 = 1; 
            //}
            result = result1 + 1;


            txtSrNo.Text = srno.ToString();
            //  txtPrintSquenceNo.Text = li.Count.ToString();
            txtPrintSquenceNo.Text = result.ToString();

            lblisnew.Text = "1";




        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (modify == false)
            {
                objMomMaster_Class.momid = Convert.ToInt32(momid);
                objMomMaster_Class.adjustmentquantity = txtAdjustmentquantity.Text;
                objMomMaster_Class.Insert_tblMOMFooterMaster();

                MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("You Want to Print Report ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Reports_Forms.Method_Of_Manufature obj = new QTMS.Reports_Forms.Method_Of_Manufature(Convert.ToInt32(momid));
                    this.Hide();
                    obj.Show();
                }
            }
            else
            {
                DataSet ds1 = new DataSet();
                objMomMaster_Class.momid = momid;
                ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    objMomMaster_Class.adjustmentquantity = txtAdjustmentquantity.Text;
                    objMomMaster_Class.UPDATE_tblMOMFooterMaster();
                    MessageBox.Show("Record updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("You Want to Print Report ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        Reports_Forms.Method_Of_Manufature obj = new QTMS.Reports_Forms.Method_Of_Manufature(Convert.ToInt32(momid));
                        this.Hide();
                        obj.Show();
                    }
                }
                else
                {
                    objMomMaster_Class.momid = Convert.ToInt32(momid);
                    objMomMaster_Class.adjustmentquantity = txtAdjustmentquantity.Text;
                    objMomMaster_Class.Insert_tblMOMFooterMaster();

                    MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("You Want to Print Report ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        Reports_Forms.Method_Of_Manufature obj = new QTMS.Reports_Forms.Method_Of_Manufature(Convert.ToInt32(momid));
                        this.Hide();
                        obj.Show();
                    }
                }
            }

            clear();
            txtMomNo.Focus();
            btnSaveAsNew.Enabled = false;
            // tabMom.SelectedIndex = 0;
            // FrmFormulaMaster_Load(sender, e);
            //cmbMOMNo.Refresh();
            tabMom.TabPages.Remove(MOMFooter);
            tabMom.TabPages.Add(MOMtab);
            tabMom.SelectedTab = MOMtab;
            Bind_cmbMomno();
            BtnDelete.Enabled = false;
            txtSrNo.Text = "";
            txtPrintSquenceNo.Text = "";
            modify = false;

            /*
            if (modify == false)
            {


                objMomMaster_Class.momno = cmbMOMNo.Text.ToString();
                DataSet ds = new DataSet();
                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("MOMNo is  Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    cmbMOMNo.Focus();
                    btnSaveAsNew.Enabled = false;
                    // tabMom.SelectedIndex = 0;
                    // FrmFormulaMaster_Load(sender, e);

                    tabMom.TabPages.Remove(MOMFooter);
                    tabMom.TabPages.Add(MOMtab);
                    tabMom.SelectedTab = MOMtab;
                    Bind_cmbMomno();
                    BtnDelete.Enabled = false;
                    BtnModify.Enabled = false;
                    clear();
                    cmbMOMNo.Focus();
                    return;
                }


                // generate string for formula
                for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                {
                    if (checkedListFormulano.GetItemCheckState(i) == CheckState.Checked)
                    {


                        checkformula += checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) + ",";
                    }
                }
                checkformula = checkformula.TrimEnd(',');

                // generate string for vessel 

                for (int i = 0; i < cheklistVessel.Items.Count; i++)
                {
                    if (cheklistVessel.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkvessel += cheklistVessel.GetItemText(cheklistVessel.Items[i]) + ",";
                    }
                }
                checkvessel = checkvessel.TrimEnd(',');

                //generate string for AnnexTank 

                for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
                {
                    if (checkedListAnnexTank.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkannexTank += checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) + ",";
                    }
                }
                checkannexTank = checkannexTank.TrimEnd(',');



                //  objMomMaster_Class.formulaNo = CmbFormulaNo.Text.ToString();
                //   objMomMaster_Class.documentsAssoociated = txtDocumentsAssoociated.Text;
                // objMomMaster_Class.equipmentstobeused = txtEquipments.Text;
                objMomMaster_Class.formulaNo = checkformula;


                // objMomMaster_Class.fno = Convert.ToInt32(checkedListFormulano.SelectedValue.ToString());
                objMomMaster_Class.batchSize = txtBatchSize.Text;

                objMomMaster_Class.productDescription = txtProductDescription.Text;
                objMomMaster_Class.iQualityPreparedBy = txtIQPreparedby.Text;
                objMomMaster_Class.iQualityAcceptedBy = txtIQAcceptedby.Text;
                objMomMaster_Class.upAcceptedBy = txtUPAcceptedby.Text;
                objMomMaster_Class.sheAcceptedBy = txtSHEAcceptedby.Text;
                objMomMaster_Class.iSODocumentNo = txtISODocumentNo.Text;
                objMomMaster_Class.referenceDocument = txtReferenceDoc.Text;
                objMomMaster_Class.reasonforIssue = txtReason.Text;
                objMomMaster_Class.vesselId = checkvessel;
                objMomMaster_Class.annexTankId = checkannexTank;

                if (DtpIQDate.Checked == true)
                {
                    objMomMaster_Class.iQualityDate = Convert.ToDateTime(DtpIQDate.Value.ToShortDateString());
                }
                else
                {

                    objMomMaster_Class.iQualityDate = Convert.ToDateTime("1/1/1900");

                }
                if (DtpUPAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime(DtpUPAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                if (DtpSHEAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime(DtpSHEAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }


                long momid = objMomMaster_Class.Insert_MOMMaster();

                foreach (MomMaster_Class obj in li)
                {
                    objMomMaster_Class.momid = Convert.ToInt32(momid);
                    obj.momid = Convert.ToInt32(momid);

                    objMomMaster_Class.Insert_tblMOMProcessMaster(obj);

                }

                objMomMaster_Class.momid = Convert.ToInt32(momid);

                objMomMaster_Class.adjustmentquantity = txtAdjustmentquantity.Text;

                objMomMaster_Class.Insert_tblMOMFooterMaster();




                if (SaveAs == true)
                {




                    SaveAs = false;








                }


                MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("You Want to Print Report ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Reports_Forms.Method_Of_Manufature obj = new QTMS.Reports_Forms.Method_Of_Manufature(Convert.ToInt32(momid));
                    this.Hide();
                    obj.Show();




                }





                clear();
                cmbMOMNo.Focus();
                btnSaveAsNew.Enabled = false;
                // tabMom.SelectedIndex = 0;
                // FrmFormulaMaster_Load(sender, e);
                cmbMOMNo.Refresh();
                tabMom.TabPages.Remove(MOMFooter);
                tabMom.TabPages.Add(MOMtab);
                tabMom.SelectedTab = MOMtab;
                Bind_cmbMomno();
                BtnDelete.Enabled = false;
                txtSrNo.Text = "";
                txtPrintSquenceNo.Text = "";





            }

            else
            {

                // update MOM_Master code here 



                objMomMaster_Class.momno = cmbMOMNo.Text.ToString();
                DataSet ds = new DataSet();

                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("MOMNo is  Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbMOMNo.Focus();
                //    return;
                //}

                int momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());


                // generate string for formula
                for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                {
                    if (checkedListFormulano.GetItemCheckState(i) == CheckState.Checked)
                    {


                        checkformula += checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) + ",";
                    }
                }
                checkformula = checkformula.TrimEnd(',');

                // generate string for vessel 

                for (int i = 0; i < cheklistVessel.Items.Count; i++)
                {
                    if (cheklistVessel.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkvessel += cheklistVessel.GetItemText(cheklistVessel.Items[i]) + ",";
                    }
                }
                checkvessel = checkvessel.TrimEnd(',');

                //generate string for AnnexTank 

                for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
                {
                    if (checkedListAnnexTank.GetItemCheckState(i) == CheckState.Checked)
                    {
                        checkannexTank += checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) + ",";
                    }
                }



                //  objMomMaster_Class.formulaNo = CmbFormulaNo.Text.ToString();
                //   objMomMaster_Class.documentsAssoociated = txtDocumentsAssoociated.Text;
                // objMomMaster_Class.equipmentstobeused = txtEquipments.Text;
                objMomMaster_Class.formulaNo = checkformula;
                // objMomMaster_Class.fno = Convert.ToInt32(checkedListFormulano.SelectedValue.ToString());
                objMomMaster_Class.batchSize = txtBatchSize.Text;
                objMomMaster_Class.productDescription = txtProductDescription.Text;
                objMomMaster_Class.iQualityPreparedBy = txtIQPreparedby.Text;
                objMomMaster_Class.iQualityAcceptedBy = txtIQAcceptedby.Text;
                objMomMaster_Class.upAcceptedBy = txtUPAcceptedby.Text;
                objMomMaster_Class.sheAcceptedBy = txtSHEAcceptedby.Text;
                objMomMaster_Class.iSODocumentNo = txtISODocumentNo.Text;
                objMomMaster_Class.referenceDocument = txtReferenceDoc.Text;
                objMomMaster_Class.reasonforIssue = txtReason.Text;
                objMomMaster_Class.vesselId = checkvessel;
                objMomMaster_Class.annexTankId = checkannexTank;
                if (DtpIQDate.Checked == true)
                {
                    objMomMaster_Class.iQualityDate = Convert.ToDateTime(DtpIQDate.Value.ToShortDateString());
                }
                else
                {

                    objMomMaster_Class.iQualityDate = Convert.ToDateTime("1/1/1900");

                }
                if (DtpUPAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime(DtpUPAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.upAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }

                if (DtpSHEAcceptedDate.Checked == true)
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime(DtpSHEAcceptedDate.Value.ToShortDateString());
                }
                else
                {
                    objMomMaster_Class.sheAcceptedByDate = Convert.ToDateTime("1/1/1900");
                }



                objMomMaster_Class.UPDATE_tblMOMMaster();



                //update Transcation Master 

                foreach (MomMaster_Class obj in li)
                {
                    objMomMaster_Class.momid = Convert.ToInt32(momid);

                    if (obj.IsUpdate == 0)
                    {

                        objMomMaster_Class.Insert_tblMOMProcessMaster(obj);
                    }

                    else
                    {

                        objMomMaster_Class.momid = Convert.ToInt32(momid);
                        objMomMaster_Class.UPDATE_tblMOMProcessMaster(obj);


                    }

                }




                objMomMaster_Class.adjustmentquantity = txtAdjustmentquantity.Text;
                objMomMaster_Class.UPDATE_tblMOMFooterMaster();


                // update Footer Master 










                MessageBox.Show("Record updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (MessageBox.Show("You Want to Print Report ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {

                    Reports_Forms.Method_Of_Manufature obj = new QTMS.Reports_Forms.Method_Of_Manufature(Convert.ToInt32(momid));
                    this.Hide();
                    obj.Show();




                }


                clear();
                modify = false;
                tabMom.SelectedIndex = 0;
                txtAdjustmentquantity.Text = "";
                BtnModify.Enabled = false;
                cmbMOMNo.Focus();
                btnSaveAsNew.Enabled = false;
                tabMom.TabPages.Remove(MOMFooter);
                tabMom.TabPages.Add(MOMtab);
                tabMom.SelectedTab = MOMtab;
                cmbMOMNo.Refresh();
                Bind_cmbMomno();
                BtnDelete.Enabled = false;
                txtSrNo.Text = "";
                txtPrintSquenceNo.Text = "";


                //  FrmFormulaMaster_Load(sender, e);











            }

            */
        }

        private void btntab2next_Click_1(object sender, EventArgs e)
        {

            ////objMomMaster_Class.momid = momid;
            ////objMomMaster_Class.Delete_tblMOMProcessMaster_By_MOMId();

            ////foreach (MomMaster_Class obj in li)
            ////{
            ////    objMomMaster_Class.momid = Convert.ToInt32(momid);
            ////    obj.momid = Convert.ToInt32(momid);

            ////    objMomMaster_Class.Insert_tblMOMProcessMaster(obj);

            ////}

            foreach (MomMaster_Class obj in li)
            {
                objMomMaster_Class.momid = Convert.ToInt32(momid);

                if (obj.IsUpdate == 0)
                {

                    objMomMaster_Class.Insert_tblMOMProcessMaster(obj);
                }

                else
                {

                    objMomMaster_Class.momid = Convert.ToInt32(momid);
                    objMomMaster_Class.UPDATE_tblMOMProcessMaster(obj);


                }

            }


            tabMom.TabPages.Remove(MOMtab);
            tabMom.TabPages.Remove(MOMPorcess);
            tabMom.TabPages.Add(MOMFooter);



            /*
            if (SaveAs == true)
            {
                modify = false;

            }

            tabMom.SelectedIndex = tabMom.SelectedIndex + 1;

            if (modify == true)
            {
                DataSet ds1 = new DataSet();

                //ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                //momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());


                objMomMaster_Class.momid = momid;



                ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();

                txtAdjustmentquantity.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Adjustmentquantity"]);

            }
            else

                if (SaveAs == true)
                {

                    DataSet ds1 = new DataSet();
                    objMomMaster_Class.momno = oldmomno;

                    ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());


                    objMomMaster_Class.momid = momid;



                    ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();

                    txtAdjustmentquantity.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Adjustmentquantity"]);



                }
                else if (oldmomno == cmbMOMNo.Text)
                {

                    DataSet ds1 = new DataSet();

                    //ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    //momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());
                    objMomMaster_Class.momno = oldmomno;



                    ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    objMomMaster_Class.momid = momid;

                    ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();


                    txtAdjustmentquantity.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Adjustmentquantity"]);



                }


            //{
            //    DataSet ds1 = new DataSet();

            //    //ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

            //    //momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());


            //        objMomMaster_Class.momid = momid;



            //        ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();
            //        if (ds1== null)
            //        {
            //            txtAdjustmentquantity.Text = "";

            //        }
            //        else
            //        {

            //            txtAdjustmentquantity.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Adjustmentquantity"]);
            //        }
            //    }


            txtAdjustmentquantity.Focus();

            */
        }

        private void tabMom_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (tabMom.SelectedIndex == 1 || tabMom.SelectedIndex == 2)
            //{
            //    tabMom.SelectedIndex = 0;

            //    TabPage page = tabMom.TabPages[0];
            //    page.Show();


            //}
        }

        private void btnPrevioustab3_Click_1(object sender, EventArgs e)
        {
            tabMom.TabPages.Add(MOMPorcess);

            tabMom.TabPages.Remove(MOMFooter);
            tabMom.TabPages.Remove(MOMtab);
            tabMom.SelectedTab = MOMPorcess;
            //tabMom.SelectedIndex = tabMom.SelectedIndex - 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tabMom.SelectedIndex == 0)
                {
                    kaireeHTMLEditor1.Text = "";
                    //txtprocessdesc.Text = "";

                    txtSrNo.Text = "";
                    txtPrintSquenceNo.Text = "";
                    cmbdesc.Text = "SELECT";
                    checklistSafetysymbol.ClearSelected();
                    checklistAccessory.ClearSelected();
                }


                btcancel.Enabled = true;
                btnadd.Text = "Modify";
                lblrowupdateID.Text = e.RowIndex.ToString();


                btnDeleteProcess.Enabled = true;

                //// Newly added code for delete mom process grid for only last record
                //if (e.RowIndex == Convert.ToInt32(dataGridView1.Rows.Count - 1))
                //    btnDeleteProcess.Enabled = true;
                //else
                //    btnDeleteProcess.Enabled = false;

                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {
                    if (checklistSafetysymbol.GetItemChecked(i))
                    {
                        checklistSafetysymbol.SetItemChecked(i, false);
                        checklistSafetysymbol.ClearSelected();

                    }
                }

                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {
                    if (checklistAccessory.GetItemChecked(i))
                    {
                        checklistAccessory.SetItemChecked(i, false);
                        checklistAccessory.ClearSelected();

                    }
                }

                if (dataGridView1.Rows.Count > 0)
                {

                    if (dataGridView1.Rows[e.RowIndex].Cells["IsNoteProSubPro"].Value != null)
                    {

                        if (Convert.ToInt32(dataGridView1["Isupdate", e.RowIndex].Value.ToString()) == 1)
                            lblisupdate.Text = "1";
                        else
                        {
                            lblisupdate.Text = "0";
                        }

                        int isnoteprosubpro = Convert.ToInt32(dataGridView1["IsNoteProSubPro", e.RowIndex].Value.ToString());

                        if (isnoteprosubpro == 0)
                        {
                            cmbdesc.Text = "Note";
                            cmbdesc.SelectedValue = "Note";

                        }
                        else if (isnoteprosubpro == 1)
                        {
                            cmbdesc.Text = "Process";
                            cmbdesc.SelectedValue = "Process";

                        }

                        else
                        {
                            cmbdesc.Text = "SubProcess";
                            cmbdesc.SelectedValue = "SubProcess";
                        }

                    }

                    lblisupdate.Text = "1";

                    if (Convert.ToInt32(dataGridView1["Isupdate", e.RowIndex].Value.ToString()) == 1)
                    {

                        lblisnew.Text = "0";
                    }
                    else
                    {

                        lblisnew.Text = "1";
                    }



                    if (dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value != null)
                    {
                        txtSrNo.Text = dataGridView1["SerialNo", e.RowIndex].Value.ToString();
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["PrintSequenceNo"].Value != null)
                    {
                        txtPrintSquenceNo.Text = dataGridView1["PrintSequenceNo", e.RowIndex].Value.ToString();
                    }
                    //   if (dataGridView1.Rows[e.RowIndex].Cells["ProcessDesc"].Value != null)
                    //   {

                    //       kaireeHTMLEditor1.Clear();

                    //   txtprocessdesc.Text = dataGridView1["ProcessDesc", e.RowIndex].Value.ToString();

                    //    // kaireeHTMLEditor1.Text = dataGridView1["ProcessDesc", e.RowIndex].Value.ToString();

                    //kaireeHTMLEditor1.Text = txtprocessdesc.Text;


                    //   }

                    if (dataGridView1.Rows[e.RowIndex].Cells["htmlProcessDesc"].Value != null)
                    {

                        kaireeHTMLEditor1.Clear();
                        string tmphtlml = dataGridView1["htmlProcessDesc", e.RowIndex].Value.ToString();

                        tmphtlml = tmphtlml.Replace("<B>", "<STRONG>");
                        tmphtlml = tmphtlml.Replace("</B>", "</STRONG>");
                        tmphtlml = tmphtlml.Replace("<I>", "<EM>");
                        tmphtlml = tmphtlml.Replace("</I>", "</EM>");


                        kaireeHTMLEditor1.Text = tmphtlml.ToString();

                    }




                    if (dataGridView1.Rows[e.RowIndex].Cells["Symb"].Value != null)
                    {
                        string symb = dataGridView1["Symb", e.RowIndex].Value.ToString();

                        string[] symb1 = symb.Split(',');

                        for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                        {
                            for (int j = 0; j < symb1.Length; j++)
                            {
                                if (checklistSafetysymbol.GetItemText(checklistSafetysymbol.Items[i]) == symb1[j].ToString())
                                {
                                    checklistSafetysymbol.SetItemChecked(i, true);
                                }
                                else
                                {


                                }
                            }
                        }


                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells["Accsessories"].Value != null)
                    {
                        string Accsessories = dataGridView1["Accsessories", e.RowIndex].Value.ToString();

                        string[] Accsessories1 = Accsessories.Split(',');

                        for (int i = 0; i < checklistAccessory.Items.Count; i++)
                        {
                            for (int j = 0; j < Accsessories1.Length; j++)
                            {
                                if (checklistAccessory.GetItemText(checklistAccessory.Items[i]) == Accsessories1[j].ToString())
                                {
                                    checklistAccessory.SetItemChecked(i, true);
                                }

                            }
                        }


                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells["Scrapper"].Value != null)
                    {
                        if (dataGridView1["Scrapper", e.RowIndex].Value.ToString() == "")
                            cmbScarpper.Text = "--Select--";
                        else
                            cmbScarpper.Text = dataGridView1["Scrapper", e.RowIndex].Value.ToString();
                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells["Impeller"].Value != null)
                    {
                        if (dataGridView1["Impeller", e.RowIndex].Value.ToString() == "")
                            cmbImpeller.Text = "--Select--";
                        else
                            cmbImpeller.Text = dataGridView1["Impeller", e.RowIndex].Value.ToString();
                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells["Emulsifer"].Value != null)
                    {
                        if (dataGridView1["Emulsifer", e.RowIndex].Value.ToString() == "")
                            cmbemulsifer.Text = "--Select--";
                        else
                            cmbemulsifer.Text = dataGridView1["Emulsifer", e.RowIndex].Value.ToString();
                    }


                    if (dataGridView1.Rows[e.RowIndex].Cells["Vac"].Value != null)
                    {
                        if (dataGridView1["Vac", e.RowIndex].Value.ToString() == "")
                            cmbVaC.Text = "--Select--";
                        else
                            cmbVaC.Text = dataGridView1["Vac", e.RowIndex].Value.ToString();
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["Vac"].Value != null)
                    {
                        lblDetailID.Text = dataGridView1["DetailID", e.RowIndex].Value.ToString();
                        //dummysrno
                        objMomMaster_Class.dummysrno = Convert.ToInt32(dataGridView1["dummysrno", e.RowIndex].Value.ToString());
                    }

                    cmbdesc.Focus();

                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            SaveAs = true;
            BtnModify.Enabled = false;
            BtnDelete.Enabled = false;

            // oldmomno = cmbMOMNo.Text;
            MessageBox.Show("kindly Change MOM No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbMOMNo.Focus();

        }

        private void btexit_Click(object sender, EventArgs e)
        {
            if (modify == true || SaveAs == true)
            {

                MessageBox.Show("Can't Exit Without Saving Recodrs ");

            }
            else
            {
                if (MessageBox.Show("You Want to Exit  ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    //tabMom.SelectedIndex = 0;
                    //FrmFormulaMaster_Load(sender, e);
                    //clear();

                    clear();
                    cmbMOMNo.Focus();
                    btnSaveAsNew.Enabled = false;
                    // tabMom.SelectedIndex = 0;
                    // FrmFormulaMaster_Load(sender, e);

                    tabMom.TabPages.Remove(MOMFooter);
                    tabMom.TabPages.Add(MOMtab);
                    tabMom.SelectedTab = MOMtab;
                    Bind_cmbMomno();
                    BtnDelete.Enabled = false;
                    BtnModify.Enabled = false;
                    clear();



                }




            }
        }

        private void btcancle_Click(object sender, EventArgs e)
        {

            if (btnadd.Text == "Modify")
            {

                btnadd.Text = "ADD";
                btcancel.Enabled = false;
                btnDeleteProcess.Enabled = false;
                kaireeHTMLEditor1.Text = "";
                kaireeHTMLEditor1.Clear();
                // txtprocessdesc.Text = "";
                txtSrNo.Text = "";
                txtPrintSquenceNo.Text = "";
                cmbdesc.SelectedIndex = 0;
                cmbdesc.Focus();
                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {


                    if (checklistSafetysymbol.GetItemChecked(i))
                    {
                        checklistSafetysymbol.SetItemChecked(i, false);
                        checklistSafetysymbol.ClearSelected();

                    }


                }

                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {


                    if (checklistAccessory.GetItemChecked(i))
                    {
                        checklistAccessory.SetItemChecked(i, false);
                        checklistAccessory.ClearSelected();

                    }


                }



            }





        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbScarpper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            try
            {
                click = true;
                btcancel.Enabled = false;
                kaireeHTMLEditor1.Text = "";
                // txtprocessdesc.Text = "";
                txtSrNo.Text = "";
                txtPrintSquenceNo.Text = "";
                cmbdesc.SelectedIndex = 0;
                cmbdesc.Focus();
                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {


                    if (checklistSafetysymbol.GetItemChecked(i))
                    {
                        checklistSafetysymbol.SetItemChecked(i, false);
                        checklistSafetysymbol.ClearSelected();

                    }


                }

                for (int i = 0; i < checklistAccessory.Items.Count; i++)
                {


                    if (checklistAccessory.GetItemChecked(i))
                    {
                        checklistAccessory.SetItemChecked(i, false);
                        checklistAccessory.ClearSelected();

                    }


                }



                txtAdjustmentquantity.Text = "";
                BtnModify.Enabled = false;
                btnSaveAsNew.Enabled = false;
                BtnDelete.Enabled = false;

                btnadd.Text = "Add";
                btnDeleteProcess.Enabled = false;
                btnadd.Enabled = true;

                // Reset Transaction Form 
                cmbemulsifer.Text = "--Select--";
                cmbImpeller.Text = "--Select--";
                cmbScarpper.Text = "--Select--";
                cmbVaC.Text = "--Select--";
                safetysymbol = "";
                accessoris = "";
                modify = false;
                SaveAs = false;
                clear();




            }

            catch (Exception)
            {
                throw;
            }

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                List<MomMaster_Class> fill = new List<MomMaster_Class>();
                DataSet ds = new DataSet();
                objMomMaster_Class.momno = cmbMOMNo.Text;
                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());
                objMomMaster_Class.momid = momid;
                if (objMomMaster_Class.momid == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //DataSet tblMOMProcessMaster = new DataSet();

                //tblMOMProcessMaster = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();

                //int detailedId = Convert.ToInt32(tblMOMProcessMaster.Tables[0].Rows[0]["DetailID"].ToString());
                //objMomMaster_Class.detailID = detailedId;

                //DataSet tblMOMFooterMaster = new DataSet();

                //tblMOMFooterMaster =objMomMaster_Class.Select_From_tblMOMFooterMaster_By_momid();

                //int footerId = Convert.ToInt32(tblMOMFooterMaster.Tables[0].Rows[0]["FooterId"].ToString());
                //objMomMaster_Class.footerId = footerId;







                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = objMomMaster_Class.Delete_tblMOMMaster();


                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnreset_Click(sender, e);

                        BtnDelete.Enabled = false;
                        Bind_cmbMomno();
                        cmbMOMNo.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Cant Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
            //Bind_cmbMomno();
            BtnDelete.Enabled = false;
            // clear list 

            for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
            {
                if (checklistSafetysymbol.GetItemChecked(i))
                {
                    checklistSafetysymbol.SetItemChecked(i, false);
                    checklistSafetysymbol.ClearSelected();
                }


            }

            for (int i = 0; i < checklistAccessory.Items.Count; i++)
            {


                if (checklistAccessory.GetItemChecked(i))
                {
                    checklistAccessory.SetItemChecked(i, false);
                    checklistAccessory.ClearSelected();

                }


            }

            txtAdjustmentquantity.Text = "";

            BtnModify.Enabled = false;
            btnSaveAsNew.Enabled = false;

            // Reset Transaction Form 
            cmbemulsifer.Text = "--Select--";
            cmbImpeller.Text = "--Select--";
            cmbScarpper.Text = "--Select--";
            cmbVaC.Text = "--Select--";
            safetysymbol = "";
            accessoris = "";
            modify = false;
            SaveAs = false;
            dataGridView1.DataSource = null;

            momid = 0;
        }

        private void tabMom_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrevioustab2_Click(object sender, EventArgs e)
        {

            tabMom.TabPages.Remove(MOMPorcess);
            tabMom.TabPages.Remove(MOMFooter);
            tabMom.TabPages.Add(MOMtab);
            tabMom.SelectedTab = MOMtab;

            if (momid > 0)
            {
                Fill_MOMMaster(momid);
            }


            /*
            ////tabMom_Click(sender,e);
            //tabMom.TabPages.Remove(MOMPorcess);
            //tabMom.TabPages.Remove(MOMFooter);
            //tabMom.TabPages.Add(MOMtab);
            //tabMom.SelectedTab = MOMtab;
            //tabMom.SelectedIndex = tabMom.SelectedIndex - 1;

            if (click == true || dataGridView1.DataSource == null)
            {

                tabMom.TabPages.Remove(MOMPorcess);
                tabMom.TabPages.Remove(MOMFooter);
                tabMom.TabPages.Add(MOMtab);
                tabMom.SelectedTab = MOMtab;

                cmbMOMNo.Refresh();
                Bind_cmbMomno();
                cmbMOMNo.Focus();

                click = false;
            }
            else
            {

                MessageBox.Show("Reset First ");

            }
           */
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMOMNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMOMNo.Refresh();
        }

        private void btnDeleteProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int TmpDetailID = Convert.ToInt32(lblDetailID.Text);
                if (TmpDetailID == 0)
                {
                    for (int i = 0; i < li.Count; i++)
                    {
                        if (li[i].dummysrno == objMomMaster_Class.dummysrno)
                        {
                            li.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    objMomMaster_Class.detailID = TmpDetailID;
                    bool b = objMomMaster_Class.Delete_tblMOMProcessMaster_DetailID();
                    if (b == true)
                    {
                        for (int i = 0; i < li.Count; i++)
                        {
                            if (li[i].detailID == TmpDetailID)
                            {
                                li.RemoveAt(i);
                            }
                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = li;
                MessageBox.Show("Record Deleted successfully !!!!");

                btnDeleteProcess.Enabled = false;

                cmbScarpper.Text = "select";
                checklistAccessory.ClearSelected();
                checklistSafetysymbol.ClearSelected();
                kaireeHTMLEditor1.Clear();
                //txtprocessdesc.Text = "";
                btnadd.Text = "ADD";
                if (btnadd.Text == "ADD")
                {
                    btcancel.Enabled = false;

                }

                int result1 = 0;
                lblisupdate.Text = "0";
                cmbdesc.Text = null;
                cmbdesc.Focus();

                //if (Convert.ToInt32(dataGridView1["detailID", dataGridView1.Rows.Count - 1].Value) > 0)
                //{
                //    objMomMaster_Class.detailID = Convert.ToInt32(dataGridView1["detailID", dataGridView1.Rows.Count - 1].Value);
                //    bool b = objMomMaster_Class.Delete_tblMOMProcessMaster();
                //    if (b == true)
                //    {
                //        MessageBox.Show("Record Deleted successfully !!!!");
                //        btnnext_Click(sender, e);
                //    }
                //}
                //else
                //{

                //    //dataGridView1.Rows.Remove();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkIndestrial_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIndestrial.Checked == true)
            {
                txtIQAcceptedby.Enabled = true;
                DtpIQDate.Enabled = true;
                txtIQAcceptedby.BackColor = Color.White;
            }
            else
            {
                txtIQAcceptedby.Enabled = false;
                DtpIQDate.Enabled = false;
                txtIQAcceptedby.BackColor = Color.FromArgb(242, 246, 252);
                txtIQAcceptedby.Focus();
            }
        }

        private void ChkUp_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUp.Checked == true)
            {
                txtUPAcceptedby.Enabled = true;
                DtpUPAcceptedDate.Enabled = true;
                txtUPAcceptedby.BackColor = Color.White;
                txtUPAcceptedby.Focus();
            }
            else
            {
                txtUPAcceptedby.Enabled = false;
                DtpUPAcceptedDate.Enabled = false;
                txtUPAcceptedby.BackColor = Color.FromArgb(242, 246, 252);
            }
        }

        private void ChkSHE_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSHE.Checked == true)
            {
                txtSHEAcceptedby.Enabled = true;
                DtpSHEAcceptedDate.Enabled = true;
                txtSHEAcceptedby.BackColor = Color.White;
                txtSHEAcceptedby.Focus();
            }
            else
            {
                txtSHEAcceptedby.Enabled = false;
                DtpSHEAcceptedDate.Enabled = false;
                txtSHEAcceptedby.BackColor = Color.FromArgb(242, 246, 252);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsFormulaDetails.Tables[0].DefaultView.RowFilter = "FormulaNo like  '" + searchString + "%'";


            checkedListFormulano.DataSource = dsFormulaDetails.Tables[0];
            checkedListFormulano.DisplayMember = "FormulaNo";
            checkedListFormulano.ValueMember = "FNo";

            //ChkTankNo.DataSource = dsTankDetails.Tables[0];

            //ChkTankNo.DisplayMember = "TkDesc";
            //ChkTankNo.ValueMember = "TankNo";

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (lstTankDesc.Count > 0)
                {
                    for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                    {
                        foreach (string var in lstTankDesc)
                        {
                            RestrictAtListIteration = true;
                            if (var.Equals(Convert.ToString(checkedListFormulano.GetItemText(checkedListFormulano.Items[i])), StringComparison.CurrentCultureIgnoreCase))
                            {
                                checkedListFormulano.SetItemCheckState(i, CheckState.Checked);
                                //ChkTankNo.SetSelected(i, true);
                            }
                        }
                    }
                    RestrictAtListIteration = false;
                }
            }
        }

        bool RestrictAtListIteration = false;
        List<string> lstTankDesc = new List<string>();

        private void txtSerachMom_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSerachMom_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSerachMom.Text;
            dsList.Tables[0].DefaultView.RowFilter = " MOMNo like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "MOMNo";
            List.ValueMember = "MOMId";
        }

        private void txtSerachMom_KeyUp(object sender, KeyEventArgs e)
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

        private void txtSerachMom_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            clear();

            if (tabMom.SelectedTab.Text.ToString() == "MomMaster ")
            { }
            else
            {
                tabMom.TabPages.Remove(MOMPorcess);
                tabMom.TabPages.Remove(MOMFooter);
                tabMom.TabPages.Add(MOMtab);
                tabMom.SelectedTab = MOMtab;
            }

           

            momid = Convert.ToInt32(List.SelectedValue.ToString());
            Fill_MOMMaster(momid);
            modify = true;
            BtnDelete.Enabled = true;
        }


        public void Fill_MOMMaster(int momid)
        {
            DataSet ds = new DataSet();
            objMomMaster_Class.momid = momid;


            ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMId();

            if (ds.Tables[0].Rows.Count > 0)
            {
                // split FormulaNo here and shows check list 
                string frno = ds.Tables[0].Rows[0]["FormulaNo"].ToString();
                string[] frno1 = frno.Split(',');

                for (int i = 0; i < checkedListFormulano.Items.Count; i++)
                {
                    for (int j = 0; j < frno1.Length; j++)
                    {
                        lstTankDesc.Add(frno1[j].ToString());
                        if (checkedListFormulano.GetItemText(checkedListFormulano.Items[i]) == frno1[j].ToString())
                        {
                            checkedListFormulano.SetItemChecked(i, true);
                        }
                    }
                }


                string VesselId = ds.Tables[0].Rows[0]["VesselId"].ToString();
                string[] VesselId1 = VesselId.Split(',');

                for (int i = 0; i < cheklistVessel.Items.Count; i++)
                {
                    for (int j = 0; j < VesselId1.Length; j++)
                    {
                        if (cheklistVessel.GetItemText(cheklistVessel.Items[i]) == VesselId1[j].ToString())
                        {
                            cheklistVessel.SetItemChecked(i, true);
                        }
                    }
                }


                string AnnexTank = ds.Tables[0].Rows[0]["AnnexTankId"].ToString();
                string[] AnnexTank1 = AnnexTank.Split(',');

                for (int i = 0; i < checkedListAnnexTank.Items.Count; i++)
                {
                    for (int j = 0; j < AnnexTank1.Length; j++)
                    {
                        if (checkedListAnnexTank.GetItemText(checkedListAnnexTank.Items[i]) == AnnexTank1[j].ToString())
                        {
                            checkedListAnnexTank.SetItemChecked(i, true);
                        }
                    }
                }

                txtBatchSize.Text = ds.Tables[0].Rows[0]["BatchSize"].ToString();
                txtMomNo.Text = ds.Tables[0].Rows[0]["MOMNo"].ToString();
                txtProductDescription.Text = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
                txtIQPreparedby.Text = ds.Tables[0].Rows[0]["IQualityPreparedBy"].ToString();
                txtIQAcceptedby.Text = ds.Tables[0].Rows[0]["IQualityAcceptedBy"].ToString();
                txtUPAcceptedby.Text = ds.Tables[0].Rows[0]["UPAcceptedBy"].ToString();
                txtSHEAcceptedby.Text = ds.Tables[0].Rows[0]["SHEAcceptedBy"].ToString();

                // txtDocumentsAssoociated.Text = ds.Tables[0].Rows[0]["DocumentsAssoociated"].ToString();


                //   txtEquipments.Text = ds.Tables[0].Rows[0]["Equipmentstobeused"].ToString();


                txtReason.Text = ds.Tables[0].Rows[0]["ReasonforIssue"].ToString();
                txtReferenceDoc.Text = ds.Tables[0].Rows[0]["ReferenceDocument"].ToString();
                txtISODocumentNo.Text = ds.Tables[0].Rows[0]["ISODocumentNo"].ToString();

                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["IQualityDate"]) == Convert.ToDateTime("1/1/1900"))
                {
                    DtpIQDate.Value = Comman_Class_Obj.Select_ServerDate();

                    DtpIQDate.Checked = false;
                }
                else
                {
                    DtpIQDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["IQualityDate"].ToString());
                    DtpIQDate.Checked = true;

                }
                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["UPAcceptedByDate"]) == Convert.ToDateTime("1/1/1900"))
                {
                    DtpUPAcceptedDate.Value = Comman_Class_Obj.Select_ServerDate();

                    DtpUPAcceptedDate.Checked = false;
                }
                else
                {
                    DtpUPAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["UPAcceptedByDate"].ToString());
                    DtpUPAcceptedDate.Checked = true;

                }
                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["SHEAcceptedByDate"]) == Convert.ToDateTime("1/1/1900"))
                {
                    DtpSHEAcceptedDate.Value = Comman_Class_Obj.Select_ServerDate();

                    DtpSHEAcceptedDate.Checked = false;
                }
                else
                {
                    DtpSHEAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["SHEAcceptedByDate"].ToString());
                    DtpSHEAcceptedDate.Checked = true;

                }


            }

            DataSet ds1 = new DataSet();
            objMomMaster_Class.momid = momid;
            ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtAdjustmentquantity.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Adjustmentquantity"]);

            }
        }

    }
}