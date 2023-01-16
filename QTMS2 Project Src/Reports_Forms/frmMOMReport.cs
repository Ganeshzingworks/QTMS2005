using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class frmMOMReport : Form
    {
        public frmMOMReport()
        {
            InitializeComponent();
        }


        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        VesselMaster_Class VesselMaster_Class_obj = new VesselMaster_Class();
        DataSet ds1 = new DataSet();

        public void BtnShow_Click(object sender, EventArgs e)
        {


            MomMaster_Class objMomMaster_Class = new MomMaster_Class();
            objMomMaster_Class.momno = cmbmom.Text.ToString();

            DataSet ds = new DataSet();

            if (cmbmom.Enabled == true)
            {
                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();




            }
            else
            {

                objMomMaster_Class.formulaNo = cmbformula.Text.ToString();
                objMomMaster_Class.batchSize = txtBatchsize.Text.ToString();
                if (txtvessel.Visible == true)
                {
                    objMomMaster_Class.vesselId = txtvessel.Text.ToString();

                }
                else
                {

                    objMomMaster_Class.vesselId = cmbVesselNo.Text.ToString();
                }

                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_FBV();




            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Method_Of_Manufature obj = new Method_Of_Manufature(Convert.ToInt32(ds.Tables[0].Rows[0]["momid"]));
                //obj.Show();


                //this.WindowState = FormWindowState.Maximized;
                //Painter.Paint(this);


                DataSet dsmommaster = new DataSet();
                DataSet dsmomdetails = new DataSet();
                DataSet dsmomfooter = new DataSet();


                objMomMaster_Class.momid = Convert.ToInt32(ds.Tables[0].Rows[0]["momid"]);

                // objMomMaster_Class.momid = momid1;

                //  momid = momid1;

                dsmommaster = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMId();
                // Reports.momds ds = new QTMS.Reports.momds();
                DataTable dt = dsmommaster.Tables[0];

                dt.TableName = "STP_SELECT_tblMOMMaster_MOMId";
                Reports.rptmom momObj = new QTMS.Reports.rptmom();
                momObj.SetDataSource(dt);



                DataSet qualityissue = new DataSet();
                QualityIssueMaster_class objQualityIssueMaster_class = new QualityIssueMaster_class();
                qualityissue = objQualityIssueMaster_class.Select_tblQualityIssue();
                DataTable Qissue = qualityissue.Tables[0];
                Qissue.TableName = "STP_Select_tblQualityIssue";




                DataSet Document = new DataSet();
                DocumentMaster objDocumentMaster = new DocumentMaster();
                Document = objDocumentMaster.Select_tblDocumentAssociatedDetails();
                DataTable doc = Document.Tables[0];
                doc.TableName = "STP_Select_tblDocumentAssociatedDetails";


                //   momObj.SetDataSource(qualityissue.Tables[0]);








                objMomMaster_Class = new MomMaster_Class();

                //objMomMaster_Class.momid = momid1;

                objMomMaster_Class.momid = Convert.ToInt32(ds.Tables[0].Rows[0]["momid"]);

                dsmomdetails = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();

                DataTable dt1 = dsmomdetails.Tables[0];

                dt.TableName = "STP_tblMOMProcessMaster_By_MOMId";



                objMomMaster_Class = new MomMaster_Class();
                objMomMaster_Class.momid = Convert.ToInt32(ds.Tables[0].Rows[0]["momid"]);


                //objMomMaster_Class.momid = momid1;
                dsmomfooter = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();
                DataTable dtmomfooter = dsmomfooter.Tables[0];
                dtmomfooter.TableName = "STP_tblMOMFooterMaster_By_MOMId";
                objQualityIssueMaster_class = new QualityIssueMaster_class();
                momObj.Subreports["Qualityissue"].SetDataSource(qualityissue.Tables[0]);
                momObj.Subreports["DocumentAssociatedDetails"].SetDataSource(Document.Tables[0]);
                momObj.Subreports["momdetails"].SetDataSource(dsmomdetails.Tables[0]);
                momObj.Subreports["MomFooter"].SetDataSource(dsmomfooter.Tables[0]);

                rptviewmom.ReportSource = momObj;
                rptviewmom.Show();




            }
            else
            {

                MessageBox.Show("No Report found ");
            }



        }

        private void panelMid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Bind_CmbFormulaNo()
        {
            // DataRow dr;
            DataSet ds = new DataSet();
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();


            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbformula.DataSource = ds.Tables[0];
                cmbformula.DisplayMember = "FormulaNo";
                cmbformula.ValueMember = "FNo";
            }
        }


        //public void Bind_vessel()
        //{
        //    DataRow dr;
        //    DataSet ds = new DataSet();
        //    ds = VesselMaster_Class_obj.Select_tblVesselMaster();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        cmbVesselNo.DataSource = ds.Tables[0];
        //        cmbVesselNo.DisplayMember = "VslDesc";
        //        cmbVesselNo.ValueMember = "VesselNo";
        //    }
        //}
        private void frmMOMReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_CmbFormulaNo();

            // Bind_vessel();
            cmbVesselNo.Enabled = true;


            //DataRow dr;
            DataSet ds = new DataSet();
            MomMaster_Class objMomMaster_Class = new MomMaster_Class();
            ds = objMomMaster_Class.SELECT_tblMOMMaster();


            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbmom.DataSource = ds.Tables[0];
                cmbmom.DisplayMember = "MOMNo";
                cmbmom.ValueMember = "MOMNo";
            }
            this.rptviewmom.RefreshReport();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbmom.SelectedIndex = 0;
            cmbVesselNo.Enabled = true;
            cmbformula.Enabled = true;
            cmbmom.Enabled = true;
            txtBatchsize.Enabled = true;
            txtvessel.Text = "";
            cmbVesselNo.Text = "";
            txtBatchsize.Text = "";



        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbmom.SelectedValue.ToString() != "")
            {
                cmbformula.Enabled = false;
                txtBatchsize.Enabled = false;
                cmbVesselNo.Enabled = false;
            }




        }

        private void cmbformula_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbformula.SelectedValue.ToString() != "")
            {

                cmbmom.Enabled = false;

            }
        }

        private void txtBatchsize_Leave(object sender, EventArgs e)
        {

            MomMaster_Class objMomMaster_Class = new MomMaster_Class();
            objMomMaster_Class.formulaNo = "%" + cmbformula.Text.ToString() + "%";
            objMomMaster_Class.batchSize = txtBatchsize.Text.ToString();

            ds1 = objMomMaster_Class.Select_From_tblMOMMaster_Vessel();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count <= 1)
                {
                    txtvessel.Visible = true;
                    cmbVesselNo.Visible = false;
                    txtvessel.Text = ds1.Tables[0].Rows[0]["VesselId"].ToString();

                }
                else
                {

                    cmbVesselNo.DataSource = ds1.Tables[0];
                    cmbVesselNo.DisplayMember = "VesselId";
                    cmbVesselNo.ValueMember = "VesselId";

                }
            }


        }
    }









}
