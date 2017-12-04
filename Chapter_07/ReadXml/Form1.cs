using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication39
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
                MessageBox.Show("Invalid source file name");
                return;
            }
            
            DataSet ds = new DataSet();
            XmlReadMode mode=XmlReadMode.Auto;
            if (radioButton1.Checked)
            {
                mode = XmlReadMode.Auto;
            }
            if (radioButton2.Checked)
            {
                mode = XmlReadMode.DiffGram;
            }
            if (radioButton3.Checked)
            {
                mode = XmlReadMode.Fragment;
            }
            if (radioButton4.Checked)
            {
                mode = XmlReadMode.IgnoreSchema;
            }
            if (radioButton5.Checked)
            {
                mode = XmlReadMode.InferSchema;
            }
            if (radioButton6.Checked)
            {
                mode = XmlReadMode.ReadSchema;
            }
            ds.ReadXml(textBox1.Text, mode);
            MessageBox.Show("XML file read successfully!");
        }
    }
}