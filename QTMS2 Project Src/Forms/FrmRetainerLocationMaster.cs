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

namespace QTMS.Forms
{
    public partial class FrmRetainerLocationMaster : Form
    {
        DataSet dsList = new DataSet();

        public FrmRetainerLocationMaster()
        {
            InitializeComponent();
        }

        private static FrmRetainerLocationMaster FrmRetainerLocationMaster_Obj = null;
        public static FrmRetainerLocationMaster GetInstance()
        {
            if (FrmRetainerLocationMaster_Obj == null)
            {
                FrmRetainerLocationMaster_Obj = new FrmRetainerLocationMaster();
            }
            return FrmRetainerLocationMaster_Obj;
        }

        # region Varibles

        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
        bool Modify = false;

        # endregion

        private void FrmRetainerLocationMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);

                txtLocation.Focus();
                Bind_List();
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
                
                dsList = RetainerLocation_Class_Obj.Select_tblRetainerLocation();
                if (dsList.Tables[0].Rows.Count > 0)
                {
                    LstLocation.DataSource = dsList.Tables[0];
                    LstLocation.DisplayMember = "Location";
                    LstLocation.ValueMember = "LocationID";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtLocation.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLocation.Focus();
                    return;

                }
                if (Modify == false)
                {
                    RetainerLocation_Class_Obj.location = txtLocation.Text.Trim();
                    bool b = RetainerLocation_Class_Obj.Insert_tblRetainerLocation();
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RetainerLocation_Class_Obj.location = txtLocation.Text.Trim();
                    RetainerLocation_Class_Obj.locationid = Convert.ToInt64(LstLocation.SelectedValue.ToString());
                    if (RetainerLocation_Class_Obj.locationid == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = RetainerLocation_Class_Obj.Update_tblRetainerLocation();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                BtnReset_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //txtSearch.Text = Convert.ToString(LstLocation.Text);
                Modify = true;
                DataSet ds = new DataSet();
                RetainerLocation_Class_Obj.locationid = Convert.ToInt64(LstLocation.SelectedValue.ToString());
                txtLocation.Text = LstLocation.Text;
                BtnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_List();
                txtSearch.Text = "";
                txtLocation.Text = "";
                txtLocation.Focus();
                BtnDelete.Enabled = false;
                Modify = false;
                Bind_List();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            LstLocation.Enabled = true;
            Modify = true;
            LstLocation_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RetainerLocation_Class_Obj.locationid = Convert.ToInt64(LstLocation.SelectedValue.ToString());

                if (RetainerLocation_Class_Obj.locationid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = RetainerLocation_Class_Obj.Delete_tblRetainerLocation();
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

        private void txtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtLocation.Text = textInfo.ToTitleCase(txtLocation.Text);	
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "Location like  '" + searchString + "%'";
            LstLocation.DataSource = dsList.Tables[0];

            LstLocation.DisplayMember = "Location";
            LstLocation.ValueMember = "LocationID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstLocation.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    RetainerLocation_Class_Obj.locationid = Convert.ToInt64(LstLocation.SelectedValue.ToString());
                    txtLocation.Text = LstLocation.Text;
                    BtnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    LstLocation.Select();
                    LstLocation.SelectedIndex = LstLocation.SelectedIndex + 1;
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
                    LstLocation.Select();
                    LstLocation.SelectedIndex = LstLocation.SelectedIndex - 1;
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

        private void LstLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstLocation.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    RetainerLocation_Class_Obj.locationid = Convert.ToInt64(LstLocation.SelectedValue.ToString());
                    txtLocation.Text = LstLocation.Text;
                    BtnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }    
    }
}