using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Kairee;

namespace QTMS
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = textBox1.Text;//@"" + Convert.ToString(ConfigurationManager.AppSettings["ConnectionString1"]);
                MessageBox.Show("Connection string : - " + connectionString);
                string queryString = "Select * from MeasurementValue";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    String ClientId = "";
                    da.Fill(ds);

                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];

                    dataGridView1.DataSource = dt;
                    //dataGridView1.datab
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            ////try
            ////{
            ////    string connectionString = "Data Source=ARYANSVR\\SQL2008;database=QTMS;UID=sa;pwd=Sql2008;";//@"" + Convert.ToString(ConfigurationManager.AppSettings["ConnectionString1"]);
            ////    MessageBox.Show("Connection string : - " + connectionString);
            ////    string queryString = "select TOP 1 FamilyDesc FROM View_BulkTest_NonBPC_Report WHERE FormulaNo = '80000MX15'";
            ////    using (SqlConnection connection = new SqlConnection(connectionString))
            ////    {

            ////        SqlCommand command = new SqlCommand(queryString, connection);
            ////        connection.Open();
            ////        string res = command.ExecuteScalar().ToString();
            ////        //dataGridView1.datab
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message.ToString());
            ////}


            //kaireeHTMLEditor1.Text = "<!DOCTYPE HTML PUBLIC '-\\W3C\\DTD HTML 4.0 Transitional\\EN'><HTML><HEAD><META content='text/html; charset=unicode' http-equiv=Content-Type><META name=GENERATOR content='MSHTML 9.00.8112.16457'></HEAD><BODY></BODY></HTML>";
            kaireeHTMLEditor1.Focus();
        }
    }
}



