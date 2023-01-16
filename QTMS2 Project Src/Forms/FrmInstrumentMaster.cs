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

namespace QTMS.Forms
{

    public partial class FrmInstrumentMaster : Form
    {
        public FrmInstrumentMaster()
        {
            InitializeComponent();
        }
        DataSet dsList = new DataSet();
        # region Varibles
        bool Modify = false;
        public bool SaveAs = false;
        BusinessFacade.Transactions.Comman_Class Comman_Class_obj = new BusinessFacade.Transactions.Comman_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        InstrumentMaster_Class InstrumentMaster_Class_Obj = new InstrumentMaster_Class();
        # endregion

        private static FrmInstrumentMaster frmInstrumentMaster_Obj = null;
        public static FrmInstrumentMaster GetInstance()
        {
            if (frmInstrumentMaster_Obj == null)
            {
                frmInstrumentMaster_Obj = new FrmInstrumentMaster();
            }
            return frmInstrumentMaster_Obj;
        }

        private void FrmInstrumentMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_List();            
            Bind_Test();            
            BtnReset_Click(sender, e);
        }

        public void Bind_List()
        {
            
            dsList = InstrumentMaster_Class_Obj.Select_tblInstrumentMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "Instrument";
            List.ValueMember = "InstNo";        
        }

        public void Bind_Test()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = TestMaster_Class_Obj.Select_TestMaster();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["TestNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbTest.DataSource = ds.Tables[0];
                CmbTest.DisplayMember = "Details";
                CmbTest.ValueMember = "TestNo";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            Modify = false;
            SaveAs = false;
            BtnDelete.Enabled = false;
            txtInstrument.Text = "";
            txtInstrument.Enabled = true;
            DtpCaliberationDate.Value = Comman_Class_obj.Select_ServerDate();
            DtpDueDate.Value = DtpCaliberationDate.Value;
            DtpCaliberationDate.Checked = false;
            DtpDueDate.Checked = false;
            CmbTest.Text = "--Select--";
            dgTestNo.Rows.Clear();
            txtInstrument.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInstrument.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Instrument", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInstrument.Text = "";
                    txtInstrument.Focus();
                    return;
                }

                if (dgTestNo.Rows.Count == 0)
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbTest.Focus();
                    return;
                }

                if (Modify == false)
                {
                    // check Instrument is already exist or not
                    InstrumentMaster_Class_Obj.instrument = txtInstrument.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = InstrumentMaster_Class_Obj.Select_tblInstrumentMaster_Instrument();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Instrument already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtInstrument.Focus();
                        return;
                    }

                    if (DtpCaliberationDate.Checked == true)
                    {
                        InstrumentMaster_Class_Obj.caliberationdate = DtpCaliberationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        InstrumentMaster_Class_Obj.caliberationdate = null;
                    }
                    if (DtpDueDate.Checked == true)
                    {
                        InstrumentMaster_Class_Obj.duedate = DtpDueDate.Value.ToShortDateString();
                    }
                    else
                    {
                        InstrumentMaster_Class_Obj.duedate = null;
                    }

                    InstrumentMaster_Class_Obj.instno = 0;
                    InstrumentMaster_Class_Obj.instno = InstrumentMaster_Class_Obj.Insert_tblInstrumentMaster();

                    if (InstrumentMaster_Class_Obj.instno != 0)
                    {
                        // Now save record in tblInstrument_TestMaster
                        for (int i = 0; i < dgTestNo.Rows.Count; i++)
                        {
                            InstrumentMaster_Class_Obj.testno = Convert.ToInt32(dgTestNo["TestNo", i].Value);
                            InstrumentMaster_Class_Obj.Insert_tblInstrument_TestMaster();
                        }
                    }

                    MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
                else
                {
                    // Update Code
                    InstrumentMaster_Class_Obj.instno = Convert.ToInt64(List.SelectedValue.ToString());
                    InstrumentMaster_Class_Obj.result = Convert.ToInt64(List.SelectedValue.ToString());
                    InstrumentMaster_Class_Obj.instrument = txtInstrument.Text.Trim();

                    if (DtpCaliberationDate.Checked == true)
                    {
                        InstrumentMaster_Class_Obj.caliberationdate = DtpCaliberationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        InstrumentMaster_Class_Obj.caliberationdate = null;
                    }
                    if (DtpDueDate.Checked == true)
                    {
                        InstrumentMaster_Class_Obj.duedate = DtpDueDate.Value.ToShortDateString();
                    }
                    else
                    {
                        InstrumentMaster_Class_Obj.duedate = null;
                    }

                    bool b = false;
                    if (MessageBox.Show("Modify this Record ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        b = InstrumentMaster_Class_Obj.Update_tblInstrumentMaster();
                    }

                    if (b == true)
                    {
                        // delete record from tblInstrument_TestMaster
                        InstrumentMaster_Class_Obj.Delete_tblInstrument_TestMaster();

                        // Now save record in tblInstrument_TestMaster
                        for (int i = 0; i < dgTestNo.Rows.Count; i++)
                        {
                            InstrumentMaster_Class_Obj.testno = Convert.ToInt32(dgTestNo["TestNo", i].Value);
                            InstrumentMaster_Class_Obj.Insert_tblInstrument_TestMaster();
                        }
                        MessageBox.Show("Record Update Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtInstrument.Enabled = true;
                        BtnReset_Click(sender, e);
                    }
                }
                Bind_List();
                SaveAs = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtInstrument.Focus();
                Modify = false;
                SaveAs = false;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            txtInstrument.Enabled = false;
            List.Enabled = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (List.SelectedValue == null)
            {
                return;
            }
            dgTestNo.Rows.Clear();
           // txtSearch.Text = Convert.ToString(List.Text);
            DataSet ds = new DataSet();
            InstrumentMaster_Class_Obj.instno = Convert.ToInt64(List.SelectedValue.ToString());
            ds = InstrumentMaster_Class_Obj.Select_tblInstrumentMaster_InstNo();
            txtInstrument.Text = List.Text;

            if (ds.Tables[0].Rows[0]["CaliberationDate"] is System.DBNull)
            {
                DtpCaliberationDate.Value = Comman_Class_obj.Select_ServerDate();
                DtpCaliberationDate.Checked = false;
            }
            else
            {
                DtpCaliberationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CaliberationDate"].ToString());
            }

            if (ds.Tables[0].Rows[0]["DueDate"] is System.DBNull)
            {
                DtpDueDate.Value = Comman_Class_obj.Select_ServerDate();
                DtpDueDate.Checked = false;
            }
            else
            {
                DtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"].ToString());
            }

            // Now get Formuala No
            DataSet ds2 = new DataSet();
            ds2 = InstrumentMaster_Class_Obj.Select_tblInstrument_TestMaster();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                dgTestNo.Rows.Add();
                dgTestNo["TestNo", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["TestNo"].ToString();
                dgTestNo["Test", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["Details"].ToString();                
            }
            BtnDelete.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                InstrumentMaster_Class_Obj.instno = Convert.ToInt64(List.SelectedValue.ToString());
                if (InstrumentMaster_Class_Obj.instno == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool a = InstrumentMaster_Class_Obj.Delete_tblInstrument_TestMaster();
                    if (a == true)
                    {
                        bool b = InstrumentMaster_Class_Obj.Delete_tblInstrumentMaster();
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        BtnReset_Click(sender, e);
                        BtnDelete.Enabled = false;
                        Bind_List();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Modify = false;
                txtInstrument.Focus();
            }
        }

        private void txtInstrument_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(32))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtInstrument_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtInstrument.Text = textInfo.ToTitleCase(txtInstrument.Text);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            SaveAs = true;
            List_DoubleClick(sender, e);
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void btnFormulaAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbTest.SelectedValue == null || CmbTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbTest.Focus();
                    return;
                }

                for (int i = 0; i < dgTestNo.Rows.Count; i++)
                {
                    if (dgTestNo["TestNo", i].Value.ToString() == CmbTest.SelectedValue.ToString())
                    {                        
                        return;
                    }
                }
                
                dgTestNo.Rows.Add();
                dgTestNo["TestNo", dgTestNo.Rows.Count - 1].Value = CmbTest.SelectedValue.ToString();
                dgTestNo["Test", dgTestNo.Rows.Count - 1].Value = CmbTest.Text;              

                btnFormulaReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormulaReset_Click(object sender, EventArgs e)
        {
            CmbTest.Text = "--Select--";            
            CmbTest.Focus();
        }

        private void btnFormulaDelete_Click(object sender, EventArgs e)
        {
            if (dgTestNo.SelectedRows != null && dgTestNo.SelectedRows.Count != 0)
            {
                for (int i = 0; i < dgTestNo.SelectedRows.Count; i++)
                {
                    if (MessageBox.Show("Delete This Test..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        dgTestNo.Rows.Remove(dgTestNo.SelectedRows[i]);
                    }
                }
                btnFormulaReset_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgTestNo.Focus();
                return;
            }
        }

        private void dgFormulaNo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CmbTest.Text = dgTestNo["Test", e.RowIndex].Value.ToString();            
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "Instrument like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "Instrument";
            List.ValueMember = "InstNo";        
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                if (List.SelectedValue == null)
                {
                    return;
                }
                dgTestNo.Rows.Clear();
                txtSearch.Text = Convert.ToString(List.Text);
                DataSet ds = new DataSet();
                InstrumentMaster_Class_Obj.instno = Convert.ToInt64(List.SelectedValue.ToString());
                ds = InstrumentMaster_Class_Obj.Select_tblInstrumentMaster_InstNo();
                txtInstrument.Text = List.Text;

                if (ds.Tables[0].Rows[0]["CaliberationDate"] is System.DBNull)
                {
                    DtpCaliberationDate.Value = Comman_Class_obj.Select_ServerDate();
                    DtpCaliberationDate.Checked = false;
                }
                else
                {
                    DtpCaliberationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CaliberationDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["DueDate"] is System.DBNull)
                {
                    DtpDueDate.Value = Comman_Class_obj.Select_ServerDate();
                    DtpDueDate.Checked = false;
                }
                else
                {
                    DtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"].ToString());
                }

                // Now get Formuala No
                DataSet ds2 = new DataSet();
                ds2 = InstrumentMaster_Class_Obj.Select_tblInstrument_TestMaster();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    dgTestNo.Rows.Add();
                    dgTestNo["TestNo", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["TestNo"].ToString();
                    dgTestNo["Test", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["Details"].ToString();
                }
                BtnDelete.Enabled = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
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

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (List.SelectedValue == null)
                {
                    return;
                }
                dgTestNo.Rows.Clear();
                txtSearch.Text = Convert.ToString(List.Text);
                DataSet ds = new DataSet();
                InstrumentMaster_Class_Obj.instno = Convert.ToInt64(List.SelectedValue.ToString());
                ds = InstrumentMaster_Class_Obj.Select_tblInstrumentMaster_InstNo();
                txtInstrument.Text = List.Text;

                if (ds.Tables[0].Rows[0]["CaliberationDate"] is System.DBNull)
                {
                    DtpCaliberationDate.Value = Comman_Class_obj.Select_ServerDate();
                    DtpCaliberationDate.Checked = false;
                }
                else
                {
                    DtpCaliberationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CaliberationDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["DueDate"] is System.DBNull)
                {
                    DtpDueDate.Value = Comman_Class_obj.Select_ServerDate();
                    DtpDueDate.Checked = false;
                }
                else
                {
                    DtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"].ToString());
                }

                // Now get Formuala No
                DataSet ds2 = new DataSet();
                ds2 = InstrumentMaster_Class_Obj.Select_tblInstrument_TestMaster();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    dgTestNo.Rows.Add();
                    dgTestNo["TestNo", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["TestNo"].ToString();
                    dgTestNo["Test", dgTestNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["Details"].ToString();
                }
                BtnDelete.Enabled = true;
            }
        }
       
    }
}