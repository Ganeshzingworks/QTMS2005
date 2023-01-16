using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;

namespace QTMS.Reports_Forms
{
    public partial class FrmTankLabelPrint : Form
    {
        public DataTable dt = new DataTable();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        public FrmTankLabelPrint(long ID)
        {
            TankMaster_Class_Obj.id = ID;
            InitializeComponent();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTankLabelPrint_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add("Tank Label Print");
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                Reports.Tank_LabalPrint TankLabalPrint = new QTMS.Reports.Tank_LabalPrint();

                dt = TankMaster_Class_Obj.Select_Tank_LabelPrint();

                TankLabalPrint.SetDataSource(dt);
                ReportViewer.ReportSource = TankLabalPrint;
                ReportViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}