using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WhiteSpaces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement root = null;
            string path = $"{Application.StartupPath}\\employees.xml";
            if (!checkBox1.Checked)
            {
                root=XElement.Load(path, LoadOptions.None);
                MessageBox.Show(root.ToString());
                root.Save(path, SaveOptions.None);
            }
            else
            {
                root=XElement.Load(path, LoadOptions.PreserveWhitespace);
                MessageBox.Show(root.ToString());
                root.Save(path, SaveOptions.DisableFormatting);
            }
            
            
        }
    }
}
