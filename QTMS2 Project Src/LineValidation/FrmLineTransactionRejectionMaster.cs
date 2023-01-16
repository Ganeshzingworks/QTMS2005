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
using System.Text.RegularExpressions;


namespace QTMS.LineValidation
{
    public partial class FrmLineTransactionRejectionMaster : Form
    {
        #region Varibles
        bool modify = false;
        bool click = false;
        int momid;
        string checkformula = "";
        string checkvessel = "";
        string checkannexTank = "";
        string safetysymbol = "";
        string accessoris = "";
        double pno = 0;
        int NPS;

        int result1 = 0;
        Double srno;
        int result = 0;
        string tmp = "";
        string oldmomno;
        bool SaveAs = false;
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        VesselMaster_Class VesselMaster_Class_obj = new VesselMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.MomMaster_Class objMomMaster_Class = new MomMaster_Class();
        SafetySymbol_Class SafetySymbol_Class_obj = new SafetySymbol_Class();



        # endregion

        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionRejectionMaster_Class LineTransactionRejectionMaster_Class_Obj = new LineTransactionRejectionMaster_Class();
        private string tmpstring;
        private long id;
        private long lineId;

        public bool Modify ;

        public FrmLineTransactionRejectionMaster()
        {
            InitializeComponent();
        }

        public FrmLineTransactionRejectionMaster(long id,long lineId) 
        {
            InitializeComponent();
            this.id = id;
            this.lineId = lineId;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineTransactionRejectionMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);
                Bind_LineDescription();
                kaireeHTMLEditor1.IsAccessible = true;
                LineTransactionRejectionMaster_Class_Obj.loginuser = FrmMain.LoginID;
                LoadLineRejectionInfo();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadLineRejectionInfo()
        {
            if (this.id != 0)
            {
                txtRCA.Enabled = kaireeHTMLEditor1.Enabled = cbLineDescription.Enabled = txtRejectionReason.Enabled = false ;
                btnSave.Visible =  btnReset.Visible = false;
                DataSet ds = LineTransactionRejectionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineRejectionId(this.id);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            cbLineDescription.SelectedValue = Convert.ToInt64(item["LineDescription"]);
                            txtRejectionReason.Text = Convert.ToString(item["RejectionReason"]);
                            //= "<html><body>" + Convert.ToString(item["RejectionReason"]) + "</body></html>";
                            //kaireeHTMLEditor1.Text ="<html><body>" + Convert.ToString(item["RejectionReason"]) + "</body></html>";
                            txtRCA.Text = Convert.ToString(item["RCA"]);
                        }
                    }
                }
            }
            else
            {
                txtRCA.Enabled = kaireeHTMLEditor1.Enabled = cbLineDescription.Enabled = txtRejectionReason.Enabled = true;
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
                if (this.lineId != 0)
                {
                    cbLineDescription.SelectedValue = this.lineId;
                    cbLineDescription.Enabled = false;                  
                }
                else
                {
                    cbLineDescription.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static FrmLineTransactionRejectionMaster frm = null;
        public static FrmLineTransactionRejectionMaster GetInstance(long id)
        {
            if (frm == null)
            {
                frm = new FrmLineTransactionRejectionMaster(id,0);
            }
            return frm;
        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //tmpstring = kaireeHTMLEditor1.Text;
                //tmpstring = tmpstring.Replace("<STRONG>", "<B>");
                //tmpstring = tmpstring.Replace("</STRONG>", "</B>");
                //tmpstring = tmpstring.Replace("<EM>", "<I>");
                //tmpstring = tmpstring.Replace("</EM>", "</I>");


                ////                
                ////objMomMaster_Class.processDesc = kaireeHTMLEditor1.Text;


                //string HTMLCode = tmpstring;

                //HTMLCode = HTMLCode.Replace("\n", " ");

                //// Remove tab spaces
                //HTMLCode = HTMLCode.Replace("\t", " ");

                //// Remove multiple white spaces from HTML
                //HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                //// Remove HEAD tag
                //HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                //                    , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                //// Remove any JavaScript
                //HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                //  , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                //// Replace special characters like &, <, >, " etc.
                //StringBuilder sbHTML = new StringBuilder(HTMLCode);
                //// Note: There are many more special characters, these are just
                //// most common. You can add new characters in this arrays if needed
                //string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
                //   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                //string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                //for (int i = 0; i < OldWords.Length; i++)
                //{
                //    sbHTML.Replace(OldWords[i], NewWords[i]);
                //}

                //// Check if there are line breaks (<br>) or paragraph (<p>)
                //sbHTML.Replace("<br>", "\n<br>");
                //sbHTML.Replace("<br ", "\n<br ");
                //sbHTML.Replace("<p ", "\n<p ");

                if (Convert.ToInt32(cbLineDescription.SelectedValue) == 0)
                {
                    MessageBox.Show("Enter Line Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbLineDescription.Focus();
                    return;
                }
                if (txtRejectionReason.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter reject reason", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRejectionReason.Focus();
                    return;
                }
                if (txtRCA.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter RCA", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRCA.Focus();
                    return;
                }
                if (Modify == false)
                {
                    LineTransactionRejectionMaster_Class_Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                    LineTransactionRejectionMaster_Class_Obj.rejectionReason = txtRejectionReason.Text.Trim(); // tmpstring;
                    LineTransactionRejectionMaster_Class_Obj.rca = txtRCA.Text.Trim();
                    LineTransactionRejectionMaster_Class_Obj.loginuser = FrmMain.LoginID;
                    bool b = LineTransactionRejectionMaster_Class_Obj.Insert_LineTransactionRejection();
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //LineTransactionRejectionMaster_Class_Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                    //LineTransactionRejectionMaster_Class_Obj.loginuser = FrmMain.LoginID;
                    //if (LineTransactionRejectionMaster_Class_Obj.id == 0)
                    //{
                    //    MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    //bool b = LayoutLineMaster_Class_Obj.Update_LayoutLineMaster();
                    //if (b == true)
                    //{
                    //    MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                btnReset_Click(sender, e);
                this.Close();
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRejectionReason.Text = txtRCA.Text = string.Empty;
            kaireeHTMLEditor1.Clear();
            cbLineDescription.SelectedIndex = 0;
        }

        private void cbLineDescription_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.lineId != 0)
            {
                cbLineDescription.Enabled = false;
                try
                {
                    if (cbLineDescription.Items.Count > 0)
                        cbLineDescription.SelectedValue = this.lineId;
                }
                catch (Exception ex)
                {
                }
               
            }
            else
            {
                cbLineDescription.Enabled = true;
            }
        }

    }
}
