using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QTMS.U_Control
{
    public partial class ucLineOEEShiftHrs : UserControl
    {

        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();


        public ucLineOEEShiftHrs()
        {
            InitializeComponent();
        }

        private void ucLineOEEShiftHrs_Load(object sender, EventArgs e)
        {
            //FrmLineOEETransactionComments frmLineOEEActivity = new FrmLineOEETransactionComments();
            //frmLineOEEActivity.ShowDialog();
            //BindGrid3("6-7");

        }

        private void BindGrid3(string str)
        {
            try
            {
                dgLineOEEActivity.Rows.Clear();
                //dgLineOEE.DataSource = null;
                dgLineOEEActivity.Columns.Clear();
                int min = 0, hrs = 0;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;

                //
                Selected_shift = str.ToString();
                Selected_shift = Selected_shift.Replace("-", ":");
                shift_hrs = Selected_shift.Split(':');
                hrs = Convert.ToInt32(shift_hrs[0].ToString());


                for (int i = 0; i <= 13; i++)
                {
                    DataGridViewColumn newCol = new DataGridViewColumn();

                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    newCol.CellTemplate = cell;

                    if (i == 0)
                    {
                        newCol.HeaderText = "Activity Name";

                        newCol.Name = "ActivityName";
                        newCol.Visible = true;
                        newCol.Width = 200;
                        newCol.ReadOnly = true;
                        newCol.Frozen = true;
                    }
                    else if (i == 13)
                    {
                        newCol.HeaderText = "Activity ID";
                        newCol.Name = "LineActivityID";
                        newCol.ReadOnly = true;
                        newCol.Visible = false;
                        newCol.Width = 100;
                    }
                    else
                    {
                        if (min > 55)
                        {
                            min = 0;
                            hrs = hrs + 1;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + min);// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.ReadOnly = true;
                            newCol.Visible = true;
                            newCol.Width = 47;
                            min = 5;
                            newCol.DividerWidth = 5;
                        }
                        else
                        {
                            if (hrs > 23) // If hours are greater than 23 then assign hrs value to 1
                                hrs = 0;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            if (min == 5)
                                newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + (min));// + "" + hrUnit);
                            else
                                newCol.HeaderText = Convert.ToString(hrs + ":" + (min));// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.Visible = true;
                            newCol.ReadOnly = true;
                            newCol.Width = 42;
                            min = min + 5;
                        }

                    }
                    dgLineOEEActivity.Columns.Add(newCol);

                }
                DataTable dt = new DataTable();

                dt = LineOEETransaction_Obj.SelectLineOEEActivityMaster();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgLineOEEActivity.Rows.Add();
                        dgLineOEEActivity["ActivityName", i].Value = Convert.ToString(dt.Rows[i]["ActivityName"]);
                        dgLineOEEActivity["LineActivityID", i].Value = Convert.ToString(dt.Rows[i]["LineActivityID"]);
                    }
                }

                //if (txtSTDMOD.Text.Trim() != "")
                //{
                //    for (int i = 0; i < dgLineOEEActivity.Columns.Count - 2; i++)
                //    {
                //        dgLineOEEActivity[i + 1, 0].Value = 10;

                //    }
                //    for (int i = 0; i < dgLineOEEActivity.Rows.Count - 1; i++)
                //    {
                //        dgLineOEEActivity.Rows[i + 1].ReadOnly = true;
                //    }
                //}


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }


    }
}
