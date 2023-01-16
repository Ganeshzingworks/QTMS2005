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
using BusinessFacade.Transactions;
using BusinessFacade.Scoop_Class;

namespace QTMS.Scoop
{
    public partial class frmUPDefect : Form
    {
        frmScoopUPTest FrmHere; 
        UPdefect_Class UPdefect_Class_Obj = new UPdefect_Class();
        UPdefect_Class UPdefect_Class_Obj_Here;
        public bool RecordExistinCach_UPTestAtSamplingPoint, RecordExistinCach_Defect;
        public Int64 LastAddedUPTestAtSamplingPoint, UPTestAtSamplingPointID; 
        public int rowindex;
        public bool recordexist = false;
        public string defectType, AQLlevel;
        public bool UPTestAtsamplingpointSaved;
        DataSet DSDefect;

        #region Constructor
        public frmUPDefect(frmScoopUPTest frm)
        {
            InitializeComponent();
            FrmHere = frm;
        }

        public frmUPDefect(frmScoopUPTest frm,UPdefect_Class obj)
        {
            InitializeComponent();
            FrmHere = frm;
            UPdefect_Class_Obj_Here = obj;
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHere.canceled = true;
        }

        private void frmDefectMajore_Load(object sender, EventArgs e)
        {
            try
            {
                if (AQLlevel == "AQLM1")
                {
                    int CellValue = Convert.ToInt32(FrmHere.dgvTest.Rows[rowindex].Cells["AQLM1"].Value);
                    if (CellValue <= 3)
                        pnlAQLM1.Visible = true;
                    else
                        pnlAQLM1.Visible = false;
                }


                Painter.Paint(this);

                #region Code(Master First then slave concept)
                //if (RecordExistinCach_UPTestAtSamplingPoint && RecordExistinCach_Defect)
                //{
                //    txtNameOFDefect.Text = UPdefect_Class_Obj_Here.defectname;
                //    txtTreatment.Text = UPdefect_Class_Obj_Here.treatment;
                //    txtCompleteProductionstudy.Text = UPdefect_Class_Obj_Here.completedproductimpactstudy;
                //    txtCorrectiveprocessactin.Text = UPdefect_Class_Obj_Here.correctiveactiontaken;
                //    return;
                //}
                #endregion

                if (recordexist)
                {
                    UPdefect_Class_Obj.aqllevel = AQLlevel;
                    UPdefect_Class_Obj.uptestatsamplingpointid = UPTestAtSamplingPointID;
                    if (DSDefect != null)
                    {
                        DSDefect.Clear();
                    }
                    else
                    {
                        DSDefect = new DataSet();
                    }
                    DSDefect = UPdefect_Class_Obj.Select_tblUPTestDefectByUPTstAtsamplingPoint();
                    if (DSDefect.Tables[0].Rows.Count > 0)
                    {
                        txtNameOFDefect.Text = DSDefect.Tables[0].Rows[0]["DefectName"].ToString(); 
                        txtCompleteProductionstudy.Text = DSDefect.Tables[0].Rows[0]["CompletedProductImpactStudy"].ToString();
                        txtCorrectiveprocessactin.Text = DSDefect.Tables[0].Rows[0]["CorrectiveActionTaken"].ToString();
                        txtTreatment.Text = DSDefect.Tables[0].Rows[0]["Treatment"].ToString();
                        txtdefectdescription.Text = DSDefect.Tables[0].Rows[0]["DefectDescription"].ToString();
                        txtdefectdescription.Text = DSDefect.Tables[0].Rows[0]["Actiontaken"].ToString();

                        if (FrmHere.up_here_Obj != null)
                        {
                            txtNameOFDefect.ReadOnly = true;
                            txtCompleteProductionstudy.ReadOnly = true;
                            txtCorrectiveprocessactin.ReadOnly = true;
                            txtTreatment.ReadOnly = true;
                            txtdefectdescription.ReadOnly = true;
                            txttakenaction.ReadOnly = true;
                        }
                    }
                    else
                    {
                       // MessageBox.Show("No record..", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            { 
            
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHere.canceled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try    
            {
                #region Code master first then slave
                //if (RecordExistinCach_UPTestAtSamplingPoint)
                //{
                //    if (!RecordExistinCach_Defect)//<----------------- keep on adding in the list if for this aqllevel the test is not saved before
                //    {
                //        UPdefect_Class_Obj.completedproductimpactstudy = txtCompleteProductionstudy.Text;
                //        UPdefect_Class_Obj.correctiveactiontaken = txtCorrectiveprocessactin.Text;
                //        UPdefect_Class_Obj.defectname = txtNameOFDefect.Text;
                //        UPdefect_Class_Obj.defecttype = "Majore";
                //        UPdefect_Class_Obj.treatment = txtTreatment.Text;
                //        UPdefect_Class_Obj.uptestatsamplingpointid = UPTestAtSamplingPointID;
                //        UPdefect_Class_Obj.aqllevel = AQLlevel;
                //        FrmHere.dgvTest.Rows[rowindex].Cells["TestDefect"].Value = "Yes";
                //        // FrmHere.up_here_Obj.UPdefect_Class_ObjList.Add(UPdefect_Class_Obj);
                //        FrmHere.updefect_Class_ObjList.Add(UPdefect_Class_Obj);
   
                //        FrmHere.canceled = false;
                //        FrmHere.Defect = true;
                //        FrmHere.chkLastSample.Checked = false;
                //        FrmHere.chkLastSample.Enabled = false;
                //        MessageBox.Show("Saved Succesfully..");
                //        this.Close();
                //        return;
                //    }

                //}
               

                //if (RecordExistinCach_UPTestAtSamplingPoint)
                //{
                //    int ind;
                //    if (RecordExistinCach_Defect)//<----------------- keep on adding in the list if for this aqllevel the test is not saved before
                //    {
                //        UPdefect_Class_Obj = FrmHere.up_here_Obj.UPdefect_Class_ObjList.Find(p => p.uptestatsamplingpointid == UPdefect_Class_Obj_Here.uptestatsamplingpointid && p.aqllevel == UPdefect_Class_Obj_Here.aqllevel);
                //        ind=FrmHere.up_here_Obj.UPdefect_Class_ObjList.FindIndex(p => p.uptestatsamplingpointid == UPdefect_Class_Obj_Here.uptestatsamplingpointid && p.aqllevel == UPdefect_Class_Obj_Here.aqllevel);
                //        UPdefect_Class_Obj.completedproductimpactstudy = txtCompleteProductionstudy.Text;
                //        UPdefect_Class_Obj.correctiveactiontaken = txtCorrectiveprocessactin.Text;
                //        UPdefect_Class_Obj.defectname = txtNameOFDefect.Text;
                //        UPdefect_Class_Obj.defecttype = "Majore";
                //        UPdefect_Class_Obj.treatment = txtTreatment.Text;
                //       // FrmHere.dgvTest.Rows[rowindex].Cells["TestDefect"].Value = "Yes";
                //        FrmHere.up_here_Obj.UPdefect_Class_ObjList[ind] = UPdefect_Class_Obj;
                //        //===================================================================================================//
                //        FrmHere.canceled = false;
                //        FrmHere.Defect = true;
                //        FrmHere.chkLastSample.Checked = false;
                //        FrmHere.chkLastSample.Enabled = false;
                //        MessageBox.Show("Saved Succesfully..");
                //        this.Close();
                //        return;
                //    }

                //}

                #endregion

                if (AQLlevel == "AQLM1")
                {
                    int CellValue = Convert.ToInt32(FrmHere.dgvTest.Rows[rowindex].Cells["AQLM1"].Value);
                    if (CellValue <= 3)
                    {
                        if (txtNameOFDefect.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Defect Name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtCorrectiveprocessactin.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Corrective actions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtdefectdescription.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Defect Description.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txttakenaction.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Action Taken.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        if (txtNameOFDefect.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Defect Name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtCorrectiveprocessactin.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Corrective actions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtCompleteProductionstudy.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Production Impact study.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtTreatment.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please enter the Treatments.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    if (txtNameOFDefect.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the Defect Name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (txtCorrectiveprocessactin.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the Corrective actions.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (txtCompleteProductionstudy.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the Production Impact study.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (txtTreatment.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the Treatments.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (!recordexist)//<-----------if record not exist in databse already
                {

                    //======================= ADDING UPDEFECTCLASSOBJ TO UPMASTERS LIST =================================//
                    // FrmHere.up_here_Obj.UPdefect_Class_ObjList.Add(UPdefect_Class_Obj);
                    // FrmHere.updefect_Class_ObjList.Add(UPdefect_Class_Obj);
                    //===================================================================================================//

                    FrmHere.canceled = false;
                    if (AQLlevel != "AQLM1")
                    {
                        FrmHere.Defect = true;
                    }
                    else
                    {
                        FrmHere.Defect = false;
                    }
                    FrmHere.chkLastSample.Checked = false;
                    FrmHere.chkLastSample.Enabled = false;

                    Save_UPDefect(rowindex);//Convert.ToInt64(FrmHere.dgvTest.Rows[rowindex].Tag.ToString()));
                    // Save_UPDefect();
                    MessageBox.Show("Saved Succesfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  FrmHere.btnCancel.Enabled = false;
                    this.Close();
                }
                else if(DSDefect != null && DSDefect.Tables[0].Rows.Count==0)
                {

                    FrmHere.canceled = false;
                    if (AQLlevel != "AQLM1")
                    {
                        FrmHere.Defect = true;
                    }
                    else
                    {
                        FrmHere.Defect = false;
                    }
                    FrmHere.chkLastSample.Checked = false;
                    FrmHere.chkLastSample.Enabled = false;

                    Save_UPDefect(rowindex);//Convert.ToInt64(FrmHere.dgvTest.Rows[rowindex].Tag.ToString()));
                    // Save_UPDefect();
                    MessageBox.Show("Saved Succesfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  FrmHere.btnCancel.Enabled = false;
                    this.Close();
                }
                else
                {
                    if (FrmHere.up_here_Obj == null)
                    {
                        if (DSDefect.Tables.Count > 0)
                        {
                            if (DSDefect.Tables[0].Rows.Count > 0)
                            {
                                UPdefect_Class_Obj.completedproductimpactstudy = txtCompleteProductionstudy.Text;
                                UPdefect_Class_Obj.correctiveactiontaken = txtCorrectiveprocessactin.Text;
                                UPdefect_Class_Obj.treatment = txtTreatment.Text;
                                UPdefect_Class_Obj.defectId = Convert.ToInt64(DSDefect.Tables[0].Rows[0]["DefectId"]);
                                UPdefect_Class_Obj.defectdescription = txtdefectdescription.Text;
                                UPdefect_Class_Obj.actiontaken = txttakenaction.Text;
                                UPdefect_Class_Obj.Update_tblUPDefect();
                                MessageBox.Show("Record Updated Succesfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }

            }
            catch
            {

            }
            this.Close();
        }

        private void Save_UPDefect(int rwINDX)
        {
            try
            {
                UPdefect_Class_Obj.completedproductimpactstudy = txtCompleteProductionstudy.Text;
                UPdefect_Class_Obj.correctiveactiontaken = txtCorrectiveprocessactin.Text;
                UPdefect_Class_Obj.defectname = txtNameOFDefect.Text;
                UPdefect_Class_Obj.defecttype = "Majore";
                UPdefect_Class_Obj.treatment = txtTreatment.Text;
                UPdefect_Class_Obj.uptestatsamplingpointid =rwINDX;//Passing temperory rowindex in uptestatsamplingpointid;
                UPdefect_Class_Obj.aqllevel = AQLlevel;
                UPdefect_Class_Obj.defectdescription = txtdefectdescription.Text;
                UPdefect_Class_Obj.actiontaken = txttakenaction.Text;

                FrmHere.list_UpDefect_Obj.Add(UPdefect_Class_Obj);
                if (AQLlevel != "AQLM1")
                {
                    FrmHere.dgvTest.Rows[rowindex].Cells["TestDefect"].Value = "Yes";
                    
                }
                else
                {
                    FrmHere.dgvTest.Rows[rowindex].Cells["TestDefect"].Value = "No";

                }
               
            }
            catch
            {

            }
        }

        //private void Save_UPDefect()
        //{
        //    try
        //    {
        //        UPdefect_Class_Obj.completedproductimpactstudy = txtCompleteProductionstudy.Text;
        //        UPdefect_Class_Obj.correctiveactiontaken = txtCorrectiveprocessactin.Text;
        //        UPdefect_Class_Obj.defectname = txtNameOFDefect.Text;
        //        UPdefect_Class_Obj.defecttype = "Majore";
        //        UPdefect_Class_Obj.treatment = txtTreatment.Text;
        //        // UPdefect_Class_Obj.uptestatsamplingpointid =ID;
        //        UPdefect_Class_Obj.aqllevel = AQLlevel;
        //        // UPdefect_Class_Obj.insert_tblUPTestDefect();
        //        FrmHere.list_UpDefect_Obj.Add(UPdefect_Class_Obj);
        //        FrmHere.dgvTest.Rows[rowindex].Cells["TestDefect"].Value = "Yes";

        //    }
        //    catch
        //    {

        //    }
        //}

      
      
    }
}
