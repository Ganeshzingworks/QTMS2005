using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Text.RegularExpressions;

namespace QTMS.Forms.LineValidation
{

    public partial class FrmMOMMaster : Form
    {
        public FrmMOMMaster()
        {
            InitializeComponent();
          
        } 
        public bool Modify;
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionRejectionMaster_Class LineTransactionRejectionMaster_Class_Obj = new LineTransactionRejectionMaster_Class();

        #region Varibles
        bool modify = false;
        bool click= false ;
        int momid;
        string tmpstring;
        string checkformula = "";
        string checkvessel = "";
        string checkannexTank = "";
        string safetysymbol = "";
        string accessoris = "";
        double pno = 0;
        int NPS;
    
        int result1 = 0;
        Double srno;
        int result = 0;
        string tmp = "";
        string oldmomno;
        bool SaveAs = false;
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        VesselMaster_Class VesselMaster_Class_obj = new VesselMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.MomMaster_Class objMomMaster_Class = new MomMaster_Class();
        SafetySymbol_Class SafetySymbol_Class_obj = new SafetySymbol_Class();



        # endregion

        private static FrmMOMMaster frmFormulaNoMaster_Obj = null;
        public static FrmMOMMaster GetInstance()
        {
            if (frmFormulaNoMaster_Obj == null)
            {
                frmFormulaNoMaster_Obj = new FrmMOMMaster();
            }
            return frmFormulaNoMaster_Obj;
        }

        private void FrmFormulaMaster_Load(object sender, EventArgs e)
        {
            try
            {
              
                Bind_CmbFormulaNo();
                Bind_vessel();
                Bind_Tank();
                Bind_cmbMomno();

               // tabMom.TabPages.Add(MOMPorcess);
                //tabMom.TabPages.Remove(MOMFooter);

                clear();
                //tabMom.SelectedIndex = 1;
                //btnnext.PerformClick();
                //btnnext_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            


        }

        public void Bind_CmbFormulaNo()
        {
        }

        public void Bind_vessel()
        {
            
        }

        public void Bind_Tank()
        {
           
        }

        public void Bind_cmbMomno()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = objMomMaster_Class.SELECT_tblMOMMaster();


            if (ds.Tables[0].Rows.Count > 0)
            {
              
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListFormulano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListFormulano_ItemCheck(object sender, ItemCheckEventArgs e)
        {



        }

      

        private void BtnSave_Click(object sender, EventArgs e)
        {


        }

        public void clear()
        {
         


        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
           
            modify = true;
           
        }

       

        private void cmbMOMNo_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {







        }

        public void Bind_SaftySymbols()
        {
            DataRow dr;
            DataSet ds = new DataSet();


            ds = SafetySymbol_Class_obj.Select_SafetySymbol_symb();

            if (ds.Tables[0].Rows.Count > 0)
            {
            }
        }



        public void Bind_Saftyacc()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = SafetySymbol_Class_obj.Select_SafetySymbol_acc();
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
        }



        public void Bind_scrapper()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Scrapper();
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
        }
        public void Bind_Impeller()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Impeller();
            if (ds.Tables[0].Rows.Count > 0)
            {
            }
        }


        public void Bind_Emulsifer()
        {
            DataRow dr;
            DataSet ds = new DataSet();

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Emulsifier();
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
        }





        public void Bind_Vac()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            //  cmbVaC.Items.Insert(0, "hi");

            ds = objMomMaster_Class.SELECT_tblAgitationRpm_Vac();
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
        }



        private void btnnext_Click(object sender, EventArgs e)
        {
            //Bind_Saftyacc();
            //Bind_SaftySymbols();
            //Bind_Emulsifer();
            //Bind_Impeller();
            //Bind_scrapper();
            //Bind_Vac();
            tabMom.TabPages.Remove(MOMFooter);
            tabMom.TabPages.Add(MOMPorcess);
        

         //   tabMom.TabPages.Add(MOMPorcess);
                    
               

              tabMom.SelectedIndex = tabMom.SelectedIndex + 1;
        

          if (SaveAs == true)

          {
              modify = false;

          
          
          }
            //if (modify == true  )
            //{



                List<MomMaster_Class> fill = new List<MomMaster_Class>();
                DataSet ds = new DataSet();
                if (SaveAs == true)
                {
                    objMomMaster_Class.momno = oldmomno;
                    ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());

                    DataSet ds1 = new DataSet();


                    ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();


                    for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                    {

                        objMomMaster_Class = new MomMaster_Class();
                        objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                        objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                        objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                        objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                        string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                        string HTMLCode = tmpstring;

                        HTMLCode = HTMLCode.Replace("\n", " ");

                        // Remove tab spaces
                        HTMLCode = HTMLCode.Replace("\t", " ");

                        // Remove multiple white spaces from HTML
                        HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                        // Remove HEAD tag
                        HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                            , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Remove any JavaScript
                        HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                          , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Replace special characters like &, <, >, " etc.
                        StringBuilder sbHTML = new StringBuilder(HTMLCode);
                        // Note: There are many more special characters, these are just
                        // most common. You can add new characters in this arrays if needed
                        string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                        string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                        for (int j = 0; j < OldWords.Length; j++)
                        {
                            sbHTML.Replace(OldWords[j], NewWords[j]);
                        }

                        // Check if there are line breaks (<br>) or paragraph (<p>)
                        sbHTML.Replace("<br>", "\n<br>");
                        sbHTML.Replace("<br ", "\n<br ");
                        sbHTML.Replace("<p ", "\n<p ");

                        // Finally, remove all HTML tags and return plain text
                        txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                         sbHTML.ToString(), "<[^>]*>", "");




                        objMomMaster_Class.processDesc = txtprocessdesc.Text;
                        objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                        objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                        objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                        objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                        objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                        objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                        objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                        objMomMaster_Class.IsUpdate = 1;

                        objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                        fill.Add(objMomMaster_Class);

                    }

                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });

                    li = fill;            


                }

                else if (modify == true)
                {
                    ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());

                    DataSet ds1 = new DataSet();


                    ds1 = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();


                    for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
                    {

                        objMomMaster_Class = new MomMaster_Class();
                        objMomMaster_Class.momid = Convert.ToInt32(ds1.Tables[0].Rows[i]["momid"]);
                        objMomMaster_Class.srNo = Convert.ToDouble(ds1.Tables[0].Rows[i]["SrNo"]);

                        objMomMaster_Class.printSequenceNo = Convert.ToInt32(ds1.Tables[0].Rows[i]["PrintSequenceNo"]);

                        objMomMaster_Class.isNoteProSubPro = Convert.ToInt32(ds1.Tables[0].Rows[i]["IsNoteProSubPro"]);

                        string tmpstring = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();

                        string HTMLCode = tmpstring;

                        HTMLCode = HTMLCode.Replace("\n", " ");

                        // Remove tab spaces
                        HTMLCode = HTMLCode.Replace("\t", " ");

                        // Remove multiple white spaces from HTML
                        HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                        // Remove HEAD tag
                        HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                            , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Remove any JavaScript
                        HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                          , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        // Replace special characters like &, <, >, " etc.
                        StringBuilder sbHTML = new StringBuilder(HTMLCode);
                        // Note: There are many more special characters, these are just
                        // most common. You can add new characters in this arrays if needed
                        string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", 
                   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                        string[] NewWords = { " ", "&", "\"", "<", ">", "®", "©", "•", "™" };
                        for (int j = 0; j < OldWords.Length; j++)
                        {
                            sbHTML.Replace(OldWords[j], NewWords[j]);
                        }

                        // Check if there are line breaks (<br>) or paragraph (<p>)
                        sbHTML.Replace("<br>", "\n<br>");
                        sbHTML.Replace("<br ", "\n<br ");
                        sbHTML.Replace("<p ", "\n<p ");

                        // Finally, remove all HTML tags and return plain text
                        txtprocessdesc.Text = System.Text.RegularExpressions.Regex.Replace(
                         sbHTML.ToString(), "<[^>]*>", "");




                        objMomMaster_Class.processDesc = txtprocessdesc.Text;
                        objMomMaster_Class.scrapper = Convert.ToString(ds1.Tables[0].Rows[i]["Scrapper"]);


                        objMomMaster_Class.impeller = Convert.ToString(ds1.Tables[0].Rows[i]["Impeller"]);


                        objMomMaster_Class.emulsifer = Convert.ToString(ds1.Tables[0].Rows[i]["Emulsifer"]);

                        objMomMaster_Class.vac = Convert.ToString(ds1.Tables[0].Rows[i]["Vac"]);

                        objMomMaster_Class.symb = ds1.Tables[0].Rows[i]["Symb"].ToString();

                        objMomMaster_Class.htmlProcessDesc = ds1.Tables[0].Rows[i]["ProcessDesc"].ToString();


                        objMomMaster_Class.accsessories = ds1.Tables[0].Rows[i]["Accsessories"].ToString();

                        objMomMaster_Class.IsUpdate = 1;

                        objMomMaster_Class.detailID = Convert.ToInt32(ds1.Tables[0].Rows[i]["detailID"]);

                        fill.Add(objMomMaster_Class);





                    }



                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.printSequenceNo.CompareTo(p2.printSequenceNo); });
                    fill.Sort(delegate(MomMaster_Class p1, MomMaster_Class p2) { return p1.srNo.CompareTo(p2.srNo); });




                    li = fill;



                }


        }

        private void btntab2next_Click(object sender, EventArgs e)
        {

            tabMom.SelectedIndex = tabMom.SelectedIndex + 1;

        }

        private void btnPrevioustab3_Click(object sender, EventArgs e)
        {
            tabMom.SelectedIndex = tabMom.SelectedIndex - 1;
        }

      

        private void cmbImpeller_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<MomMaster_Class> li = new List<MomMaster_Class>();



        private void btnadd_Click(object sender, EventArgs e)
        {






        }

        
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        private void btnsave_Click_1(object sender, EventArgs e)


        {



        }

        private void btntab2next_Click_1(object sender, EventArgs e)
        {
            tabMom.TabPages.Remove(MOMPorcess);
            tabMom.TabPages.Add(MOMFooter);
            if (SaveAs == true)
            {
                modify = false;
            
            }

            tabMom.SelectedIndex = tabMom.SelectedIndex + 1;

            if (modify == true)
            {
                DataSet ds1 = new DataSet();

                //ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                //momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());


                objMomMaster_Class.momid = momid;



                ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();


            }
            else

                if (SaveAs == true)
                {

                    DataSet ds1 = new DataSet();
                    objMomMaster_Class.momno = oldmomno;

                    ds1 = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                    momid = Convert.ToInt32(ds1.Tables[0].Rows[0]["MOMId"].ToString());


                    objMomMaster_Class.momid = momid;



                    ds1 = objMomMaster_Class.Select_From_tblMOMFooterMaster_By_MOMId();




                }
                      
        }



        private void tabMom_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (tabMom.SelectedIndex == 1 || tabMom.SelectedIndex == 2)
            //{
            //    tabMom.SelectedIndex = 0;

            //    TabPage page = tabMom.TabPages[0];
            //    page.Show();


            //}
        }
       
        private void btnPrevioustab3_Click_1(object sender, EventArgs e)
        {
            tabMom.TabPages.Add(MOMPorcess);
            
            tabMom.TabPages.Remove(MOMFooter);
            tabMom.SelectedTab = MOMPorcess;
            //tabMom.SelectedIndex = tabMom.SelectedIndex - 1;
        }



       
     

        private void btexit_Click(object sender, EventArgs e)
        {
            if (modify == true || SaveAs == true )
            {

                MessageBox.Show("Can't Exit Without Saving Recodrs ");
            
            }
            else 
            {
                if (MessageBox.Show("You Want to Exit  ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    //tabMom.SelectedIndex = 0;
                    //FrmFormulaMaster_Load(sender, e);
                    //clear();

                    clear();

                    tabMom.TabPages.Remove(MOMFooter);
                    Bind_cmbMomno();
               
                    clear();
           
                    
               
                } 
                


              
            }
        }

        private void btcancle_Click(object sender, EventArgs e)
        {
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbScarpper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                List<MomMaster_Class> fill = new List<MomMaster_Class>();
                DataSet ds = new DataSet();
                ds = objMomMaster_Class.Select_From_tblMOMMaster_By_MOMNo();

                momid = Convert.ToInt32(ds.Tables[0].Rows[0]["MOMId"].ToString());
                objMomMaster_Class.momid = momid;   
                if (objMomMaster_Class.momid ==0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //DataSet tblMOMProcessMaster = new DataSet();

                //tblMOMProcessMaster = objMomMaster_Class.Select_From_tblMOMProcessMaster_By_MOMId();

                //int detailedId = Convert.ToInt32(tblMOMProcessMaster.Tables[0].Rows[0]["DetailID"].ToString());
                //objMomMaster_Class.detailID = detailedId;

                //DataSet tblMOMFooterMaster = new DataSet();

                //tblMOMFooterMaster =objMomMaster_Class.Select_From_tblMOMFooterMaster_By_momid();

                //int footerId = Convert.ToInt32(tblMOMFooterMaster.Tables[0].Rows[0]["FooterId"].ToString());
                //objMomMaster_Class.footerId = footerId;



               
                 


                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = objMomMaster_Class.Delete_tblMOMMaster();


                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnreset_Click(sender, e);

                        Bind_cmbMomno();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Cant Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
            Bind_cmbMomno();
            safetysymbol = "";
            accessoris = "";
            modify = false;
            SaveAs = false;


        }

        private void tabMom_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrevioustab2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMOMNo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnDeleteProcess_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbdesc_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {

        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRCA.Text = string.Empty;
            kaireeHTMLEditor1.Clear();
            cbLineDescription.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {

        }
    }
}