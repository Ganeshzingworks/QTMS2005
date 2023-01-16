using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Tools
{
    public class Painter 
    {

        public static void PaintMDI(Control control)
        {
            switch (control.GetType().Name)
            {
                case "Panel":
                    Panel panel = (Panel)control;
                    //panel.BackColor = Color.FromArgb(23,118,174);                    
                    panel.BackColor = Color.FromArgb(81,123,17);  
                    break;

                //case "MenuStrip":
                //    MenuStrip menu = (MenuStrip)control;
                //    //menu.BackColor = Color.FromArgb(149,175,217);
                //    menu.BackColor = Color.FromArgb(33, 82, 118);
                //    menu.ForeColor = Color.White;
                //    menu.Font = new Font("Verdana", 8, FontStyle.Regular);                    
                //    foreach (ToolStripMenuItem menuitem in menu.Items)
                //    {
                //        //menuitem.BackColor = Color.FromArgb(149,175,217);
                //        menuitem.BackColor = Color.FromArgb(33, 82, 118);
                //        menuitem.ForeColor = Color.White;
                //        menuitem.Font = new Font("Verdana", 8, FontStyle.Regular);
                //    }
                //    break;

                case "Button":
                    Button btnMDI = (Button)control;
                    btnMDI.BackColor = Color.FromArgb(247, 247, 247);
                    btnMDI.UseVisualStyleBackColor = true;                       
                    break;
            }

            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    PaintMDI(childControl);
                }
            }
        }

        // Reset all the controls to the user's default Control color. 
        public static void Paint(Control control)
        {
            switch (control.GetType().BaseType.Name)
            {
                case "Form":
                    Form frm = (Form)control;
                    if (frm.IsMdiContainer == false && frm.WindowState != FormWindowState.Maximized)
                    {
                        frm.BackColor = Color.FromArgb(255,255,255);
                        frm.ControlBox = true;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = "";
                    }
                    else if (frm.IsMdiContainer == false && frm.WindowState == FormWindowState.Maximized)
                    {
                        frm.BackColor = Color.FromArgb(255,255,255);
                        frm.ControlBox = true;
                        //frm.FormBorderStyle = FormBorderStyle.None;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = "";
                    }
                    break;
            }

            switch (control.GetType().Name)
            {
                //case "ToolStrip":
                //    ToolStrip tool = (ToolStrip)control;
                //    tool.BackColor = Color.FromArgb(0,102,204);
                //    //tool.BackgroundImage = QTMS.Properties.Resources.button_darkpink;
                //    tool.BackgroundImageLayout = ImageLayout.Stretch;
                //    tool.GripStyle = ToolStripGripStyle.Hidden;

                //    foreach (ToolStripItem toolitem in tool.Items)
                //    {
                //        if (toolitem.GetType().Name == "ToolStripLabel")
                //        {
                //            toolitem.ForeColor = Color.White;
                //            toolitem.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
                //            toolitem.Font = new Font("Calibri", 14, FontStyle.Regular);
                //        }
                //        if (toolitem.GetType().Name == "ToolStripButton")
                //        {
                //            toolitem.BackColor = Color.Transparent;
                //            //toolitem.BackgroundImage = QTMS.Properties.Resources.cancel;
                //            toolitem.ToolTipText = "Close";
                //        }
                //    }
                //    //ToolStripButton toolbtn = new ToolStripButton();
                //    //toolbtn.Text = "&Close";
                //    //toolbtn.BackColor = Color.White;
                //    //toolbtn.Alignment = ToolStripItemAlignment.Right;
                //    //tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {toolbtn});
                //    //toolbtn.Click +=new EventHandler(toolbtn_Click);
                //    break;


                case "Panel":
                    Panel pnl = (Panel)control;
                    pnl.BackColor = Color.Transparent;
                    if (pnl.Name == "panelBottom")
                    {
                        pnl.Dock = DockStyle.None;
                    }
                    break;

                case "GroupBox":
                    GroupBox grp = (GroupBox)control;
                    grp.BackColor = Color.FromArgb(242,246,252);
                    //grp.ForeColor = Color.FromArgb(149,175,217);
                    grp.ForeColor = Color.FromArgb(149, 175, 217);
                    //grp.FlatStyle = FlatStyle.Flat;
                    grp.Font = new Font("Verdana", grp.Font.Size, FontStyle.Regular);
                    //grp.Text = "";                    
                    break;

                case "TabControl":
                    TabControl tab = (TabControl)control;
                    tab.DrawMode = TabDrawMode.OwnerDrawFixed;
                    tab.AllowDrop = true;                    
                    tab.Appearance = TabAppearance.Normal;
                    tab.HotTrack = true;                    
                    tab.DrawItem += new DrawItemEventHandler(tab_DrawItem);
                    foreach (TabPage tabpage in tab.TabPages)
                    {
                        tabpage.BackColor = Color.FromArgb(242,246,252);
                        tabpage.ForeColor = Color.FromArgb(0,0,0);
                        tabpage.BorderStyle = BorderStyle.None;
                        tabpage.UseVisualStyleBackColor = false;
                        tabpage.Font = new Font("verdana", tabpage.Font.Size, FontStyle.Regular);                        
                    }                    
                    break;

                case "Label":
                    Label lbl = (Label)control;
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.FromArgb(0,0,0);
                    lbl.Font = new Font("Verdana", lbl.Font.Size, FontStyle.Regular);
                    break;

                case "Button":
                    Button btn = (Button)control;
                    //btn.BackColor = SystemColors.Control;

                    if (btn.Enabled == true)
                    {
                        //btn.BackgroundImage = QTMS.Properties.Resources.button_darkpink;
                        btn.BackColor = Color.FromArgb(0,102,204);
                        //btn.BackColor = Color.SteelBlue;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        //btn.BackgroundImage = QTMS.Properties.Resources.button_darkpink;
                        btn.BackColor = Color.FromArgb(0,102,204);
                        btn.ForeColor = Color.Gray;
                    }

                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.EnabledChanged += new EventHandler(btn_EnabledChanged);

                    btn.Font = new Font("Verdana", btn.Font.Size, FontStyle.Regular);

                    btn.FlatStyle = FlatStyle.Popup;
                    btn.UseVisualStyleBackColor = false;
                    break;

                case "TextBox":
                    TextBox txt = (TextBox)control;
                    if (txt.Enabled == false || txt.ReadOnly == true)
                    {
                        //txt.BackColor = SystemColors.Control;
                        txt.BackColor = Color.FromArgb(242, 246, 252);  
                    }
                    else
                    {
                        txt.BackColor = SystemColors.Window;                        
                    }
                    txt.ForeColor = Color.FromArgb(0,0,0);
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Verdana", txt.Font.Size, FontStyle.Regular);
                    break;

                case "ComboBox":
                    ComboBox cmb = (ComboBox)control;
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.FromArgb(0,0,0);
                    cmb.Font = new Font("Verdana", cmb.Font.Size, FontStyle.Regular);
                    //cmb.DropDownStyle = ComboBoxStyle.DropDown;
                    //cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                case "ListBox":
                    ListBox lst = (ListBox)control;
                    lst.BackColor = Color.FromArgb(242, 246, 252);
                    lst.ForeColor = Color.FromArgb(0,0,0);
                    lst.BorderStyle = BorderStyle.FixedSingle;
                    lst.Font = new Font("Verdana", lst.Font.Size, FontStyle.Regular);
                    break;

                case "CheckedListBox":
                    CheckedListBox chkLst = (CheckedListBox)control;
                    chkLst.BackColor = Color.White;
                    chkLst.ForeColor = Color.FromArgb(0,0,0);
                    chkLst.BorderStyle = BorderStyle.FixedSingle;
                    chkLst.Font = new Font("Verdana", chkLst.Font.Size, FontStyle.Regular);
                    break;

                case "CheckBox":
                    CheckBox chk = (CheckBox)control;
                    chk.BackColor = Color.Transparent;
                    chk.ForeColor = Color.FromArgb(0,0,0);
                    chk.Font = new Font("Verdana", chk.Font.Size, FontStyle.Regular);
                    break;

                case "RadioButton":
                    RadioButton rdb = (RadioButton)control;
                    rdb.BackColor = Color.Transparent;
                    rdb.ForeColor = Color.FromArgb(0,0,0);
                    rdb.Font = new Font("Verdana", rdb.Font.Size, FontStyle.Regular);
                    break;


                case "DateTimePicker":
                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.BackColor = Color.White;
                    dtp.ForeColor = Color.FromArgb(0,0,0);
                    dtp.Font = new Font("Verdana", dtp.Font.Size, FontStyle.Regular);
                    break;

                case "DataGridView":
                    DataGridView dgv = (DataGridView)control;
                    dgv.BackgroundColor = Color.FromArgb(242, 246, 252);


                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0,102,204);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Transparent;
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0,102,204);

                    foreach (DataGridViewColumn dgvColumn in dgv.Columns)
                    {
                        if (dgvColumn.ReadOnly == true)
                        {
                            dgvColumn.DefaultCellStyle.BackColor = Color.FromArgb(242,246,252);
                            dgvColumn.DefaultCellStyle.ForeColor = Color.FromArgb(0,0,0);
                            dgvColumn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242,246,252);
                            dgvColumn.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0,0,0);
                        }
                        else
                        {
                            dgvColumn.DefaultCellStyle.BackColor = Color.White;
                            dgvColumn.DefaultCellStyle.ForeColor = Color.FromArgb(0,0,0);
                            //dgvColumn.DefaultCellStyle.SelectionBackColor = Color.White;
                            //dgvColumn.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0,0,0);
                        }
                    }                    
                    break;
            }

            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    Paint(childControl);
                }
            }
        }

        private static void btn_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled == true)
            {
                //btn.BackgroundImage = QTMS.Properties.Resources.button_darkpink;
                btn.BackColor = Color.FromArgb(0,102,204);
                btn.ForeColor = Color.White;
            }
            else
            {
                //btn.BackgroundImage = QTMS.Properties.Resources.button_darkpink;
                btn.BackColor = Color.FromArgb(0,102,204);
                btn.ForeColor = Color.Gray;
            }
        }

       
        //private static void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{         
        //    DataGridView dgv = (DataGridView)sender;
        //    if (dgv.Rows[e.RowIndex].ReadOnly == true)
        //    {
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(242, 246, 252);
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 246, 252);
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 0);
        //    }
        //    else
        //    {
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        //        dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        //        //dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
        //        //dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0,0,0);
        //    }
        //}

        //private static void dgv_ColumnDefaultCellStyleChanged(object sender, DataGridViewColumnEventArgs e)
        //{
        //    if (e.Column.ReadOnly == true)
        //    {
        //        e.Column.DefaultCellStyle.BackColor = Color.FromArgb(242, 246, 252);
        //        e.Column.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        //        e.Column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 246, 252);
        //        e.Column.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 0);
        //    }
        //    else
        //    {
        //        e.Column.DefaultCellStyle.BackColor = Color.White;
        //        e.Column.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        //        //e.Column.DefaultCellStyle.SelectionBackColor = Color.White;
        //        //e.Column.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0,0,0);
        //    }
        //}

        private static void tab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            Graphics g = e.Graphics;
            TabPage tp = tab.TabPages[e.Index];
            Brush br;
            StringFormat sf = new StringFormat();
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);
            sf.Alignment = StringAlignment.Center;
            string strTitle = tp.Text;

            //If the current index is the Selected Index, change the color
            if (tab.SelectedIndex == e.Index)
            {
                //this is the background color of the tabpage
                //you could make this a stndard color for the selected page                
                br = new SolidBrush(Color.FromArgb(242, 246, 252));
                //this is the background color of the tab page
                g.FillRectangle(br, e.Bounds);
                //g.FillRectangle(br, e.Bounds.X+4, e.Bounds.Y+4, e.Bounds.Width-4, e.Bounds.Height-4);
                //this is the background color of the tab page
                //you could make this a stndard color for the selected page
                br = new SolidBrush(tp.ForeColor);
                g.DrawString(strTitle, tab.Font, br, r, sf);
            }
            else
            {
                //these are the standard colors for the unselected tab pages
                br = new SolidBrush(Color.FromArgb(255, 255, 255));
                g.FillRectangle(br, e.Bounds);
                br = new SolidBrush(Color.FromArgb(52, 115, 209));
                g.DrawString(strTitle, tab.Font, br, r, sf);
            }
        }

   
    }

}

