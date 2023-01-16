namespace QTMS.U_Control
{
    partial class UC_SamplingGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgSamplingPoint = new System.Windows.Forms.DataGridView();
            this.HSamplingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDefectCount = new System.Windows.Forms.DataGridView();
            this.DefectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSamplingPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefectCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSamplingPoint
            // 
            this.dgSamplingPoint.AllowUserToAddRows = false;
            this.dgSamplingPoint.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.dgSamplingPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSamplingPoint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSamplingPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSamplingPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HSamplingPoint,
            this.ExpectedTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSamplingPoint.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgSamplingPoint.Location = new System.Drawing.Point(6, 3);
            this.dgSamplingPoint.Name = "dgSamplingPoint";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSamplingPoint.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgSamplingPoint.RowHeadersVisible = false;
            this.dgSamplingPoint.Size = new System.Drawing.Size(135, 392);
            this.dgSamplingPoint.TabIndex = 0;
            this.dgSamplingPoint.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSamplingPoint_CellMouseDoubleClick);
            this.dgSamplingPoint.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSamplingPoint_CellContentClick);
            // 
            // HSamplingPoint
            // 
            this.HSamplingPoint.HeaderText = "";
            this.HSamplingPoint.Name = "HSamplingPoint";
            this.HSamplingPoint.ReadOnly = true;
            this.HSamplingPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HSamplingPoint.Width = 120;
            // 
            // ExpectedTime
            // 
            this.ExpectedTime.HeaderText = "ExpectedTime";
            this.ExpectedTime.Name = "ExpectedTime";
            this.ExpectedTime.Visible = false;
            // 
            // dgDefectCount
            // 
            this.dgDefectCount.AllowUserToAddRows = false;
            this.dgDefectCount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.dgDefectCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefectCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDefectCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDefectCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DefectType,
            this.Count});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDefectCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgDefectCount.Location = new System.Drawing.Point(6, 400);
            this.dgDefectCount.Name = "dgDefectCount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefectCount.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgDefectCount.RowHeadersVisible = false;
            this.dgDefectCount.Size = new System.Drawing.Size(135, 130);
            this.dgDefectCount.TabIndex = 1;
            // 
            // DefectType
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.DefectType.DefaultCellStyle = dataGridViewCellStyle5;
            this.DefectType.HeaderText = "Defect";
            this.DefectType.Name = "DefectType";
            this.DefectType.ReadOnly = true;
            this.DefectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DefectType.Width = 80;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Count.Width = 50;
            // 
            // UC_SamplingGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgDefectCount);
            this.Controls.Add(this.dgSamplingPoint);
            this.Name = "UC_SamplingGrid";
            this.Size = new System.Drawing.Size(147, 534);
            this.Load += new System.EventHandler(this.UC_SamplingGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSamplingPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefectCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgSamplingPoint;
        public System.Windows.Forms.DataGridView dgDefectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSamplingPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}
