using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using QTMS.User_Permissions;
using BusinessFacade.Transactions;
using QTMS.Forms;
using BusinessFacade;

namespace QTMS.Scoop
{
    public partial class frmLine_SamplingPointDetails : Form
    {
        #region variables
        LineMaster_Class obj_LineMaster_Class = new LineMaster_Class();
        LineSamplingPointMaster_Class obj_LineSamplingPointMaster_Class = new LineSamplingPointMaster_Class();
        BusinessFacade.Transactions.Line_SamplePoint obj_Line_SamplePoint = new Line_SamplePoint();
        DataSet DslineNo; DataSet DsSapmlingPnt; DataSet DsLineSamplePoint; ArrayList lstDeletedSmplingPntId;// lstAddedSmplingPntId;
        bool flgRecordExistAlreadyForLine; Hashtable lstAddedSmplingPntId; int LogNoOfRow; DataTable LogSamplingPoints;
        #endregion

        public frmLine_SamplingPointDetails()
        {
            InitializeComponent();
        }

        private void Line_SamplingPointDetails_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            lstAddedSmplingPntId = new Hashtable();

            LogSamplingPoints = new DataTable();
            LogSamplingPoints.Columns.Add("SamplingID");
            LogSamplingPoints.Columns.Add("SamplingName");
            LogSamplingPoints.Columns.Add("Delete");

            flgRecordExistAlreadyForLine = false;
            Bind_LiineList();
            Bind_samplingPoints();
            cmbLine.Focus();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bind_LiineList()
        {
            try
            {
               
                DslineNo = obj_LineMaster_Class.Select_ScoopApplLineMaster();
                DataRow dr = DslineNo.Tables[0].NewRow();
                dr["LineDesc"] = "--Select--";
                DslineNo.Tables[0].Rows.InsertAt(dr, 0);

                cmbLine.DisplayMember = "LineDesc";
                cmbLine.ValueMember = "LNo";
                cmbLine.DataSource = DslineNo.Tables[0];
            }
            catch 
            {
                throw;
            }
        }

        private void Bind_samplingPoints()
        {
            try
            {
                DsSapmlingPnt = obj_LineSamplingPointMaster_Class.Select_SamplingPointMaster();
                DataRow dr = DsSapmlingPnt.Tables[0].NewRow();
                dr["SamplingPointName"] = "--Select--";
                DsSapmlingPnt.Tables[0].Rows.InsertAt(dr, 0);
                cmbSamplingPoints.DisplayMember = "SamplingPointName";
                cmbSamplingPoints.ValueMember = "SamplingPointId";
                cmbSamplingPoints.DataSource = DsSapmlingPnt.Tables[0];
            }
            catch
            {
                throw;
            }
        }

        private void cmbLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Reset_Grid(); LogNoOfRow = 0;
            //lstAddedSmplingPntId.Clear();
           
            //if (RecordExistForLine())
            //{
            //    lstDeletedSmplingPntId.Clear();
            //    flgRecordExistAlreadyForLine = true;
            //}
           
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {

            if (cmbSamplingPoints.Text == "--Select--" || cmbLine.Text=="--Select--")
            {
                string str = cmbLine.Text == "--Select--" ? "Line " : "SamplingPoint";
                MessageBox.Show("Please select"+str);
                return;
            }
            if (!ExistAlready())
            {               
                if (flgRecordExistAlreadyForLine)
                {
                    //lstAddedSmplingPntId.Add(cmbSamplingPoints.SelectedValue,dgvSaplingPoint.Rows.Count);
                }
                dgvSaplingPoint.Rows.Add(cmbSamplingPoints.SelectedValue.ToString(), cmbSamplingPoints.Text);
               
                DataRow[] dr = LogSamplingPoints.Select("SamplingID='" +dgvSaplingPoint.Rows[dgvSaplingPoint.RowCount-1].Cells["SamplingPntId"].Value.ToString() + "'");
                if (dr.Length > 0)
                {
                    dr[0]["Delete"] = true.ToString();
                }
                else
                {
                    LogSamplingPoints.Rows.Add(cmbSamplingPoints.SelectedValue.ToString(), cmbSamplingPoints.Text, true.ToString());
                }
                cmbSamplingPoints.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Record exist already.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
        }

        private bool ExistAlready()
        {
            if (dgvSaplingPoint.Rows.Count > 0)
            {
                foreach (DataGridViewRow DgvRw in dgvSaplingPoint.Rows)
                {
                    if (DgvRw.Cells["SamplingPointForLine"].Value.ToString() == cmbSamplingPoints.Text)
                    {
                        return true;
                    }

                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaplingPoint.RowCount == 0)
                {
                    MessageBox.Show("Please add the record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (flgRecordExistAlreadyForLine)
                {
                    SaveWhenREcordAlreadyExists();
                    flgRecordExistAlreadyForLine = false;
                }
                else
                {
                    int flg = 0;
                    obj_Line_SamplePoint.del = false;
                    obj_Line_SamplePoint.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                    foreach (DataGridViewRow dgvrw in dgvSaplingPoint.Rows)
                    {
                        obj_Line_SamplePoint.samplingPointId = Convert.ToInt64(dgvrw.Cells["SamplingPntId"].Value.ToString());
                        bool b = obj_Line_SamplePoint.Insert_LineSamplingPointrlt();
                        if (b == false)
                        {
                            flg = 1;
                            break;
                        }
                    }
                    if (flg == 0)
                    {
                        MessageBox.Show("Record saved succesfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                throw;
            }
            Reset_Grid();
            cmbLine.SelectedIndex = 0;
            cmbSamplingPoints.SelectedIndex = 0;
        }

        private void Reset_Grid()
        {
            if (dgvSaplingPoint.Rows.Count > 0)
            {
                dgvSaplingPoint.Rows.Clear();
            }
        
        }

        private bool RecordExistForLine()
        {
           
                obj_Line_SamplePoint.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                DsLineSamplePoint = obj_Line_SamplePoint.Select_SamplingPointForLine();
                LogNoOfRow = DsLineSamplePoint.Tables[0].Rows.Count;
                if (LogNoOfRow > 0)
                {
                    foreach (DataRow Dr in DsLineSamplePoint.Tables[0].Rows)
                    {
                        dgvSaplingPoint.Rows.Add(Dr["SamplingPointId"].ToString(), Dr["SamplingPointName"].ToString());
                        LogSamplingPoints.Rows.Add(Dr["SamplingPointId"].ToString(), Dr["SamplingPointName"].ToString(), true.ToString());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            
        
        }

        private void SaveWhenREcordAlreadyExists()
        {
            try
            {
                int i = 0;
                obj_Line_SamplePoint.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                for ( i = 0; i < LogNoOfRow; i++)
                {
                   // bool b = (bool)(dgvSaplingPoint.Rows[i].Cells["DeleteCheck"].FormattedValue);

                    if (LogSamplingPoints.Rows[i]["Delete"].ToString() == false.ToString())
                    {
                        obj_Line_SamplePoint.del = true;
                        obj_Line_SamplePoint.samplingPointId = Convert.ToInt64(LogSamplingPoints.Rows[i]["SamplingID"].ToString());
                        obj_Line_SamplePoint.Del_Update_LineSamplingPointrlt();
                    }
                }
                for (int j = i; j < LogSamplingPoints.Rows.Count;j++)
                {
                    obj_Line_SamplePoint.del = false;
                    if (LogSamplingPoints.Rows[j]["Delete"].ToString() == true.ToString())
                    {
                        obj_Line_SamplePoint.samplingPointId = Convert.ToInt64(LogSamplingPoints.Rows[j]["SamplingID"].ToString());
                        obj_Line_SamplePoint.Insert_LineSamplingPointrlt();
                    }

                }
                MessageBox.Show("Record saved succesfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                throw;
            }
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Grid(); 
            LogNoOfRow = 0;
            LogSamplingPoints.Rows.Clear();
            lstAddedSmplingPntId.Clear();
            flgRecordExistAlreadyForLine = false;
            if (cmbLine.SelectedValue.ToString() != "")
            {
                if (RecordExistForLine())
                {
                    //lstDeletedSmplingPntId.Clear();
                    flgRecordExistAlreadyForLine = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult RS = MessageBox.Show("Do you want to delete ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (RS.ToString() == "No")
            {
                return;
            }
            if (dgvSaplingPoint.Rows.Count > 0)
            {
                string nm = dgvSaplingPoint.CurrentRow.Cells["SamplingPointForLine"].Value.ToString();
                DataRow[] dr = LogSamplingPoints.Select("SamplingName='"+ nm +"'");
                int i = dr.Length;
                dr[0]["Delete"] = false.ToString();
                dgvSaplingPoint.Rows.Remove(dgvSaplingPoint.CurrentRow);
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset_Grid();
            cmbLine.SelectedIndex = 0;
            cmbSamplingPoints.SelectedIndex = 0;
        }

        private void cmbSamplingPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
          e.Handled = true;
          MessageBox.Show("Can not edit.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
          cmbSamplingPoints.SelectedIndex = 0;
        }

        private void cmbLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Can not edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmbSamplingPoints.SelectedIndex = 0;
        }

        //private bool Is_valid()
        //{
        //    try
        //    {
        //        if (cmbLine.Text == "")
        //            return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
    }
}
