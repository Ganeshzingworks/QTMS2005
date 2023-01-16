using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS
{
    public partial class FrmBarcodeTest : Form
    {
        public FrmBarcodeTest()
        {
            InitializeComponent();
        }

      

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                string strCurrentString = textBox1.Text.Trim().ToString();
                if (strCurrentString != "")
                {
                    //Do something with the barcode entered 
                    textBox2.Text = "";
                }
                textBox2.Focus();
            } 
        }
    }
}