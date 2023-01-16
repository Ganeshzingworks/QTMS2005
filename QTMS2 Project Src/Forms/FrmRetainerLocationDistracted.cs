using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;

namespace QTMS.Forms
{
    public partial class FrmRetainerLocationDistracted : Form
    {
        public FrmRetainerLocationDistracted()
        {
            InitializeComponent();
        }

        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();

        private void FrmRetainerLocationDistracted_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_Location();

            lbldistruction.ForeColor = Color.Red;
        }

        public void Bind_Location()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            //ds = RetainerLocation_Class_Obj.Select_tblRetainerLocation();
            ds = RetainerLocation_Class_Obj.Select_Distruct_tblRetainerLocation();
            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--Select--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbLocation.DataSource = ds.Tables[0];
                CmbLocation.DisplayMember = "Location";
                CmbLocation.ValueMember = "LocationID";
            }
        }

        private void CmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgLocation.Rows.Clear();
            bool FlagDis = false;
            if (CmbLocation.SelectedValue != null && CmbLocation.SelectedValue.ToString() != "" && CmbLocation.SelectedIndex != 0)
            {
                RetainerLocation_Class_Obj.locationid = Convert.ToInt64(CmbLocation.SelectedValue);
                DataSet ds = new DataSet();
                ds = RetainerLocation_Class_Obj.Select_RetainerLocation_LocationID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgLocation.Rows.Add();
                        dgLocation["TLFID", i].Value = ds.Tables[0].Rows[i]["TLFID"].ToString();
                        dgLocation["FGCode", i].Value = ds.Tables[0].Rows[i]["FGCode"].ToString();
                        dgLocation["PkgWO", i].Value = ds.Tables[0].Rows[i]["PkgWO"].ToString();
                        dgLocation["BatchNo", i].Value = ds.Tables[0].Rows[i]["BatchNo"].ToString();
                        dgLocation["TrackCodeFG", i].Value = ds.Tables[0].Rows[i]["TrackCodeFG"].ToString();
                        dgLocation["Status", i].Value = ds.Tables[0].Rows[i]["Status"].ToString();
                        if (ds.Tables[0].Rows[i]["Status"].ToString() == "Not OK")
                            FlagDis = true;
                    }

                    if (FlagDis == true)
                    {
                        BtnSave.Enabled = false;
                        lbldistruction.Text = " You Can't Destruct this location !";
                    }
                    else
                    {
                        BtnSave.Enabled = true;
                        lbldistruction.Text = " You Can Destruct this location !";
                    }
                }
                else
                {
                    BtnSave.Enabled = true;
                    lbldistruction.Text = "";
                }
            }


            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbLocation.Text = "--Select--";
            dgLocation.Rows.Clear();
            BtnSave.Enabled = true;
            lbldistruction.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbLocation.SelectedIndex == 0 || CmbLocation.Text == "--Select--")
            {
                MessageBox.Show("please select Location", "Message");
                return;
            }
            RetainerLocation_Class_Obj.locationid = Convert.ToInt64(CmbLocation.SelectedValue);
            RetainerLocation_Class_Obj.distructionid = 0;
            RetainerLocation_Class_Obj.createdby = Convert.ToInt32(GlobalVariables.uid);
            RetainerLocation_Class_Obj.distructionid = RetainerLocation_Class_Obj.Insert_tblLocationDistruction();
            if (RetainerLocation_Class_Obj.distructionid != 0)
            {
                for (int i = 0; i < dgLocation.Rows.Count; i++)
                {
                    RetainerLocation_Class_Obj.tlfid = Convert.ToInt64(dgLocation["TLFID", i].Value);
                    bool res = RetainerLocation_Class_Obj.Insert_tblDistrunctionTransaction();
                }

                MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind_Location();
                BtnReset_Click(sender, e);

            }
        }
    }
}