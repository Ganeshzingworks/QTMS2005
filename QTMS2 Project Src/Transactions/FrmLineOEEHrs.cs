using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Forms
{
    public partial class FrmLineOEEHrs : Form
    {
        public FrmLineOEEHrs()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineOEEHrs_Load(object sender, EventArgs e)
        {
            BindGrid1();
        }

        private void BindGrid1()
        {
            try
            {
                dgLineOEE.Rows.Clear();
                //dgLineOEE.DataSource = null;
                dgLineOEE.Columns.Clear();
                int min = 0, hrs = 0;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;

                hrs = 14;

                //for (int i = 1; i <= 2; i++)
                //{
                //    DataGridViewColumn newCol = new DataGridViewColumn();
                //    DataGridViewCell cell = new DataGridViewTextBoxCell();
                //    newCol.CellTemplate = cell;
                //    dgLineOEE.Columns.Add(newCol);
                //}

                ///Bind data to grid
                DataTable dt = new DataTable();
                int h = hrs;
                int d=8;
                dt = LineOEETransaction_Obj.GetProducedUnitsByHours();
                if (dt.Rows.Count > 0)
                {
                    //if (true)
                    //{
                        dgLineOEE.Columns.Add("ShiftHrs", "ShiftHours");
                        dgLineOEE.Columns.Add("ProducedUnists", "d");
                        //dgLineOEE.Columns.Add("Status", "s");
                        
                        DataGridViewButtonColumn AddButton = new DataGridViewButtonColumn();
                        AddButton.Name = "ADD";
                        AddButton.Text = "Add/Update";
                        AddButton.UseColumnTextForButtonValue = true;
                        if (dgLineOEE.Columns["ADD"] == null)
                        {
                            dgLineOEE.Columns.Insert(2, AddButton);
                        }
                        //dgLineOEE.Columns.Insert(2, AddButton);
                        for (int i = 0; i < d; i++)
                        {
                            string s = "";
                            //dgLineOEE.Rows.Add();
                            //dgLineOEE["ShiftHrs", i].Value = Convert.ToString(h+'-'+(h-1));
                            s = h+"-"+(h+1);
                            if (i<dt.Rows.Count)
	                        {
                        		dgLineOEE.Rows.Add(Convert.ToString(s), (Convert.ToString(dt.Rows[i]["ProducedUnits"]))); 
	                        }
                            else
                            {
                                dgLineOEE.Rows.Add(Convert.ToString(s),"",""); 
                            }
                            h += 1;
                        }
                    

                    
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    dgLineOEE.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                        //    //dgLineOEE.Rows.Add();
                        //    //dgLineOEE["ShiftHrs", i].Value = Convert.ToString(dt.Rows[i]["6-7"]);
                        //    //dgLineOEE["ProducedUnits", i].Value = Convert.ToString(dt.Rows[i]["ProducedUnits"]);

                        //    dgLineOEE.Rows.Add(Convert.ToString(dt.Rows[i]["ProducedUnits"]), Convert.ToString(dt.Rows[i]["Status"]), Convert.ToString(dt.Rows[i]["Status"]));

                        //}
                    //}

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgLineOEE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}