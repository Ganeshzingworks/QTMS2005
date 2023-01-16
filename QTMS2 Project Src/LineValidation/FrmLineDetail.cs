using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineDetail : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionRejectionMaster_Class LineTransactionRejectionMaster_Class_Obj = new LineTransactionRejectionMaster_Class();
        public FrmLineDetail()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);
                Bind_LineDescription();
                LineTransactionRejectionMaster_Class_Obj.loginuser = FrmMain.LoginID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void Bind_LineDescription()
        {
            try
            {
                DataSet ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["LNo"] = "0";
                dr["LineDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbLineDescription.DataSource = ds.Tables[0];
                cbLineDescription.DisplayMember = "LineDesc";
                cbLineDescription.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


         
        private void BindLineTrainingGrid(long lineid)
        {
            DataSet ds = new LineMaster_Class().Select_LayoutLineTrainingFiles(lineid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvTraining.DataSource = null;
                    dgvTraining.Rows.Clear();
                    //int index = 0;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvTraining);  //
                        //if(index == 0)
                        //{
                        //    dr1.Cells[0].Value = _LayoutFileName;
                        //    dr1.Cells[1].Value = _LayoutFilePath;
                        //}
                        dr1.Cells[0].Value = Convert.ToString(item["Id"]);
                        dr1.Cells[2].Value = Convert.ToString(item["Description"]);
                        dr1.Cells[8].Value = Convert.ToString(item["FileType"]);
                        if (Convert.ToString(item["FileType"]) == "1")
                        {
                            dr1.Cells[1].Value = "Layout";
                            dr1.Cells[3].Value = Convert.ToString(item["LayoutFileName"]);
                            dr1.Cells[4].Value = Convert.ToString(item["LayoutFileName"]);
                            dr1.Cells[5].Value = Convert.ToString(item["LayoutFilePath"]).Replace("\\\\", "\\");
                        }
                        else
                        {
                            dr1.Cells[1].Value = "Training";
                            dr1.Cells[3].Value = Convert.ToString(item["TrainingFileName"]);
                            dr1.Cells[6].Value = Convert.ToString(item["TrainingFileName"]);
                            dr1.Cells[7].Value = Convert.ToString(item["TrainingFilePath"]).Replace("\\\\", "\\");
                        }
                        dgvTraining.Rows.Add(dr1);
                        //index++;
                    }
                }
                else
                {
                    dgvTraining.DataSource = null; dgvTraining.Refresh();
                    dgvTraining.Rows.Clear();
                }
            }
            else
            {
                dgvTraining.DataSource = null; dgvTraining.Refresh();
                dgvTraining.Rows.Clear();
            }
        }

        private void BindLineGrid()
        {
            DataSet ds = LayoutLineMaster_Class_Obj.Select_LineViewDetails(Convert.ToInt64(cbLineDescription.SelectedValue));
            #region Old
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        dgvLineRejection.DataSource = null;
            //        dgvLineRejection.Rows.Clear();
            //        int serialno = 1;
            //        foreach (DataRow item in ds.Tables[0].Rows)
            //        {
            //            DataGridViewRow dr1 = new DataGridViewRow();
            //            dr1.CreateCells(dgvLineRejection);  //
            //            dr1.Cells[0].Value = serialno;
            //            dr1.Cells[1].Value = Convert.ToString(item["LineDesc"]);
            //            dr1.Cells[2].Value = Convert.ToString(item["TraningFileName"]);
            //            dr1.Cells[3].Value = Convert.ToString(item["LayoutFileName"]);
            //            dr1.Cells[4].Value = Convert.ToString(item["LNo"]);
            //            dr1.Cells[5].Value = "View";
            //            dr1.Cells[6].Value = Convert.ToString(item["TraningFilePath"]);
            //            dr1.Cells[7].Value = Convert.ToString(item["LayoutFilePath"]);
            //            serialno++;
            //            dgvLineRejection.Rows.Add(dr1);
            //        }
            //    }
            //    else
            //        BindLineRejectionGridDefault();
            //}
            //else
            //    BindLineRejectionGridDefault();
            #endregion

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        _LineDesc = Convert.ToString(item["LineDesc"]);
                        _LayoutFileName = Convert.ToString(item["LayoutFileName"]); 
                        _LayoutFilePath = Convert.ToString(item["LayoutFilePath"]); 
                    }
                    if (_LineDesc != string.Empty)
                        BindLineTrainingGrid(Convert.ToInt64(cbLineDescription.SelectedValue));
                }
            }
        }

        private void BindLineRejectionGridDefault()
        {
            dgvLineRejection.DataSource = null;
            dgvLineRejection.Rows.Clear();
            MessageBox.Show("Line Rejection Record does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgvLineRejection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                long DiscriptionId = Convert.ToInt64(dgvLineRejection1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DataSet ds = LineTransactionRejectionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(DiscriptionId);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FrmLineRejectionHistory frm = new FrmLineRejectionHistory(DiscriptionId);
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Rejection record does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Rejection record does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if ((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex >= 0)
            {
                string FilePath, FileName = string.Empty;
                try
                {
                    if (e.ColumnIndex == 2)
                    {
                        FilePath = dgvLineRejection1.Rows[e.RowIndex].Cells["TraningFilePath"].Value.ToString();
                        FileName = dgvLineRejection1.Rows[e.RowIndex].Cells["TraningFileName"].Value.ToString();
                    }
                    else
                    {
                        FilePath = dgvLineRejection1.Rows[e.RowIndex].Cells["LayoutFilePath"].Value.ToString();
                        FileName = dgvLineRejection1.Rows[e.RowIndex].Cells["LayoutFileName"].Value.ToString();
                    }
                    if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                    {
                        if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                            Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                        File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                        //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                            System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                        //if (Directory.Exists(@"" + Application.StartupPath))
                        //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLineDescription.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select line discription", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BindLineGrid();
                    BindLineRejectionGrid();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindLineRejectionGrid()
        {
            DataSet ds = LineTransactionRejectionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvLineRejection.DataSource = null;
                    dgvLineRejection.Rows.Clear();
                    int serialno = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvLineRejection);  //
                        dr1.Cells[0].Value = serialno;
                        dr1.Cells[1].Value = Convert.ToString(item["LineDescriptionName"]);
                        dr1.Cells[2].Value = Convert.ToString(item["RejectionDate"]);
                        dr1.Cells[3].Value = Convert.ToString(item["RejectionReason"]).Replace("<html><body>", "").Replace("</body></html>", "");
                        dr1.Cells[4].Value = Convert.ToString(item["RCA"]);
                        dr1.Cells[5].Value = Convert.ToString(item["Id"]);
                        //dr1.Cells[6].Value = "View";
                        serialno++;
                        dgvLineRejection.Rows.Add(dr1);
                    }
                }
                else
                    BindLineRejectionGridDefault();
            }
            else
                BindLineRejectionGridDefault();
        }

        private void btnAddRejection_Click(object sender, EventArgs e)
        {
            FrmLineTransactionRejectionMaster frm = new FrmLineTransactionRejectionMaster(0,0);
            frm.Show();
        }

        private static FrmLineDetail frm = null;
        private string _LayoutFileName;
        private string _LayoutFilePath;

        public string _LineDesc;

        public static FrmLineDetail GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineDetail();
            }
            return frm;
        }

        private void dgvTraining_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //For View file 
                if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                {
                    string FilePath = string.Empty, FileName = string.Empty;
                    try
                    {
                        if (Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["FileType"].Value) == "1")
                        {
                            FilePath = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["LayoutFilePath1"].Value);
                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                                FileName = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["LayoutFileName1"].Value);
                        }
                        else
                        {
                            FilePath = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["TrainingFilePath"].Value);
                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                                FileName = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["TrainingFileName"].Value);
                        }

                        if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                        {
                            if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                            File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                            //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                            //if (Directory.Exists(@"" + Application.StartupPath))
                            //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                
            }
            catch (Exception ex)
            {}
        }
    }
}
