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
using BusinessFacade.Transactions;
using QTMS.Tools;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace QTMS.Transactions
{
    public partial class FrmFinishedGoodTestModification_SubContract : Form
    {

        public FrmFinishedGoodTestModification_SubContract()
        {
            InitializeComponent();
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();
        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
        string formulano = "";
        #endregion

        private static FrmFinishedGoodTestModification_SubContract frmFinishedGoodTestModification_Obj = null;
        public static FrmFinishedGoodTestModification_SubContract GetInstance()
        {
            if (frmFinishedGoodTestModification_Obj == null)
            {
                frmFinishedGoodTestModification_Obj = new FrmFinishedGoodTestModification_SubContract();
            }
            return frmFinishedGoodTestModification_Obj;
        }

        private void FrmFinishedGoodTestModification_SubContract_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            Bind_Location();
            Bind_InspectedBy();
            cmbDetails.Focus();
        }

        public void Bind_Details()
        {
            cmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                //those for which Kitflag is 1 
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_ModificationFinishedGoodDetails_SubContract();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmbDetails.EndUpdate();
            }
        }

        public void Bind_Location()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = RetainerLocation_Class_Obj.Select_tblRetainerLocation();
            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--Select--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbLocation.DataSource = ds.Tables[0];
                cmbLocation.DisplayMember = "Location";
                cmbLocation.ValueMember = "LocationID";
            }
        }

        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
            }
        }


        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnReset_Click(sender, e);

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {

                    FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    //Select FGdetails from fgno 
                    DataSet dsFG = new DataSet();
                    dsFG = FinishedGoodTest_SubContract_Class_Obj.Select_FinishedGood_FGDetails_SubContract();
                    if (dsFG.Tables[0].Rows.Count > 0)
                    {
                        txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
                        txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
                        //FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);

                        if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
                        {
                            FinishedGoodTest_Class_Obj.versionno = "";
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
                        }
                    }

                    //Select Bulk & Packing Details 
                    DataSet dsPkgBulk = new DataSet();
                    /* DataSet dslnkSF = new DataSet();
                     DyeKit_Class DyeKit_Class_Obj = new DyeKit_Class();// check for semifinished product
                     DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                     dslnkSF = DyeKit_Class_Obj.Select_tblLinkSF_FGTLFID();
                     if (dslnkSF.Tables[0].Rows.Count > 0)
                         dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGoodTest_SFPackingBulkTestDetails();
                     else
                         dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();*/
                    FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                    dsPkgBulk = FinishedGoodTest_SubContract_Class_Obj.Select_FinishedGood_PackingBulkTestDetails_SubContract();
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {

                        formulano = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();

                        dgKit.Rows.Add();
                        dgKit["TLFID", i].Value = dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString();
                        dgKit["FNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString();
                        dgKit["FormulaNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgKit["MfgWo", i].Value = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgKit["FGNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGNo"].ToString();
                        dgKit["FGCode", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGCode"].ToString();
                        dgKit["TrackCode", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGSupplierName"].ToString();
                        /* LineSamplePackingDetails_Class objLineSamplePackingDetails_Class = new LineSamplePackingDetails_Class();
                         objLineSamplePackingDetails_Class.tlfid = Convert.ToInt32(dsPkgBulk.Tables[0].Rows[i]["TLFID"]);
                         DataSet dsFGTLF=objLineSamplePackingDetails_Class.Select_ModificationLinePackingDetails_Details();
                         if (dsFGTLF!=null)
                         {
                             if (dsFGTLF.Tables.Count>0)
                             {
                                 if (dsFGTLF.Tables[0].Rows.Count>0)
                                 {
                                     dgKit["PkgWO", i].Value = dsFGTLF.Tables[0].Rows[0]["PkgWO"].ToString();
                                 }
                             }
                         }      */
                        dgKit["FillDate", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["FillDateFG"]).ToShortDateString();
                        dgKit["Price", i].Value = dsPkgBulk.Tables[0].Rows[i]["PriceFG"].ToString();
                        dgKit["specification", i].Value = dsPkgBulk.Tables[0].Rows[i]["specificationFG"].ToString();
                        dgKit["BatchNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["BatchNo"].ToString();
                        dgKit["Status", i].Value = dsPkgBulk.Tables[0].Rows[i]["Status"].ToString();
                    }
                    if (dsPkgBulk.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["SupplierID"]);
                        FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["FGNo"]);
                        if (dsPkgBulk.Tables[0].Rows[0]["LocationID"].ToString() != "")
                            cmbLocation.SelectedValue = Convert.ToInt32(dsPkgBulk.Tables[0].Rows[0]["LocationID"]);
                    }
                    //FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
                    DataSet ds_Pack = new DataSet();
                    ds_Pack = FinishedGoodTest_SubContract_Class_Obj.Select_MicroPhysicochemical_SubContract();

                    if (ds_Pack.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.coc = ds_Pack.Tables[0].Rows[0]["COC"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.micro = Convert.ToBoolean(ds_Pack.Tables[0].Rows[0]["Micro"]);
                        FinishedGoodTest_SubContract_Class_Obj.physicochemical = Convert.ToBoolean(ds_Pack.Tables[0].Rows[0]["Physicochemical"]);
                        FinishedGoodTest_SubContract_Class_Obj.packing = Convert.ToBoolean(ds_Pack.Tables[0].Rows[0]["Packing"]);
                    }

                    dgTest.Rows.Clear();
                    dgTest.Columns.Clear();


                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        string Column2 = dsPkgBulk.Tables[0].Rows[0]["FormulaNo"].ToString() + ' ' + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

                        DataSet ds_Formula = new DataSet();
                        FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["FNo"]);
                        ds_Formula = FinishedGoodTest_SubContract_Class_Obj.Select_CheckPreservativeTest();

                        if (FinishedGoodTest_SubContract_Class_Obj.coc != "Yes")
                        {
                            if (i == 0)
                            {
                                //Add column in dgTest for Packing
                                dgTest.Columns.Add("Packing", "Packing");
                                dgTest.Columns["Packing"].Width = 100;
                                dgTest.Columns["Packing"].ReadOnly = true;
                            }
                            //Add column in dgTest for Physicochemical
                            dgTest.Columns.Add(Column2, Column2);
                            dgTest.Columns[Column2].Width = 120;
                            dgTest.Columns[Column2].ReadOnly = true;

                            if (ds_Formula.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                                {
                                    dgTest.Columns.Add("Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), "Preservative " +

dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                                    dgTest.Columns["Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 80;
                                    dgTest.Columns["Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;
                                }
                                if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                                {
                                    dgTest.Columns.Add("Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), "Micro " + dsPkgBulk.Tables

[0].Rows[i]["MfgWo"].ToString());
                                    dgTest.Columns["Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 80;
                                    dgTest.Columns["Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;
                                }
                            }
                        }
                        else
                        {
                            if (i == 0)
                            {
                                dgTest.Columns.Add("Packing", "Packing");
                                dgTest.Columns["Packing"].Width = 100;
                                dgTest.Columns["Packing"].ReadOnly = true;
                            }
                            //if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                            {
                                dgTest.Columns.Add(Column2, Column2);
                                dgTest.Columns[Column2].Width = 120;
                                dgTest.Columns[Column2].ReadOnly = true;
                            }

                            if (ds_Formula.Tables[0].Rows.Count > 0)
                            {
                                //if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                                {
                                    if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                                    {
                                        dgTest.Columns.Add("Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), "Preservative " +

dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                                        dgTest.Columns["Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 80;
                                        dgTest.Columns["Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;
                                    }
                                }

                                if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                                {
                                    dgTest.Columns.Add("Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), "Micro " + dsPkgBulk.Tables

[0].Rows[i]["MfgWo"].ToString());
                                    dgTest.Columns["Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 80;
                                    dgTest.Columns["Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;
                                }
                            }


                        }



                        /*  1 jan 2015
                        dgTest.Rows.Clear();
                        dgTest.Columns.Clear();
                        //Add column in dgTest for Packing
                        dgTest.Columns.Add("Packing", "Packing");
                        dgTest.Columns["Packing"].Width = 100;
                        dgTest.Columns["Packing"].ReadOnly = true;

                        string Column2 = dsPkgBulk.Tables[0].Rows[0]["FormulaNo"].ToString() + ' ' + dsPkgBulk.Tables[0].Rows[0]["MfgWo"].ToString();

                        //dgTest.Columns.Add(Column2, Column2);
                        //dgTest.Columns[Column2].Width = 120;
                        //dgTest.Columns[Column2].ReadOnly = true;

                        //FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
                        DataSet dsMicro = new DataSet();
                        dsMicro = FinishedGoodTest_SubContract_Class_Obj.Select_MicroPhysicochemical_SubContract();

                        FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["FNo"]);
                        bool pres = FinishedGoodTest_SubContract_Class_Obj.Select_CheckPreservativeTest();

                        if (dsMicro.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.coc = dsMicro.Tables[0].Rows[0]["COC"].ToString();
                            FinishedGoodTest_SubContract_Class_Obj.micro = Convert.ToBoolean(dsMicro.Tables[0].Rows[0]["Micro"]);
                            FinishedGoodTest_SubContract_Class_Obj.physicochemical = Convert.ToBoolean(dsMicro.Tables[0].Rows[0]["Physicochemical"]);
                        }
                        if (pres == true)
                        {
                            dgTest.Columns.Add("Preservative", "Preservative");
                            dgTest.Columns["Preservative"].Width = 80;
                            dgTest.Columns["Preservative"].ReadOnly = true;
                        }
                        if (FinishedGoodTest_SubContract_Class_Obj.micro == true)
                        {
                            dgTest.Columns.Add("Micro", "Micro");
                            dgTest.Columns["Micro"].Width = 80;
                            dgTest.Columns["Micro"].ReadOnly = true;
                        }
                        if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                        {
                            //dgTest.Columns.Add("Physicochemical", "Physicochemical");
                            //dgTest.Columns["Physicochemical"].Width = 120;
                            //dgTest.Columns["Physicochemical"].ReadOnly = true;

                            dgTest.Columns.Add(Column2, Column2);
                            dgTest.Columns[Column2].Width = 120;
                            dgTest.Columns[Column2].ReadOnly = true;
                        }

                        */
                        if (i == 0)
                        {
                            DataSet ds1 = new DataSet();
                            //Select PkgStatus from fgno,trackcode,lno
                            FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                            ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dgTest[0, 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                                FinishedGoodTest_SubContract_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                                FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(ds1.Tables[0].Rows[0]["InspectedBy"]);
                            }
                            else
                            {
                                FinishedGoodTest_SubContract_Class_Obj.quantity = 0;
                                FinishedGoodTest_SubContract_Class_Obj.inspectedby = 0;
                            }
                        }

                        DataSet dsFMID = new DataSet();
                        FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["FGNo"]);
                        FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["FNo"]);
                        FinishedGoodTest_SubContract_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[0]["SupplierID"]);
                        FinishedGoodTest_SubContract_Class_Obj.trackcode = Convert.ToString(dsPkgBulk.Tables[0].Rows[0]["TrackCode"]);

                        dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                        if (dsFMID.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                            DataSet PhyCheStatus = new DataSet();
                            PhyCheStatus = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract();
                            if (PhyCheStatus.Tables[0].Rows.Count > 0)
                            {
                                dgTest[Column2, 0].Value = PhyCheStatus.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                                FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(PhyCheStatus.Tables[0].Rows[0]["InspectedBy"]);
                            }

                        }

                        DataSet dsTLFID = new DataSet();
                        dsTLFID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransTLF_SubContract_TLFID();
                        if (dsTLFID.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.TLFID = Convert.ToInt64(dsTLFID.Tables[0].Rows[0]["TLFID"]);

                            DataSet ds2 = new DataSet();
                            ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblMicrobiologytest_SubContract_Status();
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dgTest["Micro " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]

["Status"].ToString();
                            }
                        }

                        DataSet dsPres = new DataSet();
                        dsPres = FinishedGoodTest_SubContract_Class_Obj.Select_tblPreservativetest_SubContract_Status();
                        if (dsPres.Tables[0].Rows.Count > 0)
                        {
                            dgTest["Preservative " + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = dsPres.Tables[0].Rows[0]

["Status"].ToString();
                        }


                    }


                    /* Because we dont have PackSize and Weight
                    //Display unit PackSize and Weight
                   DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            if (dsUnit.Tables[0].Rows[0]["PackSize"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["PackSize", i].Value = dsUnit.Tables[0].Rows[0]["PackSize"].ToString();
                            }

                            if (dsUnit.Tables[0].Rows[0]["Weight"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["Weight", i].Value = dsUnit.Tables[0].Rows[0]["Weight"].ToString();
                            }
                        }
                    }
                    
                                       //Add column in dgTest for Packing
                                       dgTest.Columns.Add("Packing", "Packing");
                                       dgTest.Columns["Packing"].Width = 100;
                                       dgTest.Columns["Packing"].ReadOnly = true;

                                       //Select PkgStatus from fgno,fno,trackcode,lno and display into packing cell 
                                       DataSet ds1 = new DataSet();
                   
                                       ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                                       if (ds1.Tables[0].Rows.Count > 0)
                                       {
                                           dgTest["packing", 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                                           FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                                       }
                                       else
                                       {
                                           dgTest["packing", 0].Value = "";
                                           FinishedGoodTest_Class_Obj.quantity = 0;
                                       }

                                       //add columns in dgTest depends on no of MfgWo
                                       for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                                       {
                                           //Check whether the column exists 
                                           if (dgTest.Columns.Contains(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables

[0].Rows[i]["MfgWo"].ToString()) == false)
                                           {
                                               dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]

["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                                               dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]

["MfgWo"].ToString()].Width = 100;
                                               dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]

["MfgWo"].ToString()].ReadOnly = true;

                                               FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[i]["FNo"]);
                                               FinishedGoodTest_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

                                               DataSet ds2 = new DataSet();
                                               //Select PhyCheStatus from fgno,fno,trackcode,lno, mfgwo and display into cell
                                               if (dslnkSF.Tables[0].Rows.Count > 0)
                                                   ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_FNo_MfgWo();
                                               else
                                                   ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                                               if (ds2.Tables[0].Rows.Count > 0)
                                               {
                                                   dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]

["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                                               }
                                               else
                                               {
                                                   dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]

["MfgWo"].ToString(), 0].Value = "";
                                               }
                                           }
                                       }
                    */
                    ////GET CONTROL TYPE FROM STP_Decide_ControlType STORED PROCEDURE
                    ////2/5 LOGIC
                    //txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
                    //FinishedGoodTest_Class_Obj.type = txtControltype.Text.Trim();

                    DataSet ds = new DataSet();
                    ds = FinishedGoodTest_SubContract_Class_Obj.Select_ModificationFinishedGoodDetails_Details_SubContract();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtControltype.Text = ds.Tables[0].Rows[0]["ControlType"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.type = txtControltype.Text.Trim();

                        DtpDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["TestDate"]);

                        if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "A")
                        {
                            RdoAccepted.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "H")
                        {
                            RdoHold.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "R")
                        {
                            RdoRejected.Checked = true;
                            ChkReject.Visible = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "D")
                        {
                            RdoAWD.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "T")
                        {
                            RdoTreatment.Checked = true;
                        }

                        cmbInspectedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["InspectedBy"]);

                        if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "ZD")
                        {
                            ChkReject.SetItemChecked(0, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "ZN")
                        {
                            ChkReject.SetItemChecked(1, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Critical")
                        {
                            ChkReject.SetItemChecked(2, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Major")
                        {
                            ChkReject.SetItemChecked(3, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Minor")
                        {
                            ChkReject.SetItemChecked(4, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Bulk")
                        {
                            ChkReject.SetItemChecked(5, true);
                        }
                        else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Other")
                        {
                            ChkReject.SetItemChecked(6, true);
                        }



                        if (ds.Tables[0].Rows[0]["NoOfDefects"] is System.DBNull || ds.Tables[0].Rows[0]["NoOfDefects"].ToString() == "0")
                        {
                            txtNoOfDefects.Text = "";
                        }
                        else
                        {
                            txtNoOfDefects.Text = ds.Tables[0].Rows[0]["NoOfDefects"].ToString();
                        }

                        if (ds.Tables[0].Rows[0]["NoOfSamples"] is System.DBNull || ds.Tables[0].Rows[0]["NoOfSamples"].ToString() == "0")
                        {
                            txtNoOfSamples.Text = "";
                        }
                        else
                        {
                            txtNoOfSamples.Text = ds.Tables[0].Rows[0]["NoOfSamples"].ToString();
                        }

                        txtComment.Text = ds.Tables[0].Rows[0]["comment"].ToString();

                        if (ds.Tables[0].Rows[0]["Decision"].ToString().Trim() == "B")
                        {
                            RdoBpc.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Decision"].ToString().Trim() == "N")
                        {
                            RdoNonBpc.Checked = true;
                        }

                        txtComment_NonBpc.Text = ds.Tables[0].Rows[0]["NonBPCComment"].ToString();

                        if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "Launch")
                        {
                            RdoLaunch.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "PriceChange")
                        {
                            RdoPriceChange.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "ArtWorkChange")
                        {
                            RdoArtWorkChange.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "Renovation")
                        {
                            RdoRenovation.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "N/A")
                        {
                            RdoRegular.Checked = true;
                        }
                        if (ds.Tables[0].Rows[0]["BMRFilepath"] is System.DBNull || ds.Tables[0].Rows[0]["BMRFilepath"].ToString() == "")
                        {

                        }
                        else
                        {
                            FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = ds.Tables[0].Rows[0]["BMRFilepath"].ToString();
                            FinishedGoodTest_SubContract_Class_Obj.filename = System.IO.Path.GetFileName

(FinishedGoodTest_SubContract_Class_Obj.bmrfilepath);
                            txtBMR.Text = FinishedGoodTest_SubContract_Class_Obj.filename;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbDetails.Text = "--Select--";
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            dgKit.Rows.Clear();
            dgTest.Columns.Clear();

            //RdoAccepted.Checked = true;
            txtComment.Text = "";
            RdoBpc.Checked = false;
            RdoNonBpc.Checked = false;
            txtComment_NonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            cmbLocation.Text = "--Select--";
            txtBMR.Text = "";

            ChkReject.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";

            cmbDetails.Focus();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("please select Details", "Message");
                    return;
                }
                else
                {
                    if (GlobalVariables.City == "BADDI")
                    {
                        if (cmbLocation.SelectedValue == null || cmbLocation.Text == "--Select--")
                        {
                            MessageBox.Show("Please Select Retainer Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbLocation.Focus();
                            return;
                        }
                    }

                    //Can't ACCEPT if any pack/phyche contains 'R'
                    bool R = false;
                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "R")
                        {
                            R = true;
                            break;
                        }
                    }
                    if (RdoAccepted.Checked == true && R == true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are rejected", "Message", MessageBoxButtons.OK,

MessageBoxIcon.Information);
                        RdoRejected.Focus();
                        return;
                    }
                    bool H = false;
                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "H")
                        {
                            H = true;
                            break;
                        }
                    }
                    if ((RdoAccepted.Checked == true || RdoRejected.Checked == true || RdoAWD.Checked == true || RdoTreatment.Checked == true) && H

== true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RdoHold.Focus();
                        return;
                    }
                    if (RdoRejected.Checked && ChkReject.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Select Type for Reject.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChkReject.Focus();
                        return;
                    }

                    if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbInspectedBy.Focus();
                        return;
                    }
                    if (RdoNonBpc.Checked != true && RdoBpc.Checked != true)
                    {
                        MessageBox.Show("Select BPC/NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (RdoNonBpc.Checked && txtComment_NonBpc.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please Enter Comment For NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (RdoRegular.Checked != true && RdoLaunch.Checked != true && RdoPriceChange.Checked != true && RdoArtWorkChange.Checked != true

&& RdoRenovation.Checked != true)
                    {
                        MessageBox.Show("Select Regular/Launch", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (RdoAccepted.Checked == true)
                    {
                        if (dgTest.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgTest.Rows[0].Cells.Count; i++)
                            {
                                if (dgTest.Rows[0].Cells[i].Value.ToString().Trim() != "A")
                                {
                                    MessageBox.Show("All test must be accepted for");
                                    return;
                                }
                            }
                        }
                        if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoRejected.Checked == true)
                    {
                        if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoAWD.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals

(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoTreatment.Checked == true)
                    {
                        if (MessageBox.Show("TREATEMENT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoHold.Checked == true)
                    {
                        if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoRegular.Checked == true)
                    {
                        if (MessageBox.Show("Regular ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoLaunch.Checked == true)
                    {
                        if (MessageBox.Show("Launch ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoPriceChange.Checked == true)
                    {
                        if (MessageBox.Show("Price Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoArtWorkChange.Checked == true)
                    {
                        if (MessageBox.Show("Art Work Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoRenovation.Checked == true)
                    {
                        if (MessageBox.Show("Renovation ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    FinishedGoodTest_SubContract_Class_Obj.testdate = Convert.ToString(DtpDate.Value);

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "A";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "R";
                    }


                    //------Actual Status------

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "D";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "T";
                    }

                    FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < ChkReject.Items.Count; i++)
                    {
                        if (ChkReject.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("ZD");
                                break;
                            }
                            else if (i == 1)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("ZN");
                                break;
                            }
                            else if (i == 2)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Critical");
                                break;
                            }
                            else if (i == 3)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Major");
                                break;
                            }
                            else if (i == 4)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Minor");
                                break;
                            }
                            else if (i == 5)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Bulk");
                                break;
                            }
                            else if (i == 6)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Other");
                                break;
                            }
                        }
                    }

                    if (txtNoOfDefects.Text.Trim() != "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofdefects = 0;
                    }

                    if (txtNoOfSamples.Text.Trim() != "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofsamples = 0;
                    }

                    FinishedGoodTest_SubContract_Class_Obj.Comment = txtComment.Text.Trim();
                    if (RdoBpc.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.decision = "B";
                        FinishedGoodTest_SubContract_Class_Obj.nonbpccomment = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.decision = "N";
                        FinishedGoodTest_SubContract_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                    }


                    if (RdoLaunch.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "Launch";
                    }
                    else if (RdoPriceChange.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "PriceChange";
                    }
                    else if (RdoArtWorkChange.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "ArtWorkChange";
                    }
                    else if (RdoRenovation.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "Renovation";
                    }
                    else if (RdoRegular.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "N/A";
                    }

                    //this Flag describes that this is current record for this FGTLFID 
                    //IF any record get treatmented in treatment screen then new record added in tblFinishedGoodTestDetails which is currentflag =1 
                    //then for old record current flag is 0
                    //If record is for treatment then set currentflag =0
                    if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.currentflag = 0;
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.currentflag = 1;
                    }

                    //this flag shows the record which are under the treatment process
                    //in transaction screen treatmentdone = 0
                    //and treatmentdone = 1 for both old and newly added record in treatment screen                    
                    FinishedGoodTest_SubContract_Class_Obj.treatmentdone = 0;

                    //this flag shows record which is added after treatment 
                    //For transation screen Treatmented = 0
                    //This flag is set for only for record which is added after treatment 
                    //In Treatment screen Treatmented = 1
                    //this flag is used to avoid record while deciding control type  
                    FinishedGoodTest_SubContract_Class_Obj.treatmented = 0;

                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;

                    // FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
                    if (txtBMR.Text != "")
                    {
                        string path = ConfigurationManager.AppSettings["BMRPath"].ToString();
                        path = path + "\\" + FinishedGoodTest_SubContract_Class_Obj.filename;

                        if (path == FinishedGoodTest_SubContract_Class_Obj.bmrfilepath)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = path;
                        }
                        else
                        {
                            if (!File.Exists(path))
                            {
                                //File.Create(path);
                                File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                            }
                            else
                            {
                                File.Delete(path);
                                File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                            }

                            FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = path;
                        }
                    }


                    //ControlType
                    //LNo

                    DataSet ds1 = new DataSet();
                    //Select FGTestNo from FGTLFID
                    ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID_SubContract();
                    if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                    {
                        //update fg transaction details
                        FinishedGoodTest_SubContract_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                        FinishedGoodTest_SubContract_Class_Obj.Update_tblFinishedGoodTestDetails_SubContract();
                    }
                    else // insert
                    {
                        //insert fg transaction details
                        FinishedGoodTest_SubContract_Class_Obj.fgtestno =

FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodTestDetails_SubContract();
                    }


                    //update FGDone=1  in tblFGTLF from FGTLFID 
                    if (RdoHold.Checked != true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fgdone = true;
                        FinishedGoodTest_SubContract_Class_Obj.Update_tblFGTLF_FGDone_SubContract();
                    }

                    FinishedGoodTest_SubContract_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);
                    FinishedGoodTest_SubContract_Class_Obj.Update_RetainerLocation_Subcontract();


                    /*                   //Insert unit details
                                       DataSet dsUnit;
                                       for (int i = 0; i < dgKit.Rows.Count; i++)
                                       {
                                           dsUnit = new DataSet();
                                           FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                                           FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                                           FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                                           dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                                           if (dsUnit.Tables[0].Rows.Count > 0)
                                           {
                                               FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                                           }
                                           else
                                           {
                                               FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                                           }
                                       }

                                       FinishedGoodTest_Class_Obj.testdate = Convert.ToString(DtpDate.Value);

                                       if (RdoAccepted.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.status = "A";
                                       }
                                       else if (RdoHold.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.status = "H";
                                       }
                                       else if (RdoRejected.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.status = "R";
                                       }
                                       else if (RdoAWD.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.status = "A";
                                       }
                                       else if (RdoTreatment.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.status = "R";
                                       }


                                       //------Actual Status------

                                       if (RdoAccepted.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.actualstatus = "A";
                                       }
                                       else if (RdoHold.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.actualstatus = "H";
                                       }
                                       else if (RdoRejected.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.actualstatus = "R";
                                       }
                                       else if (RdoAWD.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.actualstatus = "D";
                                       }
                                       else if (RdoTreatment.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.actualstatus = "T";
                                       }

                                       FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("N/A");
                                       for (int i = 0; i < ChkReject.Items.Count; i++)
                                       {
                                           if (ChkReject.GetItemChecked(i) == true)
                                           {
                                               if (i == 0)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZD");
                                                   break;
                                               }
                                               else if (i == 1)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZN");
                                                   break;
                                               }
                                               else if (i == 2)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Critical");
                                                   break;
                                               }
                                               else if (i == 3)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Major");
                                                   break;
                                               }
                                               else if (i == 4)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Minor");
                                                   break;
                                               }
                                               else if (i == 5)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Bulk");
                                                   break;
                                               }
                                               else if (i == 6)
                                               {
                                                   FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Other");
                                                   break;
                                               }
                                           }
                                       }

                                       if (txtNoOfDefects.Text.Trim() != "")
                                       {
                                           FinishedGoodTest_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                                       }
                                       else
                                       {
                                           FinishedGoodTest_Class_Obj.noofdefects = 0;
                                       }

                                       if (txtNoOfSamples.Text.Trim() != "")
                                       {
                                           FinishedGoodTest_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                                       }
                                       else
                                       {
                                           FinishedGoodTest_Class_Obj.noofsamples = 0;
                                       }

                                       FinishedGoodTest_Class_Obj.Comment = txtComment.Text.Trim();
                                       if (RdoBpc.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.decision = "B";
                                           FinishedGoodTest_Class_Obj.nonbpccomment = "";
                                       }
                                       else
                                       {
                                           FinishedGoodTest_Class_Obj.decision = "N";
                                           FinishedGoodTest_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                                       }


                                       if (RdoLaunch.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.catagory = "Launch";
                                       }
                                       else if (RdoPriceChange.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.catagory = "PriceChange";
                                       }
                                       else if (RdoArtWorkChange.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.catagory = "ArtWorkChange";
                                       }
                                       else if (RdoRenovation.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.catagory = "Renovation";
                                       }
                                       else
                                       {
                                           FinishedGoodTest_Class_Obj.catagory = "N/A";
                                       }

                                       //this Flag describes that this is current record for this FGTLFID 
                                       //IF any record get treatmented in treatment screen then new record added in tblFinishedGoodTestDetails which 

is currentflag =1 
                                       //then for old record current flag is 0
                                       //If record is for treatment then set currentflag =0
                                       if (RdoTreatment.Checked == true)
                                       {
                                           FinishedGoodTest_Class_Obj.currentflag = 0;
                                       }
                                       else
                                       {
                                           FinishedGoodTest_Class_Obj.currentflag = 1;
                                       }

                                       //this flag shows the record which are under the treatment process
                                       //in transaction screen treatmentdone = 0
                                       //and treatmentdone = 1 for both old and newly added record in treatment screen                    
                                       FinishedGoodTest_Class_Obj.treatmentdone = 0;

                                       //this flag shows record which is added after treatment 
                                       //For transation screen Treatmented = 0
                                       //This flag is set for only for record which is added after treatment 
                                       //In Treatment screen Treatmented = 1
                                       //this flag is used to avoid record while deciding control type  
                                       FinishedGoodTest_Class_Obj.treatmented = 0;

                                       FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                                       FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

                                       //ControlType
                                       //LNo

                                       DataSet ds1 = new DataSet();
                                       //Select FGTestNo from FGTLFID
                                       ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID();
                                       if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                                       {
                                           FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                                           FinishedGoodTest_Class_Obj.Update_tblFinishedGoodTestDetails();
                                       }
                                       else // insert
                                       {
                                           FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTestDetails();
                                       }


                                       //update FGDone=1  in tblFGTLF from FGTLFID 
                                       if (RdoHold.Checked != true)
                                       {
                                           FinishedGoodTest_Class_Obj.fgdone = true;
                                           FinishedGoodTest_Class_Obj.Update_tblFGTLF_FGDone();
                                       }

                                       */

                    MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_Details();
                    BtnReset_Click(sender, e);
                }
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
                if ((cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // -------- Reset FGDone Flag to 0
                    FinishedGoodTest_Class_Obj.fgdone = false;
                    FinishedGoodTest_Class_Obj.Update_tblFGTLF_FGDone();

                    bool b = FinishedGoodTest_Class_Obj.Delete_tblFinishedGoodTestDetails();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_Details();
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtComment_NonBpc.Enabled = true;
            }
        }

        private void RdoBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoBpc.Checked == true)
            {
                txtComment_NonBpc.Text = "";
                txtComment_NonBpc.Enabled = false;
            }
        }

        private void RdoRejected_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRejected.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                ChkReject.Visible = true;
                lblNoOfDefets.Visible = true;
                txtNoOfDefects.Visible = true;
                lblNoOfSamples.Visible = true;
                txtNoOfSamples.Visible = true;

                //if rejected then NonBPC
                RdoNonBpc.Checked = true;
            }
        }

        private void RdoAccepted_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            ChkReject.Visible = false;
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        private void RdoHold_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            ChkReject.Visible = false;
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        private void ChkReject_Click(object sender, EventArgs e)
        {
            if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Unchecked)
            {
                ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Checked);
            }
            else if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Checked)
            {
                ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Unchecked);
            }
        }

        private void ChkReject_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Can select only one item
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < ChkReject.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        ChkReject.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void dgKit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgKit.CurrentCell.ReadOnly == false)
            {
                dgKit.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoOfDefects_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoOfSamples_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                string header = dgTest.Columns[e.ColumnIndex].HeaderText;
                //if (e.ColumnIndex == dgTest.Columns[0].Index) 
                if (header == "Packing")//Packing
                {
                    FrmFGPackingTest_SubContract.Detail detail_Obj = new FrmFGPackingTest_SubContract.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_SubContract_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_SubContract_Class_Obj.type;
                    detail_Obj.D_fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_Packing = FinishedGoodTest_SubContract_Class_Obj.packing;

                    DataSet dsF = new DataSet();
                    //FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                    dsF = FinishedGoodTest_SubContract_Class_Obj.Select_SubContract_FlagRL();
                    if (dsF.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.flagrl = 'R';

                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.flagrl = 'L';

                    }


                    detail_Obj.D_flagrl = FinishedGoodTest_SubContract_Class_Obj.flagrl;
                    detail_Obj.D_Quantity = FinishedGoodTest_SubContract_Class_Obj.quantity;
                    detail_Obj.D_InspctedBy = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
                    FinishedGoodTest_Class_Obj.fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                    detail_Obj.D_COC = FinishedGoodTest_SubContract_Class_Obj.coc;
                    detail_Obj.D_SupploerID = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                    detail_Obj.D_Supplier = dgKit["LineDesc", 0].Value.ToString();
                    detail_Obj.D_FGCode = dgKit["FGCode", 0].Value.ToString();
                    detail_Obj.D_FormulaNo = dgKit["FormulaNo", 0].Value.ToString();

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null)
                        detail_Obj.D_pkgstatus = "";
                    else
                        detail_Obj.D_pkgstatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }

                    //Display FG Packing Test form
                    FrmFGPackingTest_SubContract fmPack = new FrmFGPackingTest_SubContract(detail_Obj);
                    fmPack.ShowDialog();

                    DataSet ds1 = new DataSet();
                    //Select PkgStatus from fgno,trackcode,lno
                    ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                        FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(ds1.Tables[0].Rows[0]["InspectedBy"]);
                    }


                }
                else if (header.Contains("Preservative"))
                {
                    string Str = header;
                    Str = Str.Replace("Preservative", "");

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                    }

                    FrmPreservativeTestSubContract frmPres = new FrmPreservativeTestSubContract(FinishedGoodTest_SubContract_Class_Obj.fmid,

FinishedGoodTest_SubContract_Class_Obj.coc, FinishedGoodTest_SubContract_Class_Obj.physicochemical);
                    frmPres.ShowDialog();

                    DataSet ds2 = new DataSet();
                    ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblPreservativetest_SubContract_Status();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds2.Tables[0].Rows[0]["Status"].ToString();
                    }
                }
                else if (header.Contains("Micro"))
                {
                    string Str = header;
                    Str = Str.Replace("Micro", "");

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                    }

                    DataSet dsTLFID = new DataSet();
                    dsTLFID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransTLF_SubContract_TLFID();
                    if (dsTLFID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.TLFID = Convert.ToInt64(dsTLFID.Tables[0].Rows[0]["TLFID"]);
                    }

                    FrmMicrobiologyTest_SubContract frmMicro = new FrmMicrobiologyTest_SubContract(FinishedGoodTest_SubContract_Class_Obj.TLFID,

FinishedGoodTest_SubContract_Class_Obj.micro);
                    frmMicro.ShowDialog();

                    DataSet ds2 = new DataSet();
                    ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblMicrobiologytest_SubContract_Status();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds2.Tables[0].Rows[0]["Status"].ToString();
                    }
                }
                else //if (e.ColumnIndex > 0)   //Physico-Chemical
                {
                    string Str = header;
                    Str = Str.Replace(formulano, "");

                    FrmFGPhysicoChemicalTest_SubContract.Detail detail_Obj = new FrmFGPhysicoChemicalTest_SubContract.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_SubContract_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_SubContract_Class_Obj.type;
                    detail_Obj.D_COC = FinishedGoodTest_SubContract_Class_Obj.coc;
                    //detail_Obj.D_fmid = FinishedGoodTest_SubContract_Class_Obj.fmid;
                    detail_Obj.D_inspectedby = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
                    detail_Obj.D_SupplierID = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                    detail_Obj.D_physicochemical = FinishedGoodTest_SubContract_Class_Obj.physicochemical;

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        detail_Obj.D_fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                    }


                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                        detail_Obj.D_phychestatus = "";
                    else
                        detail_Obj.D_phychestatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }
                    detail_Obj.D_FormulaNo = dgKit["FormulaNo", 0].Value.ToString();
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_mfgwo = FinishedGoodTest_SubContract_Class_Obj.mfgwo;

                    //Display FG Physico-Chemical Test form
                    FrmFGPhysicoChemicalTest_SubContract fmPhy = new FrmFGPhysicoChemicalTest_SubContract(detail_Obj);
                    fmPhy.ShowDialog();

                    DataSet PhyCheStatus = new DataSet();
                    PhyCheStatus = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract();
                    if (PhyCheStatus.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = PhyCheStatus.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                        //FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(PhyCheStatus.Tables[0].Rows[0]["InspectedBy"]);
                    }


                }
            }




        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FinishedGoodTest_SubContract_Class_Obj.filepath = openFileDialog1.FileName;
                FinishedGoodTest_SubContract_Class_Obj.filename = System.IO.Path.GetFileName(FinishedGoodTest_SubContract_Class_Obj.filepath);
                txtBMR.Text = FinishedGoodTest_SubContract_Class_Obj.filename;
                FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = "";
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (FinishedGoodTest_SubContract_Class_Obj.bmrfilepath == "" || FinishedGoodTest_SubContract_Class_Obj.bmrfilepath == null)
            {
                MessageBox.Show("No file selected to view", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //File.Open(FinishedGoodTest_SubContract_Class_Obj.bmrfilepath,FileMode.Open);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = FinishedGoodTest_SubContract_Class_Obj.bmrfilepath;
            process.Start();

        }







    }
}