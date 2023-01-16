using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Reports;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class Method_Of_Manufature : Form
    {
        int  momid1;
        public Method_Of_Manufature(int  paramomid )
        {
            momid1 = paramomid;
            
                      InitializeComponent();
        }

        public void rptview_Load(object sender, EventArgs e)
        {
           

        }

       

    
        private void viewrpt_Load(object sender, EventArgs e)
        {

        }

        private void Method_Of_Manufature_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);


            DataSet dsmommaster = new DataSet();
            DataSet dsmomdetails = new DataSet();
            DataSet dsmomfooter = new DataSet();
            MomMaster_Class objMomMaster_Class = new MomMaster_Class();
            objMomMaster_Class.momid = momid1;
            //  momid = momid1;
            dsmommaster = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMId();
            momds ds = new momds();
            DataTable dt = dsmommaster.Tables[0];
            dt.TableName = "STP_SELECT_tblMOMMaster_MOMId";
            Reports.rptmom momObj = new QTMS.Reports.rptmom();
            momObj.SetDataSource(dt);




            objMomMaster_Class = new MomMaster_Class();
            objMomMaster_Class.momid = momid1;
            dsmomdetails = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();
            DataTable dt1 = dsmomdetails.Tables[0];
            dt.TableName = "STP_tblMOMProcessMaster_By_MOMId";



            objMomMaster_Class = new MomMaster_Class();
            objMomMaster_Class.momid = momid1;
            dsmomfooter = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();
            DataTable dtmomfooter = dsmomfooter.Tables[0];
            dtmomfooter.TableName = "STP_tblMOMFooterMaster_By_MOMId";




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





            momObj.Subreports["Qualityissue"].SetDataSource(qualityissue.Tables[0]);
            momObj.Subreports["DocumentAssociatedDetails"].SetDataSource(Document.Tables[0]);
            momObj.Subreports["momdetails"].SetDataSource(dsmomdetails.Tables[0]);
            momObj.Subreports["MomFooter"].SetDataSource(dsmomfooter.Tables[0]);


            viewrpt.ReportSource = momObj;
            viewrpt.Show();
        }

       

        
    }
}