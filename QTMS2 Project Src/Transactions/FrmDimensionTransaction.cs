using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using System.Data.SqlClient;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessFacade.Transactions;



namespace QTMS.Transactions
{
    public partial class FrmDimensionTransaction : Form
    {
        #region Variable

        DimensionParameter_Class DimensionParameter_Class_obj = new DimensionParameter_Class();
        BusinessFacade.Transactions.DimensionParaTransaction_Class DimensionParaTransaction_Class_obj = new BusinessFacade.Transactions.DimensionParaTransaction_Class();
        long supplierCOCID, PMTestNo, PMCodeID, PMTransID = 0;
        int cntRed = 0;
        // variables for printing a gridview.
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        RadioButton rdAcceptRmTransaction;
        public string pmcode,testMethod,inspDate;
        //
        #endregion

        public FrmDimensionTransaction(long SupplierCOCID, long PMCOdeID, long pmTestNo, long Quantity)
        {
            
            this.supplierCOCID = SupplierCOCID;
            this.PMCodeID = PMCOdeID;
            this.PMTestNo = pmTestNo;
            //this.PMCodeID = pmTransid;
            DimensionParameter_Class_obj.quantity = Quantity;
            InitializeComponent();
        }
        string PlantLotNo = String.Empty;
        public string plantlotno
        {
            get { return PlantLotNo; }
            set { PlantLotNo = value; }
        }
        string _ProtocolNo = String.Empty;
        public string ProtocolNo
        {
            get { return _ProtocolNo; }
            set { _ProtocolNo = value; }
        }
        public FrmDimensionTransaction(long SupplierCOCID, long PMCOdeID, long pmTestNo, long Quantity,RadioButton rdAcceptBtn)
        {
            this.supplierCOCID = SupplierCOCID;
            this.PMCodeID = PMCOdeID;
            this.PMTestNo = pmTestNo;
            //this.PMCodeID = pmTransid;
            this.rdAcceptRmTransaction = rdAcceptBtn;
            
            DimensionParameter_Class_obj.quantity = Quantity;
            InitializeComponent();
        }

        public FrmDimensionTransaction(long TransID, long pmTestNo, long Quantity)
        {
            this.PMTransID = TransID;
            this.PMTestNo = pmTestNo;
            DimensionParameter_Class_obj.quantity = Quantity;
            InitializeComponent();
        }

        public FrmDimensionTransaction(long TransID, long pmTestNo, long Quantity, RadioButton rdAcceptBtn)
        {
            this.PMTransID = TransID;
            this.PMTestNo = pmTestNo;
            DimensionParameter_Class_obj.quantity = Quantity;
            this.rdAcceptRmTransaction = rdAcceptBtn;
            InitializeComponent();
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();

        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        private void FrmDimensionTransaction_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_InspectedBy();
            Bind_Grid();

        }

        /// <summary>
        /// bind users to combo box
        /// </summary>
        public void Bind_InspectedBy()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Grid()
        {
            try
            {
                DataTable dt = new DataTable();
                // Check norms exist or not
                if (PMTransID > 0)
                {
                    DimensionParameter_Class_obj.pmTransID = PMTransID;
                    DimensionParameter_Class_obj.testNo = PMTestNo;
                    dt = DimensionParameter_Class_obj.Select_DimensionParaRelation_PMTransID();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DimensionParameter_Class_obj.dpTransStatusID = Convert.ToInt64(dr["DPTransStatusID"]);
                        DimensionParaTransaction_Class_obj.dpTransStatusID = Convert.ToInt64(dr["DPTransStatusID"]);
                        if (Convert.ToChar(dr["Status"]) == 'A')
                            RdoAccepted.Checked = true;
                        else
                            RdoRejected.Checked = true;
                        if (dr["InspectedBy"] != DBNull.Value)
                            cmbInspectedBy.SelectedValue = Convert.ToInt32(dr["InspectedBy"]);

                    }
                    for (int i = 0; i < DimensionParameter_Class_obj.quantity; i++)
                    {
                        dgReadings.Columns.Add("Obs" + i, "Obs " + (i + 1));
                        dgReadings.Columns["Obs" + i].Width = 60;
                    }
                    dt = DimensionParameter_Class_obj.Select_DimensionParaRelation_PMTransIDTestNo();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DimensionParameter_Class_obj.dimensionMethodID = Convert.ToInt64(dr["DimensionMethodID"]);
                        if (DimensionParameter_Class_obj.Select_DimensionParaRelation_StatusIDDimensionMethodID().Rows.Count>0)
                        {
                            dgReadings.Rows.Add();
                            dgReadings["DimensionMethodID", dgReadings.Rows.Count - 1].Value = Convert.ToInt64(dr["DimensionMethodID"]);
                            dgReadings["ParameterName", dgReadings.Rows.Count - 1].Value = Convert.ToString(dr["DimensionParaName"]);
                            dgReadings["Min", dgReadings.Rows.Count - 1].Value = Convert.ToString(dr["NormsMin"]);
                            dgReadings["Max", dgReadings.Rows.Count - 1].Value = Convert.ToString(dr["NormsMax"]);
                        }                       
                    }

                    for (int i = 0; i < dgReadings.Rows.Count; i++)
                    {
                        DimensionParameter_Class_obj.dimensionMethodID = Convert.ToInt64(dgReadings["DimensionMethodID", i].Value);
                        dt = DimensionParameter_Class_obj.Select_DimensionParaRelation_StatusIDDimensionMethodID();
                        int j = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dgReadings["Obs" + j, i].Value = Convert.ToString(dr["Obs"]);

                            if (dgReadings["Max", i].Value != null && dgReadings["Max", i].Value.ToString() != "")
                            {
                                if (Convert.ToDouble(dgReadings["Obs" + j, i].Value) > Convert.ToDouble(dgReadings["Max", i].Value))
                                {
                                    cntRed++;
                                    dgReadings["Obs" + j, i].Style.BackColor = Color.Red;
                                    j++;//Increment the col number cause continue statement goes to directly foreach loop without executing other loops or code
                                    continue;
                                }
                                else
                                {
                                   
                                    dgReadings["Obs" + j, i].Style.BackColor = Color.White;
                                }
                            }

                            if (dgReadings["Min", i].Value != null && dgReadings["Min", i].Value.ToString() != "")
                            {
                                if (Convert.ToDouble(dgReadings["Obs" + j, i].Value) < Convert.ToDouble(dgReadings["Min", i].Value))
                                {
                                    cntRed++;
                                    dgReadings["Obs" + j, i].Style.BackColor = Color.Red;
                                    j++;
                                    continue;
                                }
                                else
                                {
                                    dgReadings["Obs" + j, i].Style.BackColor = Color.White;
                                }
                            }


                            j++;
                        }
                    }
                }
                else
                {
                    DimensionParameter_Class_obj.pmCodeID = PMCodeID;
                    DimensionParameter_Class_obj.testNo = PMTestNo;
                    dt = DimensionParameter_Class_obj.Select_DimensionParaRelation_PMCodeIDTestNo();
                    // if norms exist execute if loop & norms not exist then execute else loop
                    if (dt.Rows.Count > 0)
                    {
                        dgReadings.DataSource = dt;
                    }
                    for (int i = 0; i < DimensionParameter_Class_obj.quantity; i++)
                    {
                        dgReadings.Columns.Add("Obs" + i, "Obs " + (i + 1));
                        dgReadings.Columns["Obs" + i].Width = 60;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            //Create SQL Connection for SQL Transaction
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);
            try
            {
                for (int i = 0; i < dgReadings.Columns.Count; i++)
                {
                    for (int j = 0; j < dgReadings.Rows.Count; j++)
                    {
                        if (dgReadings[i, j].Value == null || dgReadings[i, j].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Enter all observations", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgReadings.Focus();
                            return;
                        }
                    }
                }

                if (RdoAccepted.Checked == false && RdoRejected.Checked == false)
                {
                    MessageBox.Show("Select Accept/Reject option ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RdoAccepted.Focus();
                    return;
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                //Use SQL Transaction 
                con.Open();

                DimensionParaTransaction_Class_obj.trans = con.BeginTransaction();
                DimensionParaTransaction_Class_obj.supplierCOCID = supplierCOCID;
                DimensionParaTransaction_Class_obj.testNo = PMTestNo;

                if (RdoAccepted.Checked == true)
                {
                    DimensionParaTransaction_Class_obj.status = 'A';
                }
                else if (RdoRejected.Checked == true)
                {
                    DimensionParaTransaction_Class_obj.status = 'R';
                }

                DimensionParaTransaction_Class_obj.inspectedBy = null;//Convert.ToInt32(cmbInspectedBy.SelectedValue);
                DimensionParaTransaction_Class_obj.loginID = FrmMain.LoginID;
                if (DimensionParaTransaction_Class_obj.dpTransStatusID <= 0)
                {
                    DimensionParaTransaction_Class_obj.dpTransStatusID = DimensionParaTransaction_Class_obj.Insert_DimensionParaTransStatus();
                }
                else
                {
                    DimensionParaTransaction_Class_obj.Update_DimensionParaTransStatus();
                }
                if (DimensionParaTransaction_Class_obj.dpTransStatusID != 0)
                {
                    DimensionParaTransaction_Class_obj.Delete_DimensionParaTransStatus();
                    for (int i = 0; i < dgReadings.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgReadings.Columns.Count; j++)
                        {
                            if (dgReadings.Columns[j].Name.StartsWith("Obs"))
                            {
                                //DimensionParaTransaction_Class_obj.dpTransStatusID = statusID;
                                DimensionParaTransaction_Class_obj.dimensionMethodID = Convert.ToInt64(dgReadings["DimensionMethodID", i].Value);
                                DimensionParaTransaction_Class_obj.obs = Convert.ToDouble(dgReadings.Rows[i].Cells[j].Value);
                                DimensionParaTransaction_Class_obj.Insert_DimensionParaObs();
                            }
                        }
                    }

                }
                DimensionParaTransaction_Class_obj.trans.Commit();
                GlobalVariables.lstStatusID.Add(DimensionParaTransaction_Class_obj.dpTransStatusID);
                MessageBox.Show("Observations saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.RdoRejected.Checked && rdAcceptRmTransaction!=null)
                {
                    rdAcceptRmTransaction.Checked = false;
                    rdAcceptRmTransaction.Enabled = false;
                }
                else if (!this.RdoRejected.Checked && rdAcceptRmTransaction != null)
                {
                    rdAcceptRmTransaction.Enabled = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                DimensionParaTransaction_Class_obj.trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
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

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Cell validating event for Test grids
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgReadings_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //Check first column name start with observations
                if (!dgReadings.Columns[e.ColumnIndex].Name.StartsWith("Obs"))
                {
                    return;
                }
                if (e.RowIndex < 0 || e.ColumnIndex != dgReadings.Columns[e.ColumnIndex].Index)
                {
                    return;
                }
                else
                {
                    if (dgReadings.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                    {
                        if (dgReadings["Max", dgReadings.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgReadings["Min", dgReadings.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                        {
                            cntRed++;
                            dgReadings.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }

                        if (dgReadings["Max", dgReadings.CurrentCell.RowIndex].Value != null && dgReadings["Max", dgReadings.CurrentCell.RowIndex].Value.ToString() != "")
                        {
                            if (Convert.ToDouble(dgReadings.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgReadings["Max", dgReadings.CurrentCell.RowIndex].Value))
                            {
                                cntRed++;
                                dgReadings.CurrentCell.Style.BackColor = Color.Red;
                                return;
                            }
                            else
                            {
                                if (dgReadings.CurrentCell.Style.BackColor == Color.Red)
                                {
                                    cntRed--;
                                }
                                dgReadings.CurrentCell.Style.BackColor = Color.White;
                            }
                        }

                        if (dgReadings["Min", dgReadings.CurrentCell.RowIndex].Value != null && dgReadings["Min", dgReadings.CurrentCell.RowIndex].Value.ToString() != "")
                        {
                            if (Convert.ToDouble(dgReadings.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgReadings["Min", dgReadings.CurrentCell.RowIndex].Value))
                            {
                                cntRed++;
                                dgReadings.CurrentCell.Style.BackColor = Color.Red;
                                return;
                            }
                            else
                            {
                                if (dgReadings.CurrentCell.Style.BackColor == Color.Red)
                                {
                                    cntRed--;
                                }
                                dgReadings.CurrentCell.Style.BackColor = Color.White;
                            }
                        }
                    }
                    else
                    {
                        dgReadings.CurrentCell.Style.BackColor = Color.White;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Privious Event not having the changes For Four reading to Rejection
        //private void dgReadings_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (!dgReadings.Columns[e.ColumnIndex].Name.StartsWith("Obs"))
        //        {
        //            return;
        //        }
        //        if (e.RowIndex < 0 || e.ColumnIndex != dgReadings.Columns[e.ColumnIndex].Index)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            if (PMTransID <= 0)
        //            {
        //                for (int i = 0; i < dgReadings.Rows.Count; i++)
        //                {
        //                    if (dgReadings["Obs" + i, i].Style.BackColor == Color.Red)
        //                    {
        //                        RdoRejected.Checked = true;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        RdoAccepted.Checked = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dgReadings_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (!dgReadings.Columns[e.ColumnIndex].Name.StartsWith("Obs"))
                {
                    return;
                }
                if (e.RowIndex < 0 || e.ColumnIndex != dgReadings.Columns[e.ColumnIndex].Index)
                {
                    return;
                }
                else
                {
                    if (cntRed > 4)
                    {
                        RdoAccepted.Checked = false;
                        RdoAccepted.Enabled = false;
                    }
                    else
                    {
                        RdoAccepted.Enabled = true;
                    }

                    if (PMTransID <= 0)
                    {
                        
                        for (int i = 0; i < dgReadings.Rows.Count-1; i++)
                        {
                            for (int j = 0; j < dgReadings.Columns.Count; j++)
                            {
                                if (dgReadings[j, i].Style.BackColor == Color.Red)
                                {
                                    RdoRejected.Checked = true;
                                    return;
                                }
                                else if (RdoAccepted.Enabled == true)
                                {
                                    RdoAccepted.Checked = true;
                                }
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgReadings_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (dgReadings.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void dgReadings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (dgReadings.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        //private System.Drawing.Printing.PrintDocument printDocument2 = new System.Drawing.Printing.PrintDocument();

        private void BtnProtocol_Click(object sender, EventArgs e)
        {
            if (dgReadings.Rows.Count > 0)
            {
                //PrintDialog printDialog = new PrintDialog();
                //printDialog.Document = printDocument2;
                //printDialog.UseEXDialog = true;
                //if (DialogResult.OK == printDialog.ShowDialog())
                //{
                //printDocument2.DocumentName = "Dimension Report";
                //printDocument2.Print();
                //}
                FrmMain frmMain = new FrmMain();
                PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
                objPPdialog.Document = printDocument2;
              // objPPdialog.
                objPPdialog.ShowDialog();
                //DimensionParameter_Class_obj.testNo = PMTestNo;
                //QTMS.Reports_Forms.FrmDimensionAnalysisProtocol_Report objDimenssion = new QTMS.Reports_Forms.FrmDimensionAnalysisProtocol_Report(DimensionParameter_Class_obj.testNo, DimensionParameter_Class_obj.quantity);
                //objDimenssion.Show();
            }
            else
            {
                MessageBox.Show("Sorry No Record Found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument2_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgReadings.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgReadings.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgReadings.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgReadings.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Dimension Analysis", new Font(dgReadings.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Dimension Analysis", new Font(dgReadings.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgReadings.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgReadings.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Dimension Analysis", new Font(new Font(dgReadings.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            e.Graphics.DrawString("Protocol No :" + ProtocolNo, new Font(dgReadings.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left , (e.MarginBounds.Top + 30) -
                                    e.Graphics.MeasureString("Protocol No :" + ProtocolNo, new Font(dgReadings.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);
                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top + 30;
                            foreach (DataGridViewColumn GridCol in dgReadings.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel_Grid(dgReadings);

        }


        private void ExportToExcel_Grid(DataGridView gd)
        {

            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = "Dimension Analysys";

            Microsoft.Office.Interop.Excel.Range range1 = worksheet.get_Range("A1", "A1");
            range1.Value2 = "Dimension Analysis";
            //range1.Merge(true);
            range1 = worksheet.get_Range("A2", "A2");
            range1.Value2 = "Date :";
            range1 = worksheet.get_Range("B2", "B2");
            range1.Value2 = DateTime.Now.ToShortDateString();
            range1 = worksheet.get_Range("A3", "A3");
            range1.Value2 = "Protocol No:";
            range1 = worksheet.get_Range("B3", "b3");
            range1.Value2 = ProtocolNo;

            // storing header part in Excel
            for (int i = 1; i < gd.Columns.Count + 1; i++)
            {
                worksheet.Cells[4, i] = gd.Columns[i - 1].HeaderText;
            }

            
            // storing Each row and column value to excel sheet
            for (int i = 0; i < gd.Rows.Count; i++)
            {
                for (int j = 0; j < gd.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(getColumnName(j + 1) + Convert.ToString(i + 5), getColumnName(j +1) + Convert.ToString(i + 5));
                    range.Value2 = Convert.ToString(gd.Rows[i].Cells[j].Value);
                }
            }

            releaseObject(worksheet);
            releaseObject(workbook);

            releaseObject(app);
            // Exit from the application
            //app.Quit();
        }

        private string getColumnName(int j)
        {
            string clmName = "";
            int rem = j % 26;
            switch (rem)
            {
                case 1: clmName = "A"; break; case 2: clmName = "B"; break; case 3: clmName = "c"; break;
                case 4: clmName = "d"; break; case 5: clmName = "e"; break; case 6: clmName = "f"; break;
                case 7: clmName = "g"; break; case 8: clmName = "h"; break; case 9: clmName = "i"; break;
                case 10: clmName = "j"; break; case 11: clmName = "k"; break; case 12:clmName = "l"; break;
                case 13: clmName = "m"; break; case 14: clmName = "n"; break; case 15: clmName = "o"; break;
                case 16: clmName = "p"; break; case 17: clmName = "q"; break; case 18: clmName = "r"; break;
                case 19: clmName = "s"; break; case 20: clmName = "t"; break; case 21: clmName = "u"; break;
                case 22: clmName = "v"; break; case 23: clmName = "w"; break; case 24: clmName = "x"; break;
                case 25: clmName = "y"; break; case 0: clmName = "z"; break;
            }
            if (j>26)
            {
                if (j>26 && j<(26*2))
                {
                    clmName = "A" + clmName;
                }
                if (j > (26*2) && j < (26*3))
                {
                    clmName = "b" + clmName;
                }
                if (j > (26 * 3) && j < (26 * 4))
                {
                    clmName = "c" + clmName;
                }
                if (j > (26 * 4) && j < (26 * 5))
                {
                    clmName = "d" + clmName;
                }
            }
            return clmName;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                // ex.Message = "Exception occured";
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void groupBoxReadings_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}