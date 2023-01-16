using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Transactions
{
    public partial class FrmKitSearch : Form
    {
        public FrmKitSearch()
        {
            InitializeComponent();
        }

        public static string SearchText = "";

        private void FrmKitSearch_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FrmKitSearch.SearchText = this.txtSearch.Text.Trim();
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //Enter
            {
                BtnSearch_Click(sender, e);
            }
            else if (e.KeyChar == 27) // Esc
            {
                this.Close();
            }            
        }


    }
}