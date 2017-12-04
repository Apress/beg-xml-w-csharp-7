using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml($"{Application.StartupPath}\\menus.xml");

            foreach (DataRow topmenu in ds.Tables[0].Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(topmenu["text"].ToString());
                menuStrip1.Items.Add(item);
                DataRow[] submenus= topmenu.GetChildRows(ds.Relations[0]);
                foreach (DataRow submenu in submenus)
                {
                    item.DropDownItems.Add(submenu[0].ToString());
                }

            }

        }
    }
}