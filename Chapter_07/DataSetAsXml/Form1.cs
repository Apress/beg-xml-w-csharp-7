using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsApplication37
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please specify XML file name");
                return;
            }
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox1.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }

            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select employeeid,firstname,lastname,homephone,notes from employees", @"data source=.;initial catalog=northwind;integrated security=true");
            da.Fill(ds, "employees");
            if (radioButton1.Checked)
            {
                ds.WriteXml(textBox1.Text, XmlWriteMode.IgnoreSchema);
            }
            if (radioButton2.Checked)
            {
                ds.WriteXml(textBox1.Text, XmlWriteMode.WriteSchema);
            }
            if (radioButton3.Checked)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row.SetModified();
                }
                ds.WriteXml(textBox1.Text, XmlWriteMode.DiffGram);
            }
            if (checkBox1.Checked)
            {
                Process.Start(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}