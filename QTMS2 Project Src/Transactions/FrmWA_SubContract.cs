using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using System.IO;
using System.Data.OleDb;

namespace QTMS.Transactions
{
    public partial class FrmWA_SubContract : Form
    {
        public class Weighing
        {
            public long WA_WATransID;
            public char WA_Reason;
            public int WA_ObsCnt;
            public string WA_AnalysisType;
            public string WA_TorqueMin;
            public string WA_TorqueMax;
            public long WA_uptestsamplingpointid;
            public string WA_FormName;
            public int MTID;
        }

        public FrmWA_SubContract(FrmWA_SubContract.Weighing weighing)
        {
            /* FinishedGoodTest_Class_Obj.watransid = weighing.WA_WATransID;
             FinishedGoodTest_Class_Obj.reason = weighing.WA_Reason;
             FinishedGoodTest_Class_Obj.count = weighing.WA_ObsCnt;
             FinishedGoodTest_Class_Obj.analysistype = weighing.WA_AnalysisType;
             FinishedGoodTest_Class_Obj.torquemin = weighing.WA_TorqueMin;
             FinishedGoodTest_Class_Obj.torquemax = weighing.WA_TorqueMax;
             FinishedGoodTest_Class_Obj.upsamplingpointid = weighing.WA_uptestsamplingpointid;
             FinishedGoodTest_Class_Obj.form_name = weighing.WA_FormName;
             FinishedGoodTest_Class_Obj.mtid = weighing.MTID;
             */

            FinishedGoodTest_SubContract_Class_Obj.watransid = weighing.WA_WATransID;
            FinishedGoodTest_SubContract_Class_Obj.reason = weighing.WA_Reason;
            FinishedGoodTest_SubContract_Class_Obj.count = weighing.WA_ObsCnt;
            FinishedGoodTest_SubContract_Class_Obj.analysistype = weighing.WA_AnalysisType;
            FinishedGoodTest_SubContract_Class_Obj.torquemin = weighing.WA_TorqueMin;
            FinishedGoodTest_SubContract_Class_Obj.torquemax = weighing.WA_TorqueMax;
            FinishedGoodTest_SubContract_Class_Obj.upsamplingpointid = weighing.WA_uptestsamplingpointid;
            //FinishedGoodTest_SubContract_Class_Obj.form_name = weighing.WA_FormName;
            FinishedGoodTest_SubContract_Class_Obj.mtid = weighing.MTID;

            InitializeComponent();
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();

        private void FrmWA_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            this.Text = FinishedGoodTest_SubContract_Class_Obj.analysistype;

            Bind_InspectedBy();
            if (FinishedGoodTest_SubContract_Class_Obj.count == 30)
            {
                DrawGrid(5, 6);
            }
            if (FinishedGoodTest_SubContract_Class_Obj.count == 32)
            {
                DrawGrid(4, 8);
            }
            if (FinishedGoodTest_SubContract_Class_Obj.count == 50)
            {
                DrawGrid(5, 10);
            }
            if (FinishedGoodTest_SubContract_Class_Obj.count == 80)
            {
                DrawGrid(8, 10);
            }

            if (FinishedGoodTest_SubContract_Class_Obj.analysistype == "Weight" || FinishedGoodTest_SubContract_Class_Obj.analysistype == "Tare Weight")
            {
                lblAvg.Visible = true;
                txtAvg.Visible = true;

                lblMin.Visible = false;
                txtMin.Visible = false;
                lblMax.Visible = false;
                txtMax.Visible = false;
            }
            else if (FinishedGoodTest_SubContract_Class_Obj.analysistype == "Torque")
            {
                lblAvg.Visible = false;
                txtAvg.Visible = false;

                lblMin.Visible = true;
                txtMin.Visible = true;
                lblMax.Visible = true;
                txtMax.Visible = true;

                txtMin.Text = FinishedGoodTest_SubContract_Class_Obj.torquemin;
                txtMax.Text = FinishedGoodTest_SubContract_Class_Obj.torquemax;
            }
            //if (FinishedGoodTest_Class_Obj.form_name != "Scoop")
            {
                DataSet ds = new DataSet();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_tblWAObs_WATransID_SubContract();
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string str = ds.Tables[0].Rows[0]["Status"].ToString();
                    if (str.Trim() == "A")
                        RdoAccepted.Checked = true;
                    else if (str.Trim() == "R")
                        RdoRejected.Checked = true;
                    else if (str.Trim() == "H")
                        RdoHold.Checked = true;
                    cmbInspectedBy.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["inspectedby"]);
                    //for (int col = 0; col < dgReadings.Columns.Count; col++)
                    //{
                    //    for (int row = 0; row < dgReadings.Rows.Count; row++)
                    //    {
                    //        if (i < ds.Tables[0].Rows.Count)
                    //        {
                    //            if (ds.Tables[0].Rows[i]["Obs"] is System.DBNull)
                    //            {

                    //            }
                    //            else
                    //            {
                    //                dgReadings[col, row].Value = ds.Tables[0].Rows[i]["Obs"].ToString();
                    //            }
                    //        }
                    //        i++;
                    //    }
                    //}

                    for (int col = 0; col < dgReadings.Columns.Count; col++)
                    {
                        for (int row = 0; row < dgReadings.Rows.Count; row++)
                        {
                            if (i < ds.Tables[0].Rows.Count)
                            {
                                //if (Obsds.Tables[0].Rows[i]["Obs"] is System.DBNull)
                                if (ds.Tables[0].Rows[i]["Obs"].ToString() == "0")
                                {
                                    //dgReadings[col, row].Value = "";
                                }
                                else
                                {
                                    dgReadings[col, row].Value = ds.Tables[0].Rows[i]["Obs"].ToString();
                                }
                            }
                            i++;
                        }
                    }
                }
            }
            /*  else
             {
                 DataSet ds = new DataSet();
                 ds = FinishedGoodTest_Class_Obj.Select_tblWAStatus_Scoop_StatusID();
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     string str = ds.Tables[0].Rows[0]["Status"].ToString();
                     if (str.Trim() == "A")
                         RdoAccepted.Checked = true;
                     else if (str.Trim() == "R")
                         RdoRejected.Checked = true;
                     else if (str.Trim() == "H")
                         RdoHold.Checked = true;
                     cmbInspectedBy.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["inspectedby"]);

                     FinishedGoodTest_Class_Obj.statusid = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusID"]);
                     DataSet Obsds = new DataSet();
                     Obsds = FinishedGoodTest_Class_Obj.Select_tblWAObsScoop_StatusID();
                     int i = 0;
                     if (Obsds.Tables[0].Rows.Count > 0)
                     {
                         //for (int row = 0; row < dgReadings.Rows.Count; row++)
                         //{
                         //    for (int col = 0; col < dgReadings.Columns.Count; col++)
                         //    {
                         //        if (i < Obsds.Tables[0].Rows.Count)
                         //        {
                         //            //if (Obsds.Tables[0].Rows[i]["Obs"] is System.DBNull)
                         //            if (Obsds.Tables[0].Rows[i]["Obs"].ToString() == "0")
                         //            {
                         //                //dgReadings[col, row].Value = "";
                         //            }
                         //            else
                         //            {
                         //                dgReadings[col, row].Value = Obsds.Tables[0].Rows[i]["Obs"].ToString();
                         //            }
                         //        }
                         //        i++;
                         //    }
                         //}

                         for (int col = 0; col < dgReadings.Columns.Count; col++)
                         {
                             for (int row = 0; row < dgReadings.Rows.Count; row++)
                             {
                                 if (i < Obsds.Tables[0].Rows.Count)
                                 {
                                     //if (Obsds.Tables[0].Rows[i]["Obs"] is System.DBNull)
                                     if (Obsds.Tables[0].Rows[i]["Obs"].ToString() == "0")
                                     {
                                         //dgReadings[col, row].Value = "";
                                     }
                                     else
                                     {
                                         dgReadings[col, row].Value = Obsds.Tables[0].Rows[i]["Obs"].ToString();
                                     }
                                 }
                                 i++;
                             }
                         }
                     }

                 }
             }*/
            if (FinishedGoodTest_SubContract_Class_Obj.analysistype == "Weight")
            {
                CalculateAvg();
            }

        }

        /// <summary>
        /// bind users to combo box
        /// </summary>
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

        private void DrawGrid(int col, int row)
        {
            for (int i = 0; i < col; i++)
            {
                dgReadings.Columns.Add(i.ToString(), i.ToString());
                dgReadings.Columns[i].Width = dgReadings.Width / col;

            }
            for (int j = 0; j < row; j++)
            {
                dgReadings.Rows.Add();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //if (FinishedGoodTest_Class_Obj.form_name != "Scoop")
            //{
            //    for (int i = 0; i < dgReadings.Columns.Count; i++)
            //    {
            //        for (int j = 0; j < dgReadings.Rows.Count; j++)
            //        {
            //            if (dgReadings[i, j].Value == null || dgReadings[i, j].Value.ToString().Trim() == "")
            //            {
            //                MessageBox.Show("Enter all observations", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                dgReadings.Focus();
            //                return;
            //            }
            //        }
            //    }
            //}
            if (RdoAccepted.Checked == false && RdoRejected.Checked == false && RdoHold.Checked == false)
            {
                MessageBox.Show("Select Accept/Reject/Hold option ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RdoAccepted.Focus();
                return;
            }
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return;
            }

            DataSet ds;

            if (RdoAccepted.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.wastatus = 'A';
            }
            else if (RdoRejected.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.wastatus = 'R';
            }
            else if (RdoRejected.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.wastatus = 'H';
            }
            FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
            FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;

            #region Avinash 05-09-2014
            /*if (FinishedGoodTest_Class_Obj.form_name == "Scoop")
            {
                
                ds = new DataSet();
                ds = FinishedGoodTest_Class_Obj.Select_tblWAStatus_Scoop_StatusID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FinishedGoodTest_Class_Obj.statusid = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusID"]);
                    FinishedGoodTest_Class_Obj.Update_tblWAStatus_Scoop();
                }
                else
                {
                    FinishedGoodTest_Class_Obj.Insert_tblWAStatus_Scoop();
                    ds = new DataSet();
                    ds = FinishedGoodTest_Class_Obj.Select_tblWAStatus_Scoop_StatusID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_Class_Obj.statusid = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusID"]);
                        //FinishedGoodTest_Class_Obj.Update_tblWAStatus_Scoop();
                    }
                }
                FinishedGoodTest_Class_Obj.Delete_tblWAObsScoop_Scoop();
                for (int i = 0; i < dgReadings.Columns.Count; i++)
                {
                    for (int j = 0; j < dgReadings.Rows.Count; j++)
                    {
                        //if (dgReadings[i, j].Value != null && dgReadings[i, j].Value.ToString().Trim() != "")
                        //{
                            FinishedGoodTest_Class_Obj.obs = Convert.ToDouble(dgReadings[i, j].Value);
                            FinishedGoodTest_Class_Obj.Insert_tblWAObsScoop_Scoop();
                        //}
                    }
                }
            }*/
            // else
            {
                ds = new DataSet();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_tblWAStatus_WATransID_SubContract();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FinishedGoodTest_SubContract_Class_Obj.statusid = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusID"]);
                    FinishedGoodTest_SubContract_Class_Obj.Update_tblWAStatus_SubContract();
                }
                else
                {
                    FinishedGoodTest_SubContract_Class_Obj.statusid = FinishedGoodTest_SubContract_Class_Obj.Insert_tblWAStatus_SubContract();
                }

                FinishedGoodTest_SubContract_Class_Obj.Delete_tblWAObs_SubContract();

                for (int i = 0; i < dgReadings.Columns.Count; i++)
                {
                    for (int j = 0; j < dgReadings.Rows.Count; j++)
                    {
                        //if (dgReadings[i, j].Value != null && dgReadings[i, j].Value.ToString().Trim() != "")
                        //{
                        FinishedGoodTest_SubContract_Class_Obj.obs = Convert.ToDouble(dgReadings[i, j].Value);
                        FinishedGoodTest_SubContract_Class_Obj.Insert_tblWAObs_SubContract();
                        // }
                    }
                }

                FinishedGoodTest_SubContract_Class_Obj.Update_tblWATrans_WADone_SubContract();
            }

            #endregion

            MessageBox.Show("Observations saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void dgReadings_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgReadings.CurrentCell.RowIndex < 0)
            {
                return;
            }
            else
            {
                dgReadings.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace,  period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void dgReadings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateAvg();
        }

        private void CalculateAvg()
        {
            double Avg = 0;
            int Cnt = 0;
            //if (FinishedGoodTest_Class_Obj.form_name == "Scoop")
            {
                for (int i = 0; i < dgReadings.Columns.Count; i++)
                {
                    for (int j = 0; j < dgReadings.Rows.Count; j++)
                    {
                        if (dgReadings[i, j].Value != null && dgReadings[i, j].Value.ToString().Trim() != "")
                        {
                            Avg = Avg + Convert.ToDouble(dgReadings[i, j].Value);
                            Cnt++;
                        }
                    }
                }
                if (Cnt != 0)
                {
                    double avg = Avg / Cnt;
                    txtAvg.Text = avg.ToString("f3");
                }
            }
            /* else
             {
                 for (int i = 0; i < dgReadings.Columns.Count; i++)
                 {
                     for (int j = 0; j < dgReadings.Rows.Count; j++)
                     {
                         if (dgReadings[i, j].Value != null && dgReadings[i, j].Value.ToString().Trim() != "")
                         {
                             Avg = Avg + Convert.ToDouble(dgReadings[i, j].Value);
                         }
                     }
                 }

                 txtAvg.Text = Convert.ToString(Avg / FinishedGoodTest_Class_Obj.count);
             }*/
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "", filepath = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    filename = System.IO.Path.GetFileName(filepath);

                    string path = Application.StartupPath;
                    path = path + "\\" + filename;

                    if (!File.Exists(path))
                    {
                        //File.Create(path);
                        File.Copy(filepath, path);
                    }
                    else
                    {
                        File.Delete(path);
                        File.Copy(filepath, path);
                    }

                    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';";
                    OleDbConnection oledbConn = new OleDbConnection(connString);

                    oledbConn.Open();

                    DataTable Sheets = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    DataSet ds = new DataSet();
                    foreach (DataRow dr in Sheets.Rows)
                    {
                        string sht = dr[2].ToString().Replace("'", "");
                        //OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from [" + sht + "]", oledbConn);
                        OleDbCommand cmd = new OleDbCommand("select * from [" + sht + "]", oledbConn);
                        OleDbDataAdapter oleda = new OleDbDataAdapter();
                        oleda.SelectCommand = cmd;

                        oleda.Fill(ds, "WA");
                        DataTable dtEmp = ds.Tables["WA"];
                        break;
                    }
                    ////OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
                    ////OleDbDataAdapter oleda = new OleDbDataAdapter();
                    ////oleda.SelectCommand = cmd;
                    ////DataSet ds = new DataSet();
                    ////oleda.Fill(ds, "WA");
                    ////DataTable dtEmp = ds.Tables["WA"];

                    #region entry in grid cell

                    int r = 0;

                    for (int i = 0; i < dgReadings.Columns.Count; i++)
                    {
                        for (int j = 0; j < dgReadings.Rows.Count; j++)
                        {
                            if (r < ds.Tables["WA"].Rows.Count)
                            {
                                dgReadings[i, j].Value = Convert.ToString(ds.Tables["WA"].Rows[r]["Net"]);
                                r++;
                            }
                        }
                    }


                    CalculateAvg();
                    #endregion

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



    }
}