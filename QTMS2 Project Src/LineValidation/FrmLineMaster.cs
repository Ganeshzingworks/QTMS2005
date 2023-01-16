using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineMaster : Form
    {
        DataSet dsList = new DataSet();

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LstTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTestDescription;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnDelete;
        private Panel panelOuter;
        private Panel panelBottom;
        private Panel panelFill;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnExport;
        private CheckBox chkScoopApplicable;
        private Label label2;
        private ComboBox cmbManufacturedBy;
        private Label label3;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLineMaster()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        private static FrmLineMaster frmLineMaster_Obj = null;
        public static FrmLineMaster GetInstance()
        {
            if (frmLineMaster_Obj == null)
            {
                frmLineMaster_Obj = new FrmLineMaster();
            }
            return frmLineMaster_Obj;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);

            frmLineMaster_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblLayoutFileName = new System.Windows.Forms.Label();
            this.txtLayoutDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddLayout = new System.Windows.Forms.Button();
            this.btnUploadLayout = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrainingDescription = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddTraining = new System.Windows.Forms.Button();
            this.lbltrainingfile = new System.Windows.Forms.Label();
            this.dgvTraining = new System.Windows.Forms.DataGridView();
            this.tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.LayoutFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LayoutFilePath1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainingFileName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TrainingFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbManufacturedBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkScoopApplicable = new System.Windows.Forms.CheckBox();
            this.txtTestDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstTest = new System.Windows.Forms.ListBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.openFileDialogTrainingFile = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogLayoutFile = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogTrainingFileForMultiple = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraining)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dgvTraining);
            this.groupBox1.Controls.Add(this.cmbManufacturedBy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkScoopApplicable);
            this.groupBox1.Controls.Add(this.txtTestDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(237, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblLayoutFileName);
            this.groupBox4.Controls.Add(this.txtLayoutDescription);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnAddLayout);
            this.groupBox4.Controls.Add(this.btnUploadLayout);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(18, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(657, 78);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Layout";
            // 
            // lblLayoutFileName
            // 
            this.lblLayoutFileName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayoutFileName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLayoutFileName.Location = new System.Drawing.Point(250, 22);
            this.lblLayoutFileName.Name = "lblLayoutFileName";
            this.lblLayoutFileName.Size = new System.Drawing.Size(138, 23);
            this.lblLayoutFileName.TabIndex = 22;
            // 
            // txtLayoutDescription
            // 
            this.txtLayoutDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLayoutDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLayoutDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayoutDescription.Location = new System.Drawing.Point(164, 50);
            this.txtLayoutDescription.MaxLength = 50;
            this.txtLayoutDescription.Name = "txtLayoutDescription";
            this.txtLayoutDescription.Size = new System.Drawing.Size(280, 23);
            this.txtLayoutDescription.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Layout File (.pdf)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Layout Description";
            // 
            // btnAddLayout
            // 
            this.btnAddLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnAddLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLayout.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddLayout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddLayout.Location = new System.Drawing.Point(459, 47);
            this.btnAddLayout.Name = "btnAddLayout";
            this.btnAddLayout.Size = new System.Drawing.Size(81, 26);
            this.btnAddLayout.TabIndex = 22;
            this.btnAddLayout.Text = "&Add";
            this.btnAddLayout.UseVisualStyleBackColor = false;
            this.btnAddLayout.Click += new System.EventHandler(this.btnAddLayout_Click);
            // 
            // btnUploadLayout
            // 
            this.btnUploadLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnUploadLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadLayout.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnUploadLayout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUploadLayout.Location = new System.Drawing.Point(164, 14);
            this.btnUploadLayout.Name = "btnUploadLayout";
            this.btnUploadLayout.Size = new System.Drawing.Size(81, 26);
            this.btnUploadLayout.TabIndex = 12;
            this.btnUploadLayout.Text = "&Browse";
            this.btnUploadLayout.UseVisualStyleBackColor = false;
            this.btnUploadLayout.Click += new System.EventHandler(this.btnUploadLayout_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtTrainingDescription);
            this.groupBox3.Controls.Add(this.btnUpload);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnAddTraining);
            this.groupBox3.Controls.Add(this.lbltrainingfile);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(657, 78);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Training";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Training File (.pdf/.ppt)";
            // 
            // txtTrainingDescription
            // 
            this.txtTrainingDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTrainingDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrainingDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainingDescription.Location = new System.Drawing.Point(164, 49);
            this.txtTrainingDescription.MaxLength = 50;
            this.txtTrainingDescription.Name = "txtTrainingDescription";
            this.txtTrainingDescription.Size = new System.Drawing.Size(280, 23);
            this.txtTrainingDescription.TabIndex = 21;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpload.Location = new System.Drawing.Point(167, 17);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(80, 26);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "&Browse";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Training Description";
            // 
            // btnAddTraining
            // 
            this.btnAddTraining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnAddTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTraining.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTraining.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddTraining.Location = new System.Drawing.Point(459, 46);
            this.btnAddTraining.Name = "btnAddTraining";
            this.btnAddTraining.Size = new System.Drawing.Size(81, 26);
            this.btnAddTraining.TabIndex = 18;
            this.btnAddTraining.Text = "&Add";
            this.btnAddTraining.UseVisualStyleBackColor = false;
            this.btnAddTraining.Click += new System.EventHandler(this.btnAddTraining_Click);
            // 
            // lbltrainingfile
            // 
            this.lbltrainingfile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrainingfile.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbltrainingfile.Location = new System.Drawing.Point(265, 23);
            this.lbltrainingfile.Name = "lbltrainingfile";
            this.lbltrainingfile.Size = new System.Drawing.Size(138, 23);
            this.lbltrainingfile.TabIndex = 19;
            // 
            // dgvTraining
            // 
            this.dgvTraining.AllowUserToAddRows = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTraining.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTraining.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTraining.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraining.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tid,
            this.FileType,
            this.FileTypeName,
            this.Description,
            this.FileName,
            this.LayoutFileName,
            this.LayoutFilePath1,
            this.TrainingFileName,
            this.TrainingFilePath,
            this.Update,
            this.Delete});
            this.dgvTraining.Location = new System.Drawing.Point(51, 322);
            this.dgvTraining.Name = "dgvTraining";
            this.dgvTraining.Size = new System.Drawing.Size(596, 135);
            this.dgvTraining.TabIndex = 15;
            this.dgvTraining.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraining_CellClick);
            // 
            // tid
            // 
            this.tid.DataPropertyName = "Id";
            this.tid.HeaderText = "id";
            this.tid.Name = "tid";
            this.tid.ReadOnly = true;
            this.tid.Visible = false;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "FileType";
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            this.FileType.Visible = false;
            // 
            // FileTypeName
            // 
            this.FileTypeName.HeaderText = "File Type";
            this.FileTypeName.Name = "FileTypeName";
            this.FileTypeName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 150F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 150F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FileName.Width = 150;
            // 
            // LayoutFileName
            // 
            this.LayoutFileName.HeaderText = "LayoutFileName";
            this.LayoutFileName.Name = "LayoutFileName";
            this.LayoutFileName.Visible = false;
            // 
            // LayoutFilePath1
            // 
            this.LayoutFilePath1.HeaderText = "LayoutFilePath";
            this.LayoutFilePath1.Name = "LayoutFilePath1";
            this.LayoutFilePath1.Visible = false;
            // 
            // TrainingFileName
            // 
            this.TrainingFileName.FillWeight = 200F;
            this.TrainingFileName.HeaderText = "TrainingFileName";
            this.TrainingFileName.Name = "TrainingFileName";
            this.TrainingFileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrainingFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TrainingFileName.Visible = false;
            this.TrainingFileName.Width = 200;
            // 
            // TrainingFilePath
            // 
            this.TrainingFilePath.HeaderText = "TrainingFilePath";
            this.TrainingFilePath.Name = "TrainingFilePath";
            this.TrainingFilePath.Visible = false;
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.Visible = false;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // cmbManufacturedBy
            // 
            this.cmbManufacturedBy.FormattingEnabled = true;
            this.cmbManufacturedBy.Location = new System.Drawing.Point(160, 126);
            this.cmbManufacturedBy.Name = "cmbManufacturedBy";
            this.cmbManufacturedBy.Size = new System.Drawing.Size(279, 21);
            this.cmbManufacturedBy.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Manufactured On";
            // 
            // chkScoopApplicable
            // 
            this.chkScoopApplicable.AutoSize = true;
            this.chkScoopApplicable.Location = new System.Drawing.Point(159, 96);
            this.chkScoopApplicable.Name = "chkScoopApplicable";
            this.chkScoopApplicable.Size = new System.Drawing.Size(15, 14);
            this.chkScoopApplicable.TabIndex = 5;
            this.chkScoopApplicable.UseVisualStyleBackColor = true;
            // 
            // txtTestDescription
            // 
            this.txtTestDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTestDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestDescription.Location = new System.Drawing.Point(159, 58);
            this.txtTestDescription.MaxLength = 50;
            this.txtTestDescription.Name = "txtTestDescription";
            this.txtTestDescription.Size = new System.Drawing.Size(280, 23);
            this.txtTestDescription.TabIndex = 4;
            this.txtTestDescription.Leave += new System.EventHandler(this.txtTestDescription_Leave);
            this.txtTestDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestDescription_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "SCOOP  Applicable";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Line Description";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(320, 491);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(282, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 26);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(115, 29);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(67, 26);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(37, 29);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(61, 26);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(374, 29);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(61, 26);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(202, 29);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(61, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LstTest
            // 
            this.LstTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstTest.ItemHeight = 16;
            this.LstTest.Location = new System.Drawing.Point(16, 58);
            this.LstTest.Name = "LstTest";
            this.LstTest.Size = new System.Drawing.Size(215, 514);
            this.LstTest.TabIndex = 2;
            this.LstTest.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.LstTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstTest_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1009, 619);
            this.panelOuter.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1007, 30);
            this.panelTop.TabIndex = 42;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1007, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 27);
            this.toolStripLabel1.Text = "Line Master";
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
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Location = new System.Drawing.Point(0, 30);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1007, 588);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFill.Controls.Add(this.LstTest);
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1006, 587);
            this.panelFill.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // openFileDialogTrainingFile
            // 
            this.openFileDialogTrainingFile.FileName = "openFileDialog1";
            // 
            // openFileDialogLayoutFile
            // 
            this.openFileDialogLayoutFile.FileName = "openFileDialog1";
            // 
            // openFileDialogTrainingFileForMultiple
            // 
            this.openFileDialogTrainingFileForMultiple.FileName = "openFileDialog1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "TrainingFileName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "TrainingFilePath";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // FrmLineMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1010, 619);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line Master";
            this.Load += new System.EventHandler(this.FrmLineMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraining)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        #region Varibles
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        bool Modify = false;
        private string shairedpath;

        public string _LayoutFilePath;
        public string _TrainingFilePathForMultiple;
        public bool IsLayoutFileBrowse;
        public bool IsTrainingFileBrowse;
        private long id;
        private int rowindex;
        #endregion

        private void FrmLineMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            txtTestDescription.Focus();
            Bind_List();
            Bind_Manufacturer();
            _TrainingFilePathForMultiple = _LayoutFilePath = string.Empty;
            if (cmbManufacturedBy.Items.Count > 0)
                cmbManufacturedBy.SelectedIndex = 0;

            shairedpath = ConfigurationManager.AppSettings["shairedpath"].ToString();
        }

        private void Bind_Manufacturer()
        {
            try
            {
                DataSet ds = LineMaster_Class_Obj.Select_Manufacturer();
                DataRow dr = ds.Tables[0].NewRow();
                dr["ManufacturedById"] = "0";
                dr["ManufacturerName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbManufacturedBy.DataSource = ds.Tables[0];
                cmbManufacturedBy.DisplayMember = "ManufacturerName";
                cmbManufacturedBy.ValueMember = "ManufacturedById";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Bind_List()
        {
            try
            {
                dsList = LineMaster_Class_Obj.Select_LineMaster();
                LstTest.DataSource = dsList.Tables[0];
                LstTest.DisplayMember = "LineDesc";
                LstTest.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (txtTestDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Line Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTestDescription.Focus();
                    return;
                }
                if (Convert.ToInt32(cmbManufacturedBy.SelectedValue) == 0)
                {
                    MessageBox.Show("Please Select Manufactured By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbManufacturedBy.Focus();
                    return;
                }
                if (_LayoutFilePath != string.Empty)
                {
                    if (File.Exists(_LayoutFilePath))
                        LineMaster_Class_Obj.layoutFileName = Path.GetFileName(_LayoutFilePath);
                }
                if (_TrainingFilePathForMultiple != string.Empty)
                {
                    if (File.Exists(_TrainingFilePathForMultiple))
                        LineMaster_Class_Obj.trainingFileName = Path.GetFileName(_TrainingFilePathForMultiple);
                }
                List<LineTraingFile_Class> LineTraingFile_ClassList = new List<BusinessFacade.LineTraingFile_Class>();
                foreach (DataGridViewRow item in dgvTraining.Rows)
                {
                    try
                    {
                        LineTraingFile_Class LineTraingFile_Class = new LineTraingFile_Class();

                        // FileType = 1 for Layout type
                        if (Convert.ToString(item.Cells["FileType"].Value) == "1")
                        { 
                            LineMaster_Class_Obj.layoutFileNameList.Add(Convert.ToString(item.Cells["LayoutFileName"].Value));
                            LineMaster_Class_Obj.layoutFilePathList.Add(Convert.ToString(item.Cells["LayoutFilePath1"].Value));
                            LineMaster_Class_Obj.layoutFileDescription.Add(Convert.ToString(item.Cells["Description"].Value));

                            LineTraingFile_Class.LayoutFileName = Convert.ToString(item.Cells["LayoutFileName"].Value);
                            LineTraingFile_Class.LayoutFilePath = Convert.ToString(item.Cells["LayoutFilePath1"].Value);
                        }
                        // FileType = 2 for Training type
                        else if (Convert.ToString(item.Cells["FileType"].Value) == "2")
                        {
                            LineMaster_Class_Obj.trainingFileNameList.Add(Convert.ToString(item.Cells["TrainingFileName"].Value));
                            LineMaster_Class_Obj.trainingFilePathList.Add(Convert.ToString(item.Cells["TrainingFilePath"].Value));
                            LineMaster_Class_Obj.trainingFileDescription.Add(Convert.ToString(item.Cells["Description"].Value));

                            LineTraingFile_Class.TrainingFileName = Convert.ToString(item.Cells["TrainingFileName"].Value);
                            LineTraingFile_Class.TrainingFilePath = Convert.ToString(item.Cells["TrainingFilePath"].Value);
                        }
                        LineMaster_Class_Obj.trainingFileIdList.Add(Convert.ToString(item.Cells["tid"].Value));
                        LineTraingFile_Class.FileType = Convert.ToInt32(item.Cells["FileType"].Value);
                        LineTraingFile_Class.Description = Convert.ToString(item.Cells["Description"].Value);
                       
                        LineTraingFile_Class.Id = 0; /*Convert.ToInt64(item.Cells["tid"].Value);*/
                        LineTraingFile_ClassList.Add(LineTraingFile_Class);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Modify == false)
                {
                    LineMaster_Class_Obj.linename = txtTestDescription.Text.Trim();
                    LineMaster_Class_Obj.scoopApplicable = chkScoopApplicable.Checked ? true : false;
                    LineMaster_Class_Obj.ManufacturedById = Convert.ToInt32(cmbManufacturedBy.SelectedValue);
                    LineMaster_Class_Obj.loginuser = FrmMain.LoginID;
                    LineMaster_Class_Obj.layoutFileName = System.IO.Path.GetFileName(_LayoutFilePath);
                    LineMaster_Class_Obj.layoutFilePath = _LayoutFilePath.Replace("\\\\", "\\");
                    LineMaster_Class_Obj.trainingFileName = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                    LineMaster_Class_Obj.trainingFilePath = _TrainingFilePathForMultiple.Replace("\\\\", "\\");

                    bool b = LineMaster_Class_Obj.Insert_LineMaster();
                    if (b == true)
                    {
                        foreach (LineTraingFile_Class item in LineTraingFile_ClassList)
                        {
                            b = LineMaster_Class_Obj.Insert_LineTrainingFileMaster(item);
                        }

                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LineMaster_Class_Obj.linename = txtTestDescription.Text.Trim();
                    LineMaster_Class_Obj.lno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    LineMaster_Class_Obj.scoopApplicable = chkScoopApplicable.Checked ? true : false;
                    LineMaster_Class_Obj.loginuser = FrmMain.LoginID;
                    LineMaster_Class_Obj.ManufacturedById = Convert.ToInt32(cmbManufacturedBy.SelectedValue);
                    LineMaster_Class_Obj.layoutFileName = System.IO.Path.GetFileName(_LayoutFilePath);
                    LineMaster_Class_Obj.layoutFilePath = _LayoutFilePath.Replace("\\\\", "\\");
                    LineMaster_Class_Obj.trainingFileName = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                    LineMaster_Class_Obj.trainingFilePath = _TrainingFilePathForMultiple.Replace("\\\\", "\\");
                    if (LineMaster_Class_Obj.lno == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Update Line Master
                    bool b = LineMaster_Class_Obj.Update_LineMaster();


                    b = LineMaster_Class_Obj.Delete_LineTraningFileMaster(LineMaster_Class_Obj.lno);
                    foreach (LineTraingFile_Class item in LineTraingFile_ClassList)
                    {
                        if (item.Id == 0)
                            b = LineMaster_Class_Obj.Insert_LineTraningFileMaster(LineMaster_Class_Obj.lno, item.TrainingFileName, item.TrainingFilePath,item.FileType,item.LayoutFileName,item.LayoutFilePath,item.Description);
                        //else
                        //    b = LineMaster_Class_Obj.Update_LineTraningFileMaster(item.Id,LineMaster_Class_Obj.lno, item.TrainingFileName, item.TrainingFilePath);
                    }
                    if (b == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                BtnReset_Click(sender, e);
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LstTest_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                Modify = true;
                //DataSet ds=new DataSet();
                LineMaster_Class_Obj.lno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                dgvTraining.DataSource = null; dgvTraining.Refresh();
                dgvTraining.Rows.Clear();
                _TrainingFilePathForMultiple = _LayoutFilePath = lbltrainingfile.Text = lblLayoutFileName.Text = txtLayoutDescription.Text = txtTrainingDescription.Text = "";
                BindLineTrainingGrid(LineMaster_Class_Obj.lno);
                txtTestDescription.Text = LstTest.Text;
                DataRow[] dr = dsList.Tables[0].Select("lno=" + Convert.ToInt64(LstTest.SelectedValue.ToString()) + "");

                if (dr[0]["ScoopApplicable"].ToString() != "")
                    chkScoopApplicable.Checked = Convert.ToBoolean(dr[0]["ScoopApplicable"].ToString());
                else
                    chkScoopApplicable.Checked = false;

                if (!string.IsNullOrEmpty(Convert.ToString(dr[0]["LineDesc"])))
                {
                    txtTestDescription.Text = Convert.ToString(dr[0]["LineDesc"]);
                }
                if (dr[0]["ManufacturedById"] != DBNull.Value)
                {
                    if (Convert.ToInt32(dr[0]["ManufacturedById"]) == 1)
                    {
                        cmbManufacturedBy.SelectedIndex = 1;
                    }
                    else if (Convert.ToInt32(dr[0]["ManufacturedById"]) == 2)
                    {
                        cmbManufacturedBy.SelectedIndex = 2;
                    }
                    else if (Convert.ToInt32(dr[0]["ManufacturedById"]) != 2 && (Convert.ToInt32(dr[0]["ManufacturedById"]) != 1))
                    {
                        cmbManufacturedBy.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbManufacturedBy.SelectedIndex = 0;
                }
                //if (!string.IsNullOrEmpty(Convert.ToString(dr[0]["TraningFilePath"])))
                //{
                //    btnViewTrainingFile.Visible = true;
                //    _TrainingFilePathForMultiple = Convert.ToString(dr[0]["TraningFilePath"]);
                //}
                //else
                //{
                //    btnViewTrainingFile.Visible = false;
                //}
                //if (!string.IsNullOrEmpty(Convert.ToString(dr[0]["LayoutFilePath"])))
                //{
                //    btnViewLayoutFile.Visible = true;
                //    _LayoutFilePath = Convert.ToString(dr[0]["LayoutFilePath"]);
                //}
                //else
                //{
                //    btnViewLayoutFile.Visible = false;
                //}


                BtnDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BindLineTrainingGrid(long lineid)
        {
            DataSet ds = LineMaster_Class_Obj.Select_LayoutLineTrainingFiles(lineid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvTraining.DataSource = null;
                    dgvTraining.Rows.Clear();
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvTraining);  //

                        dr1.Cells[0].Value = Convert.ToString(item["Id"]);
                        dr1.Cells[1].Value = Convert.ToString(item["FileType"]);
                        if (Convert.ToString(item["FileType"]) == "1")
                        {
                            dr1.Cells[2].Value = "Layout";
                            dr1.Cells[4].Value = Convert.ToString(item["LayoutFileName"]);
                            dr1.Cells[5].Value = Convert.ToString(item["LayoutFileName"]);
                            dr1.Cells[6].Value = Convert.ToString(item["LayoutFilePath"]).Replace("\\\\", "\\");
                        }
                        else
                        {
                            dr1.Cells[2].Value = "Training";
                            dr1.Cells[4].Value = Convert.ToString(item["TrainingFileName"]);
                            dr1.Cells[7].Value = Convert.ToString(item["TrainingFileName"]);
                            dr1.Cells[8].Value = Convert.ToString(item["TrainingFilePath"]).Replace("\\\\", "\\");
                        }
                        dr1.Cells[3].Value = Convert.ToString(item["Description"]);
                        dr1.Cells[9].Value = "Update";
                        dr1.Cells[10].Value = "Delete";
                        dgvTraining.Rows.Add(dr1);
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

        private void BtnReset_Click(object sender, System.EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtTestDescription.Text = "";
            _LayoutFilePath = _TrainingFilePathForMultiple = string.Empty;
            txtTestDescription.Focus();
            BtnDelete.Enabled = false;
            Modify = false;
            chkScoopApplicable.Checked = false;
            Bind_List();
            cmbManufacturedBy.SelectedIndex = 0;
            dgvTraining.DataSource = null; dgvTraining.Refresh();
            dgvTraining.Rows.Clear();
            _TrainingFilePathForMultiple = _LayoutFilePath = lbltrainingfile.Text = lblLayoutFileName.Text = txtLayoutDescription.Text = txtTrainingDescription.Text = "";
            btnAddTraining.Text = "&Add";
        }

        private void BtnModify_Click(object sender, System.EventArgs e)
        {
            LstTest.Enabled = true;
            Modify = true;
            LstTest_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                LineMaster_Class_Obj.lno = Convert.ToInt64(LstTest.SelectedValue.ToString());

                if (LineMaster_Class_Obj.lno > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = LineMaster_Class_Obj.Delete_LineMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTestDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }

            // Only 0-9 and a-z and A-Z allowed
            //if (e.KeyChar != Convert.ToChar(8))
            //{
            //    if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //    {

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txtTestDescription_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            txtTestDescription.Text = textInfo.ToTitleCase(txtTestDescription.Text);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "LineDesc like  '" + searchString + "%'";
            LstTest.DataSource = dsList.Tables[0];

            LstTest.DisplayMember = "LineDesc";
            LstTest.ValueMember = "LNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(LstTest.Text);
                    Modify = true;
                    //DataSet ds=new DataSet();
                    LineMaster_Class_Obj.lno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    txtTestDescription.Text = LstTest.Text;
                    BtnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex + 1;
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
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex - 1;
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

        private void LstTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(LstTest.Text);
                    Modify = true;
                    //DataSet ds=new DataSet();
                    LineMaster_Class_Obj.lno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    txtTestDescription.Text = LstTest.Text;
                    BtnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                LineMaster_Class objLineMaster_Class = new LineMaster_Class();
                DataSet ds = new DataSet();
                ds = objLineMaster_Class.Select_All_Record_tblLineMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseTraining_Click(object sender, EventArgs e)
        {
            try
            {
                //TrainingFilePath = string.Empty;
                //IsTrainingFileBrowse = false;
                DialogResult result = openFileDialogTrainingFile.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _TrainingFilePathForMultiple = string.Empty;
                    IsTrainingFileBrowse = false;
                    if (!(System.IO.Path.GetExtension(openFileDialogTrainingFile.FileName) == ".pdf" || System.IO.Path.GetExtension(openFileDialogTrainingFile.FileName) == ".ppt"))
                    {
                        MessageBox.Show("Please select valid pdf or ppt file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        IsTrainingFileBrowse = true;
                        //if (!System.IO.Directory.Exists(shairedpath))
                        //    System.IO.Directory.CreateDirectory(shairedpath);
                        //if (!System.IO.Directory.Exists(shairedpath + "\\Training\\"))
                        //    System.IO.Directory.CreateDirectory(shairedpath + "\\Training\\");
                        //File.Copy(openFileDialogTrainingFile.FileName, shairedpath + "\\Training\\" + System.IO.Path.GetFileName(openFileDialogTrainingFile.FileName));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnBrowseLayout_Click(object sender, EventArgs e)
        {
            try
            {
                //LayoutFilePath = string.Empty;
                //IsLayoutFileBrowse = false;
                DialogResult result = openFileDialogLayoutFile.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _LayoutFilePath = string.Empty;
                    IsLayoutFileBrowse = false;
                    //if (!(System.IO.Path.GetExtension(openFileDialogLayoutFile.FileName) == ".jpg" || System.IO.Path.GetExtension(openFileDialogLayoutFile.FileName) == ".jpeg" || System.IO.Path.GetExtension(openFileDialogLayoutFile.FileName) == ".png"))
                    //{
                    if (!(System.IO.Path.GetExtension(openFileDialogLayoutFile.FileName) == ".pdf"))
                    {
                        //MessageBox.Show("Please select valid jpg, jpeg, png file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Please select valid pdf file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        IsLayoutFileBrowse = true;
                        if (!System.IO.Directory.Exists(shairedpath))
                            System.IO.Directory.CreateDirectory(shairedpath);
                        if (!System.IO.Directory.Exists(shairedpath + "\\Layout\\"))
                            System.IO.Directory.CreateDirectory(shairedpath + "\\Layout\\");
                        File.Copy(openFileDialogLayoutFile.FileName, shairedpath + "\\Layout\\" + System.IO.Path.GetFileName(openFileDialogLayoutFile.FileName), true);
                        _LayoutFilePath = shairedpath + "\\Layout\\" + Path.GetFileName(openFileDialogLayoutFile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnUploadTraining_Click(object sender, EventArgs e)
        {
            _TrainingFilePathForMultiple = string.Empty;
            if (IsTrainingFileBrowse)
            {
                if (!System.IO.Directory.Exists(shairedpath))
                    System.IO.Directory.CreateDirectory(shairedpath);
                if (!System.IO.Directory.Exists(shairedpath + "\\Training\\"))
                    System.IO.Directory.CreateDirectory(shairedpath + "\\Training\\");
                File.Copy(openFileDialogTrainingFile.FileName, shairedpath + "\\Training\\" + System.IO.Path.GetFileName(openFileDialogTrainingFile.FileName), true);
                _TrainingFilePathForMultiple = shairedpath + "\\Training\\" + System.IO.Path.GetFileName(openFileDialogTrainingFile.FileName);
                MessageBox.Show("Training file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btnViewTrainingFile.Visible = true;
            }
            else
            {
                //btnViewTrainingFile.Visible = false;
                MessageBox.Show("Please browse training file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnUploadLayout_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialogLayoutFile.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _LayoutFilePath = string.Empty;
                    if (!(System.IO.Path.GetExtension(openFileDialogLayoutFile.FileName) == ".pdf"))
                    {
                        //MessageBox.Show("Please select valid jpg, jpeg, png file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Please select valid pdf file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(shairedpath))
                            System.IO.Directory.CreateDirectory(shairedpath);
                        if (!System.IO.Directory.Exists(shairedpath + "\\Layout\\"))
                            System.IO.Directory.CreateDirectory(shairedpath + "\\Layout\\");
                        lblLayoutFileName.Text = System.IO.Path.GetFileName(openFileDialogLayoutFile.FileName);
                        File.Copy(openFileDialogLayoutFile.FileName, shairedpath + "\\Layout\\" + System.IO.Path.GetFileName(openFileDialogLayoutFile.FileName), true);
                        _LayoutFilePath = shairedpath + "\\Layout\\" + System.IO.Path.GetFileName(openFileDialogLayoutFile.FileName);
                        MessageBox.Show("Layout file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnViewLayout_Click(object sender, EventArgs e)
        {
            string FilePath, FileName = string.Empty;
            try
            {
                FilePath = _LayoutFilePath;
                if (File.Exists(@"" + _LayoutFilePath.Replace("\\", "\\\\")))
                    FileName = Path.GetFileName(_LayoutFilePath);


                if (File.Exists(@"" + _LayoutFilePath.Replace("\\", "\\\\")))
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

        private void btnViewTrainingFile_Click(object sender, EventArgs e)
        {
            string FilePath, FileName = string.Empty;
            try
            {
                FilePath = _TrainingFilePathForMultiple;
                if (File.Exists(@"" + _TrainingFilePathForMultiple.Replace("\\", "\\\\")))
                    FileName = Path.GetFileName(_TrainingFilePathForMultiple);


                if (File.Exists(@"" + _TrainingFilePathForMultiple.Replace("\\", "\\\\")))
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

        private void btnViewLayoutFile_Click(object sender, EventArgs e)
        {
            string FilePath, FileName = string.Empty;
            try
            {
                FilePath = _LayoutFilePath;
                if (File.Exists(@"" + _LayoutFilePath.Replace("\\", "\\\\")))
                    FileName = Path.GetFileName(_LayoutFilePath);


                if (File.Exists(@"" + _LayoutFilePath.Replace("\\", "\\\\")))
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //TrainingFilePath = string.Empty;
                //IsTrainingFileBrowse = false;
                DialogResult result = openFileDialogTrainingFileForMultiple.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _TrainingFilePathForMultiple = string.Empty;
                    if (!(System.IO.Path.GetExtension(openFileDialogTrainingFileForMultiple.FileName) == ".pdf" || System.IO.Path.GetExtension(openFileDialogTrainingFileForMultiple.FileName) == ".ppt"))
                    {
                        MessageBox.Show("Please select valid pdf or ppt file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbltrainingfile.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(shairedpath))
                            System.IO.Directory.CreateDirectory(shairedpath);
                        if (!System.IO.Directory.Exists(shairedpath + "\\Training\\"))
                            System.IO.Directory.CreateDirectory(shairedpath + "\\Training\\");
                        lbltrainingfile.Text = System.IO.Path.GetFileName(openFileDialogTrainingFileForMultiple.FileName);
                        File.Copy(openFileDialogTrainingFileForMultiple.FileName, shairedpath + "\\Training\\" + System.IO.Path.GetFileName(openFileDialogTrainingFileForMultiple.FileName), true);
                        _TrainingFilePathForMultiple = shairedpath + "\\Training\\" + System.IO.Path.GetFileName(openFileDialogTrainingFileForMultiple.FileName);
                        MessageBox.Show("Training file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddTraining_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TrainingFilePathForMultiple != string.Empty)
                {
                    if (!string.IsNullOrEmpty(txtTrainingDescription.Text.Trim()))
                    {
                        if (btnAddTraining.Text.Contains("Update"))
                        {
                            DataGridViewRow item = dgvTraining.Rows[rowindex];
                            if (item != null)
                            {
                                item.Cells[3].Value = txtTrainingDescription.Text.Trim();
                                item.Cells[4].Value = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                                item.Cells[7].Value = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                                item.Cells[8].Value = _TrainingFilePathForMultiple.Replace("\\\\", "\\");
                            }
                            MessageBox.Show("Training file successfully updated ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataGridViewRow dr1 = new DataGridViewRow();
                            dr1.CreateCells(dgvTraining);  //

                            dr1.Cells[0].Value = "0";
                            dr1.Cells[1].Value = "2";
                            dr1.Cells[2].Value = "Training";
                            dr1.Cells[3].Value = txtTrainingDescription.Text.Trim();
                            dr1.Cells[4].Value = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                            dr1.Cells[7].Value = System.IO.Path.GetFileName(_TrainingFilePathForMultiple);
                            dr1.Cells[8].Value = _TrainingFilePathForMultiple.Replace("\\\\", "\\");
                            dr1.Cells[5].Value = dr1.Cells[6].Value = "";
                            dr1.Cells[9].Value = "Update";
                            dr1.Cells[10].Value = "Delete";
                            dgvTraining.Rows.Add(dr1);
                            MessageBox.Show("Training file successfully added ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _TrainingFilePathForMultiple = lbltrainingfile.Text = txtTrainingDescription.Text = "";
                        btnAddTraining.Text = "&Add";
                    }
                    else
                    {
                        txtTrainingDescription.Focus();
                        MessageBox.Show("Please enter training description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please browse training file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvTraining_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //e.ColumnIndex == 4 for file type view
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    string FilePath = string.Empty, FileName = string.Empty;
                    try
                    {
                        if (Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["FileType"].Value) == "1")
                        {
                            FilePath = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["LayoutFilePath1"].Value);
                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                                FileName = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["LayoutFileName"].Value);
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
                // If any cell is clicked on update
                if (e.ColumnIndex == 9 && e.RowIndex >= 0)
                {
                    id = Convert.ToInt64(dgvTraining.Rows[e.RowIndex].Cells["tid"].Value.ToString());
                    rowindex = e.RowIndex;
                    _TrainingFilePathForMultiple = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["TrainingFilePath"].Value);
                    lbltrainingfile.Text = Convert.ToString(dgvTraining.Rows[e.RowIndex].Cells["TrainingFileName"].Value);
                    btnAddTraining.Text = "&Update";
                }
                // If any cell is clicked on delete
                if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    //long id = Convert.ToInt64(dgvTraining.Rows[e.RowIndex].Cells["tid"].Value.ToString());
                    dgvTraining.Rows.RemoveAt(e.RowIndex);
                    dgvTraining.Refresh(); // if needed
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddLayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LayoutFilePath != string.Empty)
                {
                    if (!string.IsNullOrEmpty(txtLayoutDescription.Text.Trim()))
                    {
                        if (btnAddTraining.Text.Contains("Update"))
                        {
                            DataGridViewRow item = dgvTraining.Rows[rowindex];
                            if (item != null)
                            {
                                item.Cells[3].Value = txtLayoutDescription.Text.Trim();
                                item.Cells[4].Value = System.IO.Path.GetFileName(_LayoutFilePath);
                                item.Cells[5].Value = System.IO.Path.GetFileName(_LayoutFilePath);
                                item.Cells[6].Value = _LayoutFilePath.Replace("\\\\", "\\");
                            }
                            MessageBox.Show("Training file successfully updated ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataGridViewRow dr1 = new DataGridViewRow();
                            dr1.CreateCells(dgvTraining);  //
                            dr1.Cells[0].Value = "0";
                            dr1.Cells[1].Value = "1";
                            dr1.Cells[2].Value = "Layout";
                            dr1.Cells[3].Value = txtLayoutDescription.Text.Trim();
                            dr1.Cells[4].Value = System.IO.Path.GetFileName(_LayoutFilePath);
                            dr1.Cells[5].Value = System.IO.Path.GetFileName(_LayoutFilePath);
                            dr1.Cells[6].Value = _LayoutFilePath.Replace("\\\\", "\\");
                            dr1.Cells[7].Value = dr1.Cells[8].Value = "";
                            dr1.Cells[9].Value = "Update";
                            dr1.Cells[10].Value = "Delete";
                            dgvTraining.Rows.Add(dr1);
                            MessageBox.Show("Layout file successfully added ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _LayoutFilePath = lblLayoutFileName.Text = txtLayoutDescription.Text = "";
                        btnAddTraining.Text = "&Add";
                    }
                    else
                    {
                        txtLayoutDescription.Focus();
                        MessageBox.Show("Please enter layout description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please browse layout file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
