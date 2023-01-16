using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmFGOutSourceAddNew : Form
    {
        public FrmFGOutSourceAddNew(long OFGID)
        {
            InitializeComponent();
            FGOutSource_Class_Obj._OFGID = OFGID;
        }
        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.FGOutSource_Class FGOutSource_Class_Obj = new BusinessFacade.FGOutSource_Class();
        #endregion
        private void FrmFGOutSourceAddNew_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            DtpFinalMfgdate.Value = DtpChildMfgdate.Value = Comman_Class_Obj.Select_ServerDate();
            dgv.AutoGenerateColumns = false;

            if (FGOutSource_Class_Obj._OFGID != 0)
            {
                BtnSave.Text = "Update";

                DataSet Ds = new DataSet();
                Ds = FGOutSource_Class_Obj.Select_tblOutSourceFG_By_OFGID();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    txtFinalFg.Text = Ds.Tables[0].Rows[0]["FinalFGCode"].ToString();
                    txtFinalBatchcode.Text = Ds.Tables[0].Rows[0]["Batchcode"].ToString();
                    DtpFinalMfgdate.Value = Convert.ToDateTime(Ds.Tables[0].Rows[0]["Mfgdate"]);

                    DataSet DsChild = new DataSet();
                    DsChild = FGOutSource_Class_Obj.Select_tblOutSourceFG_Child_By_OFGID();
                    for (int i = 0; i < DsChild.Tables[0].Rows.Count; i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = Convert.ToString(DsChild.Tables[0].Rows[i]["OCFGID"]);
                        dgv.Rows[i].Cells[1].Value = Convert.ToString(DsChild.Tables[0].Rows[i]["ChildFGCode"]);
                        dgv.Rows[i].Cells[2].Value = Convert.ToString(DsChild.Tables[0].Rows[i]["BatchCode"]);
                        dgv.Rows[i].Cells[3].Value = Convert.ToString(DsChild.Tables[0].Rows[i]["Mfgdate"]);
                        dgv.Rows[i].Cells[4].Value = Convert.ToString(DsChild.Tables[0].Rows[i]["Supplier"]);
                    }
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtChildFgCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter child fg code.");
                txtChildFgCode.Focus();
                return;
            }
            if (txtChildBatchcode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter batch code.");
                txtChildBatchcode.Focus();
                return;
            }
            if (txtSupplier.Text.Trim() == "")
            {
                MessageBox.Show("Please enter supplier.");
                txtSupplier.Focus();
                return;
            }

            dgv.Rows.Add();
            int RowNo = dgv.Rows.Count - 1;
            dgv.Rows[RowNo].Cells[0].Value = "0";
            dgv.Rows[RowNo].Cells[1].Value = txtChildFgCode.Text.Trim();
            dgv.Rows[RowNo].Cells[2].Value = txtChildBatchcode.Text.Trim();
            dgv.Rows[RowNo].Cells[3].Value = DtpChildMfgdate.Value.ToString("dd-MMM-yyyy");
            dgv.Rows[RowNo].Cells[4].Value = txtSupplier.Text.Trim();
            BtnReset_Click(sender, e);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtChildFgCode.Text = "";
            txtChildBatchcode.Text = "";
            txtSupplier.Text = "";
            DtpChildMfgdate.Value = Comman_Class_Obj.Select_ServerDate();
            txtChildFgCode.Focus();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 5)//Delete
                    {
                        string id = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        if (id == "0")
                            dgv.Rows.RemoveAt(e.RowIndex);
                        else
                        {
                            FGOutSource_Class_Obj._OCFGID = Convert.ToInt64(id);
                            FGOutSource_Class_Obj.Delete_tblOutSourceFG_Child();
                            dgv.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtFinalFg.Text.Trim() == "")
            {
                MessageBox.Show("Please enter final fg code.");
                txtFinalFg.Focus();
                return;
            }
            if (txtFinalBatchcode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter final batch code.");
                txtFinalBatchcode.Focus();
                return;
            }

            FGOutSource_Class_Obj._FinalFGCode = txtFinalFg.Text.Trim();
            FGOutSource_Class_Obj._Batchcode = txtFinalBatchcode.Text.Trim();
            FGOutSource_Class_Obj._Mfgdate = Convert.ToString(DtpFinalMfgdate.Value);
            FGOutSource_Class_Obj._CreatedBy = FGOutSource_Class_Obj._ModifiedBy = GlobalVariables.uid;
            FGOutSource_Class_Obj._CreatedOn = FGOutSource_Class_Obj._ModifiedOn = Convert.ToString(Comman_Class_Obj.Select_ServerDate());

            if (FGOutSource_Class_Obj._OFGID != 0)
            {
                FGOutSource_Class_Obj.Update_tblOutSourceFG();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToString(dgv.Rows[i].Cells[0].Value) == "0")
                    {
                        FGOutSource_Class_Obj._ChildFGCode = Convert.ToString(dgv.Rows[i].Cells[1].Value);
                        FGOutSource_Class_Obj._ChildBatchcode = Convert.ToString(dgv.Rows[i].Cells[2].Value);
                        FGOutSource_Class_Obj._ChildMfgdate = Convert.ToString(dgv.Rows[i].Cells[3].Value);
                        FGOutSource_Class_Obj._Supplier = Convert.ToString(dgv.Rows[i].Cells[4].Value);

                        FGOutSource_Class_Obj.Insert_tblOutSourceFG_Child();
                    }
                }
                MessageBox.Show("Record Update Successfully !!");
            }
            else
            {
                DataSet ds = new DataSet();
                ds = FGOutSource_Class_Obj.Get_OFGID();
                if (ds.Tables[0].Rows.Count > 0)
                    FGOutSource_Class_Obj._OFGID = Convert.ToInt64(ds.Tables[0].Rows[0]["OFGID"]);
                else
                    FGOutSource_Class_Obj._OFGID = FGOutSource_Class_Obj.Insert_tblOutSourceFG();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    FGOutSource_Class_Obj._ChildFGCode = Convert.ToString(dgv.Rows[i].Cells[1].Value);
                    FGOutSource_Class_Obj._ChildBatchcode = Convert.ToString(dgv.Rows[i].Cells[2].Value);
                    FGOutSource_Class_Obj._ChildMfgdate = Convert.ToString(dgv.Rows[i].Cells[3].Value);
                    FGOutSource_Class_Obj._Supplier = Convert.ToString(dgv.Rows[i].Cells[4].Value);

                    FGOutSource_Class_Obj.Insert_tblOutSourceFG_Child();
                }


                MessageBox.Show("Record Saved Successfully !!");
            }
            txtFinalFg.Text = "";
            txtFinalBatchcode.Text = "";
            DtpFinalMfgdate.Value = Comman_Class_Obj.Select_ServerDate();
            dgv.Rows.Clear();
            BtnReset_Click(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}