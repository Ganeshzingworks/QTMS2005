using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Threading;
using System.Globalization;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmRMCodeRetainerLabel : System.Windows.Forms.Form
    {
        #region Variables and Enumerators
        RMCodeTestMethodMaster_Class RMCodeTestMethodMaster_Class_obj = new RMCodeTestMethodMaster_Class();
        RMCodeRetainerMaster_Class RMCodeRetainerMaster_Class_Obj = new RMCodeRetainerMaster_Class();
        private static FrmRMCodeRetainerLabel FrmRMCodeRetainerLabel_Obj = null;

        private enum RMRetainerTypes : int
        {
            S = 0,
            A
        }
        #endregion                      
        
        public static FrmRMCodeRetainerLabel GetInstance()
        {
            if (FrmRMCodeRetainerLabel_Obj == null)
            {
                FrmRMCodeRetainerLabel_Obj = new Forms.FrmRMCodeRetainerLabel();
            }
            return FrmRMCodeRetainerLabel_Obj;
        }

        public FrmRMCodeRetainerLabel()
        {
            InitializeComponent();
        }            

        private void FrmRMMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Painter.Paint(this);
                Bind_RMCode();
                Bind_SafetySymbols();
                Bind_Accessories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void Bind_Accessories()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = RMCodeRetainerMaster_Class_Obj.Select_RMAccessoriesSymbol();
                ChkLstAccessories.DataSource = Dt;
                ChkLstAccessories.DisplayMember = "SymName";
                ChkLstAccessories.ValueMember = "SymID";
                //RMCodeRetainerMaster_Class_Obj.type = Enum.GetName(typeof(RMRetainerTypes), RMRetainerTypes.A);
                //Dt = RMCodeRetainerMaster_Class_Obj.Select_RMRetainerMaster_By_Type();
                //ChkLstAccessories.DataSource = Dt;
                //ChkLstAccessories.DisplayMember = "RMRetainerLabel";
                //ChkLstAccessories.ValueMember = "RMRetainerId";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Bind_SafetySymbols()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = RMCodeRetainerMaster_Class_Obj.Select_RMSafetySymbol();
                ChkLstSafetySymbols.DataSource = Dt;
                ChkLstSafetySymbols.DisplayMember = "SymName";
                ChkLstSafetySymbols.ValueMember = "SymID";
                //RMCodeRetainerMaster_Class_Obj.type = Enum.GetName(typeof(RMRetainerTypes), RMRetainerTypes.S);
                //Dt = RMCodeRetainerMaster_Class_Obj.Select_RMRetainerMaster_By_Type();
                //ChkLstSafetySymbols .DataSource = Dt;
                //ChkLstSafetySymbols.DisplayMember = "RMRetainerLabel";
                //ChkLstSafetySymbols.ValueMember = "RMRetainerId";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Bind_RMCode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RMCodeTestMethodMaster_Class_obj.Select_RMCodeMaster();
                dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbRMCode.DataSource = ds.Tables[0];
                    CmbRMCode.DisplayMember = "RMCode";
                    CmbRMCode.ValueMember = "RMCodeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void CmbRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                Reset();
                if (CmbRMCode.SelectedIndex != 0)//For not selected record
                {
                    DataTable Dt = new DataTable();
                    RMCodeRetainerMaster_Class_Obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue);
                    //RMCodeRetainerMaster_Class_Obj.rmCodeId = Convert.ToInt64(CmbRMCode.SelectedValue);

                    //RMCodeRetainerMaster_Class_Obj.type = Enum.GetName(typeof(RMRetainerTypes), RMRetainerTypes.S);
                    Dt = RMCodeRetainerMaster_Class_Obj.Select_RMSafetySymbol_RMCodeID();//For SafetySymbols
                   // Dt = RMCodeRetainerMaster_Class_Obj.Select_RMRetainerDetails_RMCodeId_Type();//For SafetySymbols
                    FillCheckList(ChkLstSafetySymbols, ref Dt);

                    Dt = null;
                    RMCodeRetainerMaster_Class_Obj.type = Enum.GetName(typeof(RMRetainerTypes), RMRetainerTypes.A);
                    Dt = RMCodeRetainerMaster_Class_Obj.Select_RMAccessoriesSymbol_RMCodeID();//For Accessories
                   // Dt = RMCodeRetainerMaster_Class_Obj.Select_RMRetainerDetails_RMCodeId_Type();//For Accessories
                    FillCheckList(ChkLstAccessories, ref Dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillCheckList(CheckedListBox ChkLstBox, ref DataTable Dt)
        {
            try
            {
                for (int i = 0; i < Dt.Rows.Count; i++)//Each value members value from DataBase
                {
                    for (int j = 0; j < ChkLstBox.Items.Count;j++) //Compare DB value with each value member of Check List Box
                    {
                        DataRowView row = (DataRowView)ChkLstBox.Items[j];//row.Row.ItemArray[0] will give items value
                        if (Convert.ToInt64(row.Row.ItemArray[0]) == Convert.ToInt64(Dt.Rows[i]["SymID"]))
                        {
                            ChkLstBox.SetItemChecked(j, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        private Boolean IsValid()
        {
            if (CmbRMCode.SelectedIndex == 0)
            {
                MessageBox.Show("Please select RM code");
                CmbRMCode.Focus();
                return false;
            }

            if (ChkLstSafetySymbols.CheckedItems.Count == 0)
            {
                if (MessageBox.Show("No safety symbols are selected.\n Do you want to save?") == DialogResult.No)
                {
                    ChkLstSafetySymbols.Focus();
                    return false;
                }
            }

            if (ChkLstAccessories.CheckedItems.Count == 0)
            {
                if (MessageBox.Show("No accessories are selected.\n Do you want to save?") == DialogResult.No)
                {
                    ChkLstAccessories.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ClearChkLstBox(CheckedListBox ChkLstBox)
        {
            for (int j = 0; j < ChkLstBox.Items.Count; j++)
            {
                ChkLstBox.SetItemChecked(j, false);
            }
        }

        private void Reset()
        {
            ClearChkLstBox(ChkLstSafetySymbols);
            ClearChkLstBox(ChkLstAccessories);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                CmbRMCode.SelectedIndex = 0;
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (IsValid())
                {
                    RMCodeRetainerMaster_Class_Obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue);
                    RMCodeRetainerMaster_Class_Obj.Delete_RMRetainerSASymbol();
                    RMCodeRetainerMaster_Class_Obj.createdby = FrmMain.LoginID;
                    RMCodeRetainerMaster_Class_Obj.modifiedby = FrmMain.LoginID;
                    foreach (DataRowView row in ChkLstSafetySymbols.CheckedItems)
                    {
                        RMCodeRetainerMaster_Class_Obj.symid = Convert.ToInt32(row.Row.ItemArray[0]);
                        RMCodeRetainerMaster_Class_Obj.Insert_RMRetainerSASymbol();
                    }
                    foreach (DataRowView row in ChkLstAccessories.CheckedItems)
                    {
                        RMCodeRetainerMaster_Class_Obj.symid = Convert.ToInt32(row.Row.ItemArray[0]);
                        RMCodeRetainerMaster_Class_Obj.Insert_RMRetainerSASymbol();
                    }
                    //RMCodeRetainerMaster_Class_Obj.rmCodeId = Convert.ToInt64(CmbRMCode.SelectedValue);
                    //RMCodeRetainerMaster_Class_Obj.Delete_RMRetainerDetails_By_RMCodeId();

                    //foreach (DataRowView row in ChkLstSafetySymbols.CheckedItems)
                    //{
                    //    RMCodeRetainerMaster_Class_Obj.rmRetainerId =  Convert.ToInt64(row.Row.ItemArray[0]);
                    //    RMCodeRetainerMaster_Class_Obj.Insert_RMRetainerDetails();
                    //}

                    //foreach (DataRowView row in ChkLstAccessories.CheckedItems)
                    //{
                    //    RMCodeRetainerMaster_Class_Obj.rmRetainerId = Convert.ToInt64(row.Row.ItemArray[0]);
                    //    RMCodeRetainerMaster_Class_Obj.Insert_RMRetainerDetails();
                    //}
                    
                    MessageBox.Show("Labels saved successfully");
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}