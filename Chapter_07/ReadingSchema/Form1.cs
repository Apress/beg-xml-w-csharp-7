using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication41
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("Invalid XML file name");
                return;
            }

            
            DataSet ds = new DataSet();
            if (radioButton1.Checked)
            {
                ds.ReadXmlSchema(textBox1.Text);
            }
            if (radioButton2.Checked)
            {
                ds.InferXmlSchema(textBox1.Text,null);
            }
            MessageBox.Show(ds.GetXmlSchema());
        }
    }
}