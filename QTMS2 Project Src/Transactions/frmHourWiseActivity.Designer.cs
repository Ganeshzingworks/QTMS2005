namespace QTMS.Transactions
{
    partial class frmHourWiseActivity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHourWiseActivity));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReset = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip_OEE = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgLineOEEActivity = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEEActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.btnReset.Location = new System.Drawing.Point(6, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(179, 33);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Clear Comment";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(823, 30);
            this.panelTop.TabIndex = 42;
            // 
            // toolStrip_OEE
            // 
            this.toolStrip_OEE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_OEE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip_OEE.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_OEE.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_OEE.Name = "toolStrip_OEE";
            this.toolStrip_OEE.Size = new System.Drawing.Size(823, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(143, 27);
            this.toolStripLabel1.Text = "Activity Details";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Visible = false;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(825, 446);
            this.panelOuter.TabIndex = 5;
            // 
            // panelbottom
            // 
            this.panelbottom.BackColor = System.Drawing.SystemColors.Window;
            this.panelbottom.Controls.Add(this.groupBox3);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(823, 444);
            this.panelbottom.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(185, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 57);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.btnClose.Location = new System.Drawing.Point(191, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(192, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgLineOEEActivity);
            this.groupBox2.Location = new System.Drawing.Point(4, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 333);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activity Details";
            // 
            // dgLineOEEActivity
            // 
            this.dgLineOEEActivity.AllowUserToAddRows = false;
            this.dgLineOEEActivity.AllowUserToDeleteRows = false;
            this.dgLineOEEActivity.AllowUserToResizeColumns = false;
            this.dgLineOEEActivity.AllowUserToResizeRows = false;
            this.dgLineOEEActivity.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLineOEEActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLineOEEActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLineOEEActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLineOEEActivity.Location = new System.Drawing.Point(3, 27);
            this.dgLineOEEActivity.Name = "dgLineOEEActivity";
            this.dgLineOEEActivity.RowHeadersVisible = false;
            this.dgLineOEEActivity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgLineOEEActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgLineOEEActivity.Size = new System.Drawing.Size(809, 303);
            this.dgLineOEEActivity.TabIndex = 44;
            this.dgLineOEEActivity.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLineOEEActivity_CellMouseUp);
            this.dgLineOEEActivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgLineOEEActivity_MouseDown);
            this.dgLineOEEActivity.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLineOEEActivity_CellMouseClick);
            this.dgLineOEEActivity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgLineOEEActivity_MouseMove);
            this.dgLineOEEActivity.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLineOEEActivity_CellMouseDown);
            this.dgLineOEEActivity.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLineOEEActivity_CellMouseMove);
            this.dgLineOEEActivity.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLineOEEActivity_CellClick);
            this.dgLineOEEActivity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLineOEEActivity_CellContentClick);
            // 
            // frmHourWiseActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(825, 446);
            this.Controls.Add(this.panelOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHourWiseActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmHourWiseActivity";
            this.Load += new System.EventHandler(this.frmHourWiseActivity_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelbottom.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEEActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip_OEE;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelbottom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgLineOEEActivity;
    }
}