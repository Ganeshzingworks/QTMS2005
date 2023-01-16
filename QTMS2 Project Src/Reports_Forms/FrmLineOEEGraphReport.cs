using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Transactions;
using Excel = Microsoft.Office.Interop.Excel;
namespace QTMS.Reports_Forms
{
	/// <summary>
	/// Summary description for FrmTestMaster.
	/// </summary>
	public class FrmLineOEEGraphReport : System.Windows.Forms.Form
    {
		# region Varibles
        LineOEETransaction LineOEETransaction_obj = new LineOEETransaction();
        DateTime date = new DateTime();
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        Excel.Range workSheet_range = null;	
		#endregion

        private Panel panelOuter;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelBottom;
        private ToolStripButton toolStripButtonClose;
        private Panel panelFill;
        private GroupBox groupBox2;
        private Button btnReset;
        private Button btnGenerateReport;
        private Button BtnExit;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker DtpDateFrom;
        private Label label1;
        private DateTimePicker DtpDateTo;
        private ToolStrip toolStrip2;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripLabel toolStripStatusLabelTime;
        private ToolStripLabel toolStripLabelMsgName;
        private BackgroundWorker bkgWorkerExcel;
        private System.Windows.Forms.Timer timer1;
        private RadioButton rdShiftwise;
        private RadioButton rdDaywise;
        private IContainer components;

		public FrmLineOEEGraphReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
            FrmLineOEEGraphReport_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdShiftwise = new System.Windows.Forms.RadioButton();
            this.rdDaywise = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMsgName = new System.Windows.Forms.ToolStripLabel();
            this.bkgWorkerExcel = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(681, 214);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(679, 30);
            this.panelTop.TabIndex = 41;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(679, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(231, 27);
            this.toolStripLabel1.Text = "Line OEE Graph Monthwise Report";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, -39);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(679, 251);
            this.panelBottom.TabIndex = 3;
            // 
            // panelFill
            // 
            this.panelFill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(679, 251);
            this.panelFill.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnGenerateReport);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(147, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateReport.Location = new System.Drawing.Point(247, 15);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(174, 28);
            this.btnGenerateReport.TabIndex = 0;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(442, 15);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(80, 28);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.rdShiftwise);
            this.groupBox1.Controls.Add(this.rdDaywise);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtpDateTo);
            this.groupBox1.Controls.Add(this.DtpDateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdShiftwise
            // 
            this.rdShiftwise.AutoSize = true;
            this.rdShiftwise.Location = new System.Drawing.Point(362, 13);
            this.rdShiftwise.Name = "rdShiftwise";
            this.rdShiftwise.Size = new System.Drawing.Size(93, 20);
            this.rdShiftwise.TabIndex = 56;
            this.rdShiftwise.TabStop = true;
            this.rdShiftwise.Text = "Shift Wise";
            this.rdShiftwise.UseVisualStyleBackColor = true;
            // 
            // rdDaywise
            // 
            this.rdDaywise.AutoSize = true;
            this.rdDaywise.Checked = true;
            this.rdDaywise.Location = new System.Drawing.Point(215, 13);
            this.rdDaywise.Name = "rdDaywise";
            this.rdDaywise.Size = new System.Drawing.Size(87, 20);
            this.rdDaywise.TabIndex = 55;
            this.rdDaywise.TabStop = true;
            this.rdDaywise.Text = "Day Wise";
            this.rdDaywise.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "To Date :";
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateTo.Checked = false;
            this.DtpDateTo.CustomFormat = "MMM-yyyy";
            this.DtpDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTo.Location = new System.Drawing.Point(440, 48);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.ShowCheckBox = true;
            this.DtpDateTo.Size = new System.Drawing.Size(136, 23);
            this.DtpDateTo.TabIndex = 1;
            this.DtpDateTo.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            // 
            // DtpDateFrom
            // 
            this.DtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateFrom.Checked = false;
            this.DtpDateFrom.CustomFormat = "MMM-yyyy";
            this.DtpDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateFrom.Location = new System.Drawing.Point(189, 48);
            this.DtpDateFrom.Name = "DtpDateFrom";
            this.DtpDateFrom.ShowCheckBox = true;
            this.DtpDateFrom.Size = new System.Drawing.Size(132, 23);
            this.DtpDateFrom.TabIndex = 0;
            this.DtpDateFrom.Value = new System.DateTime(2008, 1, 25, 0, 0, 0, 0);
            this.DtpDateFrom.ValueChanged += new System.EventHandler(this.DtpDateFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "From Date :";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelTime,
            this.toolStripLabelMsgName});
            this.toolStrip2.Location = new System.Drawing.Point(0, 189);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(681, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(650, 22);
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(19, 22);
            this.toolStripStatusLabelTime.Text = "00";
            this.toolStripStatusLabelTime.Visible = false;
            // 
            // toolStripLabelMsgName
            // 
            this.toolStripLabelMsgName.Name = "toolStripLabelMsgName";
            this.toolStripLabelMsgName.Size = new System.Drawing.Size(0, 22);
            // 
            // bkgWorkerExcel
            // 
            this.bkgWorkerExcel.WorkerReportsProgress = true;
            this.bkgWorkerExcel.WorkerSupportsCancellation = true;
            this.bkgWorkerExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorkerExcel_DoWork);
            this.bkgWorkerExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgWorkerExcel_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmLineOEEGraphReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(681, 214);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineOEEGraphReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line OEE Graph Monthwise Report";
            this.Load += new System.EventHandler(this.FrmLineOEEGraphReport_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private static Reports_Forms.FrmLineOEEGraphReport FrmLineOEEGraphReport_Obj = null;
        public static Reports_Forms.FrmLineOEEGraphReport GetInstance()
        {
            if (FrmLineOEEGraphReport_Obj  == null)
            {
                FrmLineOEEGraphReport_Obj = new Reports_Forms.FrmLineOEEGraphReport();
            }
            return FrmLineOEEGraphReport_Obj;
        }
        string monthYear = string.Empty;
        private void FrmLineOEEGraphReport_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            this.WindowState = FormWindowState.Normal;
           
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
            
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                 
                if (IsValid())
                {
                    monthYear = String.Format("{0:MMM-yy}", DtpDateFrom.Value);
                    if (!bkgWorkerExcel.IsBusy)
                    {

                        bkgWorkerExcel.RunWorkerAsync();
                        timer1.Start();
                        //MessageBox.Show(toolStripLabelMsgName.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
                     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // This function is used for show Data Day wise
        private void getData()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = new DataSet();
                ds = LineMaster_Class_Obj.Select_LineMaster();

                DataTable dt = new DataTable();
                dt = LineOEETransaction_obj.Select_GetDate_BetweenTwoDate();
                
                if (dt.Rows.Count > 0 && dt.Rows.Count <= 31)
                {
                    dt.Columns.Add("Line Name");
                    foreach (DataRow dr in dt.Rows)
                    {
                        dt.Columns.Add(String.Format("{0:dd-MMM-yy}", dr["DateValue"]));

                        //dt.Columns.Add(dr["DateValue"]);
                    }
                    dt.Columns.Remove("DateValue");
                    dt.Rows.Clear();
                   
                }

                foreach (DataRow drLine in ds.Tables[0].Rows)
                {
                    dt = GetFinalData(dt, Convert.ToInt32(drLine["LNo"]), Convert.ToString(drLine["LineDesc"]));
                }
                CreateExcelFile(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable GetFinalData(DataTable dt, int Lno, string lineDesc)
        {
            try
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    LineOEETransaction_obj.lno = Lno;
                    //LineOEETransaction_obj.transDate = Convert.ToDateTime(dt.Columns[i].Caption);
                    LineOEETransaction_obj.transDate = DateTime.Parse(dt.Columns[i].Caption, new CultureInfo("en-CA"));
                   
                    DataTable dtFinal = new DataTable();
                    dtFinal = LineOEETransaction_obj.Select_LineOEEDataExistGraph_Report();
                    dt.Rows[dt.Rows.Count - 1][i] = dtFinal.Rows[0]["Time"];
                }
                dt.Rows[dt.Rows.Count - 1]["Line Name"] = lineDesc;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // This function is used for show data by shift wise
        private void getShiftwiseData()
        {
            try
            {
                ArrayList listDay = new ArrayList();
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = new DataSet();
                ds = LineMaster_Class_Obj.Select_LineMaster();

                DataTable dt = new DataTable();
                dt = LineOEETransaction_obj.Select_GetDate_BetweenTwoDate();

                if (dt.Rows.Count > 0 && dt.Rows.Count <= 31)
                {
                    dt.Columns.Add("Line Name");
                    foreach (DataRow dr in dt.Rows)
                    {
                        listDay.Add(String.Format("{0:dd-MMM-yy}", dr["DateValue"]));
                        // Every day has three shift. Add data in shift wise
                        for (int i = 1; i <= 3; i++)
                        {
                            dt.Columns.Add(String.Format("{0:dd-MMM-yy}", dr["DateValue"]) + Convert.ToString("Shift" + i));
                        }
                            

                        //dt.Columns.Add(dr["DateValue"]);
                    }
                    dt.Columns.Remove("DateValue");
                    dt.Rows.Clear();

                }

                foreach (DataRow drLine in ds.Tables[0].Rows)
                {
                    
                    dt = GetShiftWiseFinalData(dt, Convert.ToInt32(drLine["LNo"]), Convert.ToString(drLine["LineDesc"]));
                }
                CreateShiftwiseExcelFile(dt);
                //CreateExcelFile(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // This function is used for show data by shift wise
        private DataTable GetShiftWiseFinalData(DataTable dt, int Lno, string lineDesc)
        {
            try
            {

               

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                   
                    string[] str = new string[2];
                    str[0] = dt.Columns[i].Caption.Substring(0, 9);
                    str[1] = dt.Columns[i].Caption.Substring(9);

                    LineOEETransaction_obj.lno = Lno;
                    //LineOEETransaction_obj.transDate = Convert.ToDateTime(str[0]);
                    LineOEETransaction_obj.transDate = DateTime.Parse(str[0], new CultureInfo("en-CA")); 
                    if (str[1] == "Shift1")
                        LineOEETransaction_obj.shiftID = 1;
                    else if (str[1] == "Shift2")
                        LineOEETransaction_obj.shiftID = 2;
                    else if (str[1] == "Shift3")
                        LineOEETransaction_obj.shiftID = 3;


                    DataTable dtFinal = new DataTable();
                    dtFinal = LineOEETransaction_obj.Select_LineOEEDataExistGraph_ShiftWiseReport();
                    dt.Rows[dt.Rows.Count - 1][i] = dtFinal.Rows[0]["Time"];
                }
                dt.Rows[dt.Rows.Count - 1]["Line Name"] = lineDesc;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        private bool IsValid()
        {
            try
            {
                if (DtpDateFrom.Checked && DtpDateTo.Checked)
                {
                    if (DtpDateFrom.Value > DtpDateTo.Value)
                    {
                        MessageBox.Show("End date should be gretter than start date.");
                        return false;
                    }
                }

                if (DtpDateFrom.Checked == true)
                {
                    DateTime fromDate = new DateTime(DtpDateFrom.Value.Year,DtpDateFrom.Value.Month,1);

                    LineOEETransaction_obj.startdate = Convert.ToString(fromDate);//DtpDateFrom.Value.ToShortDateString();
                    
                    DtpDateTo.Checked = true;
                    DateTime toDate = new DateTime(DtpDateFrom.Value.Year, DtpDateFrom.Value.Month, 1).AddMonths(1).AddDays(-1);
                    LineOEETransaction_obj.enddate = Convert.ToString(toDate);//DtpDateTo.Value.ToShortDateString();
                    DtpDateTo.Enabled = false;
                }
                else
                {
                    //LineOEETransaction_obj.startdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                    MessageBox.Show("Please select the start date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (DtpDateTo.Checked == true)
                {
                    DateTime toDate = new DateTime(DtpDateFrom.Value.Year, DtpDateFrom.Value.Month, 1).AddMonths(1).AddDays(-1);
                    LineOEETransaction_obj.enddate = Convert.ToString(toDate);//DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    //LineOEETransaction_obj.enddate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                    MessageBox.Show("Please select the end date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //if (txtPath.Text == "")
                //{
                //    MessageBox.Show("Select Export Path", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPath.Focus();
                //    return false;
                //}
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
             
       

        private void bkgWorkerExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (bkgWorkerExcel.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (rdDaywise.Checked)
                    getData();
                else if (rdShiftwise.Checked)
                    getShiftwiseData();
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        private void bkgWorkerExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //bool result = (bool)e.Result;
            //if (result)
            //    //toolStripLabelMsgName.Text = "Excel Created Successfully";
            //else
            //    toolStripLabelMsgName.Text = "Some Problem in Creating File";

            toolStripProgressBar1.Value = 100;

            bkgWorkerExcel.Dispose();
            btnGenerateReport.Enabled = true;
            timer1.Stop();
            //MessageBox.Show(strMsg);

            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            toolStripProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(date);
            string sTime = "    " + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            toolStripStatusLabelTime.Text = sTime;
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value = 0;
            }
            toolStripProgressBar1.PerformStep();
        }

        #region Create Excel File For Show Data Daywise 

        private void CreateExcelFile(DataTable dtExcel)//(string efolderPath,string eFile, DataTable dtExcel)
        {
            try
            {
                application = new Excel.ApplicationClass();

                workbook = application.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

                // Headers
                ExcelHeaders(dtExcel.Columns.Count);


                for (int row = 0; row < dtExcel.Rows.Count; row++)
                {
                    //workSheet_range.NumberFormat = "0.00";
                    workSheet_range.WrapText = true;
                    //progressBar1.Value++;
                    //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
                    worksheet.Cells[row + 3, 1] = dtExcel.Rows[row][0].ToString();
                    workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    //workSheet_range.Interior.ColorIndex = 4;

                    if (Convert.ToString(dtExcel.Rows[row][1]) != "")
                    {
                        worksheet.Cells[row + 3, 2] = dtExcel.Rows[row][1].ToString();
                        workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 2] = "";//dtExcel.Rows[row][1].ToString();
                        workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }

                    if (Convert.ToString(dtExcel.Rows[row][2]) != "")
                    {
                        worksheet.Cells[row + 3, 3] = dtExcel.Rows[row][2].ToString();
                        workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 3] = "";//dtExcel.Rows[row][2].ToString();
                        workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][3]) != "")
                    {
                        worksheet.Cells[row + 3, 4] = dtExcel.Rows[row][3].ToString();
                        workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 4] = "";//dtExcel.Rows[row][3].ToString();
                        workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][4]) != "")
                    {
                        worksheet.Cells[row + 3, 5] = dtExcel.Rows[row][4].ToString();
                        workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 5] = "";// dtExcel.Rows[row][4].ToString();
                        workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][5]) != "")
                    {
                        worksheet.Cells[row + 3, 6] = dtExcel.Rows[row][5].ToString();
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 6] = "";//dtExcel.Rows[row][5].ToString();
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][6]) != "")
                    {
                        worksheet.Cells[row + 3, 7] = dtExcel.Rows[row][6].ToString();
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 7] = "";//dtExcel.Rows[row][6].ToString();
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][7]) != "")
                    {
                        worksheet.Cells[row + 3, 8] = dtExcel.Rows[row][7].ToString();
                        workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 8] = "";//dtExcel.Rows[row][7].ToString();
                        workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][8]) != "")
                    {
                        worksheet.Cells[row + 3, 9] = dtExcel.Rows[row][8].ToString();
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 9] = "";//dtExcel.Rows[row][8].ToString();
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][9]) != "")
                    {
                        worksheet.Cells[row + 3, 10] = dtExcel.Rows[row][9].ToString();
                        workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 10] = "";//dtExcel.Rows[row][9].ToString();
                        workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][10]) != "")
                    {
                        worksheet.Cells[row + 3, 11] = dtExcel.Rows[row][10].ToString();
                        workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 11] = "";//dtExcel.Rows[row][10].ToString();
                        workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                       
                    }
                    if (Convert.ToString(dtExcel.Rows[row][11]) != "")
                    {
                        worksheet.Cells[row + 3, 12] = dtExcel.Rows[row][11].ToString();
                        workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 12] = "";//dtExcel.Rows[row][11].ToString();
                        workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                    if (Convert.ToString(dtExcel.Rows[row][12]) != "")
                    {
                        worksheet.Cells[row + 3, 13] = dtExcel.Rows[row][12].ToString();
                        workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 13] = "";//dtExcel.Rows[row][12].ToString();
                        workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                      
                    }
                    if (Convert.ToString(dtExcel.Rows[row][13]) != "")
                    {
                        worksheet.Cells[row + 3, 14] = dtExcel.Rows[row][13].ToString();
                        workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 14] = "";//dtExcel.Rows[row][13].ToString();
                        workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][14]) != "")
                    {
                        worksheet.Cells[row + 3, 15] = dtExcel.Rows[row][14].ToString();
                        workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 15] = "";//dtExcel.Rows[row][14].ToString();
                        workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][15]) != "")
                    {
                        worksheet.Cells[row + 3, 16] = dtExcel.Rows[row][15].ToString();
                        workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 16] = "";//dtExcel.Rows[row][15].ToString();
                        workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                       
                    }
                    if (Convert.ToString(dtExcel.Rows[row][16]) != "")
                    {
                        worksheet.Cells[row + 3, 17] = dtExcel.Rows[row][16].ToString();
                        workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 17] = "";//dtExcel.Rows[row][16].ToString();
                        workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                       
                    }
                    if (Convert.ToString(dtExcel.Rows[row][17]) != "")
                    {
                        worksheet.Cells[row + 3, 18] = dtExcel.Rows[row][17].ToString();
                        workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 18] = "";//dtExcel.Rows[row][17].ToString();
                        workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                       
                    }
                    if (Convert.ToString(dtExcel.Rows[row][18]) != "")
                    {
                        worksheet.Cells[row + 3, 19] = dtExcel.Rows[row][18].ToString();
                        workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 19] = "";//dtExcel.Rows[row][18].ToString();
                        workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][19]) != "")
                    {
                        worksheet.Cells[row + 3, 20] = dtExcel.Rows[row][19].ToString();
                        workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 20] = "";//dtExcel.Rows[row][19].ToString();
                        workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
               
                    }
                    if (Convert.ToString(dtExcel.Rows[row][20]) != "")
                    {
                        worksheet.Cells[row + 3, 21] = dtExcel.Rows[row][20].ToString();
                        workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 21] = "";//dtExcel.Rows[row][20].ToString();
                        workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][21]) != "")
                    {
                        worksheet.Cells[row + 3, 22] = dtExcel.Rows[row][21].ToString();
                        workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 22] = "";//dtExcel.Rows[row][21].ToString();
                        workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][22]) != "")
                    {
                        worksheet.Cells[row + 3, 23] = dtExcel.Rows[row][22].ToString();
                        workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 23] = "";//dtExcel.Rows[row][22].ToString();
                        workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();                     
                    }
                    if (Convert.ToString(dtExcel.Rows[row][23]) != "")
                    {
                        worksheet.Cells[row + 3, 24] = dtExcel.Rows[row][23].ToString();
                        workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 24] = "";//dtExcel.Rows[row][23].ToString();
                        workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][24]) != "")
                    {
                        worksheet.Cells[row + 3, 25] = dtExcel.Rows[row][24].ToString();
                        workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 25] = "";//dtExcel.Rows[row][24].ToString();
                        workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();                       
                    }
                    if (Convert.ToString(dtExcel.Rows[row][25]) != "")
                    {
                        worksheet.Cells[row + 3, 26] = dtExcel.Rows[row][25].ToString();
                        workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 26] = "";//dtExcel.Rows[row][25].ToString();
                        workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][26]) != "")
                    {
                        worksheet.Cells[row + 3, 27] = dtExcel.Rows[row][26].ToString();
                        workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 27] = "";//dtExcel.Rows[row][26].ToString();
                        workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }
                    if (Convert.ToString(dtExcel.Rows[row][27]) != "")
                    {
                        worksheet.Cells[row + 3, 28] = dtExcel.Rows[row][27].ToString();
                        workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 4;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 28] = "";//dtExcel.Rows[row][27].ToString();
                        workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        
                    }

                    //Check for month date 


                    if (dtExcel.Columns.Count == 29)
                    {
                        if (Convert.ToString(dtExcel.Rows[row][28]) != "")
                        {
                            worksheet.Cells[row + 3, 29] = dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 29] = "";//dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        
                    }
                    else if (dtExcel.Columns.Count == 30)
                    {
                        if (Convert.ToString(dtExcel.Rows[row][28]) != "")
                        {
                            worksheet.Cells[row + 3, 29] = dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 29] = "";//dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][29]) != "")
                        {
                            worksheet.Cells[row + 3, 30] = dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 30] = "";//dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }

                        
                    }
                    else if (dtExcel.Columns.Count == 31)
                    {
                        if (Convert.ToString(dtExcel.Rows[row][28]) != "")
                        {
                            worksheet.Cells[row + 3, 29] = dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 29] = "";//dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][29]) != "")
                        {
                            worksheet.Cells[row + 3, 30] = dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 30] = "";//dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][30]) != "")
                        {
                            worksheet.Cells[row + 3, 31] = dtExcel.Rows[row][30].ToString();
                            workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 31] = "";// dtExcel.Rows[row][30].ToString();
                            workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        
                    }
                    else if (dtExcel.Columns.Count == 32)
                    {
                        if (Convert.ToString(dtExcel.Rows[row][28]) != "")
                        {
                            worksheet.Cells[row + 3, 29] = dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 29] = "";//dtExcel.Rows[row][28].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][29]) != "")
                        {
                            worksheet.Cells[row + 3, 30] = dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 30] = "";//dtExcel.Rows[row][29].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][30]) != "")
                        {
                            worksheet.Cells[row + 3, 31] = dtExcel.Rows[row][30].ToString();
                            workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 31] = "";//dtExcel.Rows[row][30].ToString();
                            workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }
                        if (Convert.ToString(dtExcel.Rows[row][31]) != "")
                        {
                            worksheet.Cells[row + 3, 32] = dtExcel.Rows[row][31].ToString();
                            workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 4;
                        }
                        else
                        {
                            worksheet.Cells[row + 3, 32] = "";//dtExcel.Rows[row][31].ToString();
                            workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        }                   
                        
                    }               
                   
                   
                }
                //SAVE WORKBOOK AT EXPORT PATH
                //workbook.SaveAs(eFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                application.Visible = true;
                //application.Workbooks.Close();


                releaseObject(workbook);
                releaseObject(worksheet);
                releaseObject(application);
                //application.Quit();
                //efolderPath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void ExcelHeaders(int cnt)
        {
            try
            {
                CreateHeaders(2, 1, "Line Name", "A2", "A2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 2, "01-" + monthYear, "B2", "B2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 3, "02-" + monthYear, "C2", "C2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 4, "03-" + monthYear, "D2", "D2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 5, "04-" + monthYear, "E2", "E2", 0, "DARK YELLOW", true, 10); // SMT
                CreateHeaders(2, 6, "05-" + monthYear, "F2", "F2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 7, "06-" + monthYear, "G2", "G2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 8, "07-" + monthYear, "H2", "H2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 9, "08-" + monthYear, "I2", "I2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 10, "09-" + monthYear, "J2", "J2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 11, "10-" + monthYear, "K2", "K2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 12, "11-" + monthYear, "L2", "L2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 13, "12-" + monthYear, "M2", "M2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 14, "13-" + monthYear, "N2", "N2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 15, "14-" + monthYear, "O2", "O2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 16, "15-" + monthYear, "P2", "P2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 17, "16-" + monthYear, "Q2", "Q2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 18, "17-" + monthYear, "R2", "R2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 19, "18-" + monthYear, "S2", "S2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 20, "19-" + monthYear, "T2", "T2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 21, "20-" + monthYear, "U2", "U2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 22, "21-" + monthYear, "V2", "V2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 23, "22-" + monthYear, "W2", "W2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 24, "23-" + monthYear, "X2", "X2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 25, "24-" + monthYear, "Y2", "Y2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 26, "25-" + monthYear, "Z2", "Z2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 27, "26-" + monthYear, "AA2", "AA2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 28, "27-" + monthYear, "AB2", "AB2", 0, "DARK YELLOW", true, 10);
                if (cnt == 29)
                {
                    CreateHeaders(2, 29, "28-" + monthYear, "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                    return;
                }
                if (cnt == 30)
                {
                    CreateHeaders(2, 29, "28-" + monthYear, "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 30, "29-" + monthYear, "AD2", "AD2", 0, "DARK YELLOW", true, 10);
                    return;
                }
                if (cnt == 31)
                {
                    CreateHeaders(2, 29, "28-" + monthYear, "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 30, "29-" + monthYear, "AD2", "AD2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 31, "30-" + monthYear, "AE2", "AE2", 0, "DARK YELLOW", true, 10);
                    return;
                }
                if (cnt == 32)
                {
                    CreateHeaders(2, 29, "28-" + monthYear, "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 30, "29-" + monthYear, "AD2", "AD2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 31, "30-" + monthYear, "AE2", "AE2", 0, "DARK YELLOW", true, 10);
                    CreateHeaders(2, 32, "31-" + monthYear, "AF2", "AF2", 0, "DARK YELLOW", true, 10);
                    return;
                }
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private void CreateHeaders(int row, int col, string hText, string cell1, string cell2, int mergeColumn, string b, bool font, int size)
        {
            try
            {
                worksheet.Cells[row, col] = hText;
                workSheet_range = worksheet.get_Range(cell1, cell2);
                workSheet_range.Merge(mergeColumn);
                workSheet_range.WrapText = true;


                switch (b)
                {
                    case "DARK YELLOW":
                        workSheet_range.Interior.ColorIndex = 42;
                        break;
                    case "YELLOW":
                        //workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                        workSheet_range.Interior.ColorIndex = 27; //Color index 45 means Yellow mix color
                        break;
                    case "GRAY":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                        break;
                    case "GAINSBORO":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                        break;
                    case "Turquoise":
                        workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
                        workSheet_range.Interior.ColorIndex = 8;
                        break;
                    case "AQUA":
                        workSheet_range.Interior.ColorIndex = 42;
                        break;
                    case "PeachPuff":
                        workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
                        break;
                    case "TEAL":
                        workSheet_range.Interior.ColorIndex = 14;
                        break;
                    case "GREEN":
                        workSheet_range.Interior.ColorIndex = 10;
                        break;
                    case "LIGHT GREEN":
                        workSheet_range.Interior.ColorIndex = 35;
                        break;
                    case "TAN":
                        workSheet_range.Interior.ColorIndex = 40;
                        break;
                    case "DARK BLUE":
                        workSheet_range.Interior.ColorIndex = 5;
                        break;
                    case "SKY BLUE":
                        workSheet_range.Interior.ColorIndex = 33;
                        break;
                    default:
                        //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                        break;
                }
                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheet_range.Font.Bold = font;
                workSheet_range.ColumnWidth = size;
                workSheet_range.HorizontalAlignment = Excel.Constants.xlCenter;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region Create Excel File For Show Data Shiftwise

        private void CreateShiftwiseExcelFile(DataTable dtExcel)//(string efolderPath,string eFile, DataTable dtExcel)
        {
            try
            {
                application = new Excel.ApplicationClass();

                workbook = application.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

                // Headers && Sub Headers
                ExcelShiftwiseHeaders(dtExcel);

                
                for (int row = 0; row < dtExcel.Rows.Count; row++)
                {
                    int cntChar = 0;
                    short cntAlphabet = 66;
                    workSheet_range.WrapText = true;
                    worksheet.Cells[row + 3, 1] = dtExcel.Rows[row][0].ToString();
                    workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                    for (int col = 1; col < dtExcel.Columns.Count; col++)
                    {
                        if (cntAlphabet == 91)
                            cntAlphabet = 65;
                        cntChar = col + 65;
                        // Ascii conversion of A to Z for excel column
                        if (cntChar >= 65 && cntChar <= 90)
                        {
                            if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                            {
                                worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                workSheet_range = worksheet.get_Range(Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                workSheet_range.Interior.ColorIndex = 4;
                            }
                            else
                            {
                                worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                workSheet_range = worksheet.get_Range(Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            }
                        }
                        else if (cntChar > 90 && cntChar <= 116)
                        {
                            if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                            {
                                worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                workSheet_range = worksheet.get_Range("A" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "A" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                workSheet_range.Interior.ColorIndex = 4;
                            }
                            else
                            {
                                worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                workSheet_range = worksheet.get_Range("A" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "A" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            }
                        }
                        else if (cntChar > 116 && cntChar <= 142)
                        {
                            if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                            {
                                worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                workSheet_range = worksheet.get_Range("B" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "B" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                workSheet_range.Interior.ColorIndex = 4;
                            }
                            else
                            {
                                worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                workSheet_range = worksheet.get_Range("B" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "B" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            }
                        }

                        if (dtExcel.Columns.Count == 85)
                        {
                            if (cntChar > 142 && cntChar <= 149)
                            {
                                if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                                {
                                    worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                    workSheet_range.Interior.ColorIndex = 4;
                                }
                                else
                                {
                                    worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                }
                            }
                        }
                        if (dtExcel.Columns.Count == 88)
                        {
                            if (cntChar > 142 && cntChar <= 152)
                            {
                                if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                                {
                                    worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                    workSheet_range.Interior.ColorIndex = 4;
                                }
                                else
                                {
                                    worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                }
                            }
                        }
                        if (dtExcel.Columns.Count == 91)
                        {
                            if (cntChar > 142 && cntChar <= 155)
                            {
                                if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                                {
                                    worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                    workSheet_range.Interior.ColorIndex = 4;
                                }
                                else
                                {
                                    worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                }
                            }
                        }
                        if (dtExcel.Columns.Count == 94)
                        {
                            if (cntChar > 142 && cntChar <= 158)
                            {
                                if (Convert.ToString(dtExcel.Rows[row][col]) != "")
                                {
                                    worksheet.Cells[row + 3, col + 1] = dtExcel.Rows[row][col].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                    workSheet_range.Interior.ColorIndex = 4;
                                }
                                else
                                {
                                    worksheet.Cells[row + 3, col + 1] = "";//dtExcel.Rows[row][1].ToString();
                                    workSheet_range = worksheet.get_Range("C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3), "C" + Convert.ToChar(cntAlphabet) + Convert.ToString(row + 3));
                                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                }
                            }
                        }
                        cntAlphabet++;
                        
                    }

                }
                //SAVE WORKBOOK AT EXPORT PATH
                //workbook.SaveAs(eFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                application.Visible = true;
                //application.Workbooks.Close();


                releaseObject(workbook);
                releaseObject(worksheet);
                releaseObject(application);
                //application.Quit();
                //efolderPath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void ExcelShiftwiseHeaders(DataTable dt)
        {
            try
            {
                int cnt = dt.Columns.Count;
                int cntChar = 1;
                int cntAlphabets = 66;

                #region Headers               
                
                for (int j = 1; j < cnt; j++)
                {                    
                    string[] strColumnName = new string[2];
                    strColumnName[0] = dt.Columns[j].Caption.Substring(0, 9);
                    strColumnName[1] = dt.Columns[j].Caption.Substring(9);
                    cntChar = 65;
                    if (cntAlphabets >= 91)
                        cntAlphabets = 65;

                    if (cntChar >= 65 && cntChar < 90)
                    {
                        CreateHeaders(1, j + 1, strColumnName[0], Convert.ToString(Convert.ToChar(cntAlphabets) + "1"), Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    else if (cntChar >= 90 && cntChar < 116)
                    {

                        CreateHeaders(1, j + 1, strColumnName[0], "A" + Convert.ToChar(cntAlphabets) + "1", "A" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    else if (cntChar >= 116 && cntChar < 142)
                    {
                        CreateHeaders(1, j + 1, strColumnName[0], "B" + Convert.ToChar(cntAlphabets) + "1", "B" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    if (cnt == 85)//For 28 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 149)
                            CreateHeaders(1, j+1, strColumnName[0], "C" + Convert.ToChar(cntAlphabets) + "1", "C" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    if (cnt == 88)//For 29 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 152)
                            CreateHeaders(1, j+1, strColumnName[0], "C" + Convert.ToChar(cntAlphabets) + "1", "C" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    if (cnt == 91)//For 30 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 155)
                            CreateHeaders(1, j+1, strColumnName[0], "C" + Convert.ToChar(cntAlphabets) + "1", "C" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    if (cnt == 94)//For 31 Days + Line Name
                    {

                        if (cntChar >= 142 && cntChar < 158)
                            CreateHeaders(1, j+1 , strColumnName[0], "C" + Convert.ToChar(cntAlphabets) + "1", "C" + Convert.ToChar(cntAlphabets) + "1", 3, "", true, 10);
                    }
                    cntAlphabets = cntAlphabets + 3;
                    cntChar = cntChar + 3;
                }


                #endregion

                #region Sub Headers
               
                cntAlphabets = 66;
                CreateHeaders(2, 1, "Line Name", "A2", "A2", 0, "AQUA", true, 15);
                
                for (int i = 1; i < cnt; i++)
                {
                    
                    
                   
                    string[] strColumnName = new string[2];
                    strColumnName[0] = dt.Columns[i].Caption.Substring(0, 9);
                    strColumnName[1] = dt.Columns[i].Caption.Substring(9);
                    cntChar = i + 64;
                    if (cntAlphabets == 91)
                        cntAlphabets = 65;
                    
                    if (cntChar >= 65 && cntChar < 90)
                        CreateHeaders(2, i + 1, strColumnName[1], Convert.ToString(Convert.ToChar(cntAlphabets) + "2"), Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    else if (cntChar >= 90 && cntChar < 116)
                    {                    

                        CreateHeaders(2, i + 1, strColumnName[1], "A" + Convert.ToChar(cntAlphabets) + "2", "A" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    }
                    else if (cntChar >= 116 && cntChar < 142)
                        CreateHeaders(2, i + 1, strColumnName[1], "B" + Convert.ToChar(cntAlphabets) + "2", "B" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    //else if (cntChar > 142 && cntChar <= 168)                        
                    //    CreateHeaders(2, i + 1, strColumnName[1], "C" + Convert.ToChar(cntAlphabets) + "2", "C" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);

                    if (cnt == 85)//For 28 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 149)
                            CreateHeaders(2, i + 1, strColumnName[1], "C" + Convert.ToChar(cntAlphabets) + "2", "C" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    }
                    if (cnt == 88)//For 29 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 152)
                            CreateHeaders(2, i + 1, strColumnName[1], "C" + Convert.ToChar(cntAlphabets) + "2", "C" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    }
                    if (cnt == 91)//For 30 Days + Line Name
                    {
                        if (cntChar >= 142 && cntChar < 155)
                            CreateHeaders(2, i + 1, strColumnName[1], "C" + Convert.ToChar(cntAlphabets) + "2", "C" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    }
                    if (cnt == 94)//For 31 Days + Line Name
                    {

                        if (cntChar >= 142 && cntChar < 158)
                            CreateHeaders(2, i + 1, strColumnName[1], "C" + Convert.ToChar(cntAlphabets) + "2", "C" + Convert.ToChar(cntAlphabets) + "2", 0, "AQUA", true, 10);
                    }
                    cntAlphabets++;


                }
                #endregion

                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        private void DtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (DtpDateFrom.Checked)
            {
                DateTime fromDate = new DateTime(DtpDateFrom.Value.Year, DtpDateFrom.Value.Month, 1);

                LineOEETransaction_obj.startdate = Convert.ToString(fromDate);//DtpDateFrom.Value.ToShortDateString();

                DtpDateTo.Checked = true;
                DateTime toDate = new DateTime(DtpDateFrom.Value.Year, DtpDateFrom.Value.Month, 1).AddMonths(1).AddDays(-1);
                LineOEETransaction_obj.enddate = Convert.ToString(toDate);//DtpDateTo.Value.ToShortDateString();
                DtpDateTo.Value = toDate;
                DtpDateTo.Enabled = false;
            }
        }

	}
}
