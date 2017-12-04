using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlXml;
using System.IO;

namespace WindowsApplication56
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
                MessageBox.Show("Please enter SELECT query");
                return;
            }

            try
            {
                string strConn = @"Provider=SQLOLEDB;server=.;database=northwind;integrated security=SSPI";

                SqlXmlCommand cmd = new SqlXmlCommand(strConn);
                cmd.CommandText = textBox1.Text;
                Stream stream = cmd.ExecuteStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = File.CreateText($"{Application.StartupPath}\\sqlxmlresults.xml");
                writer.Write(reader.ReadToEnd());
                writer.Close();
                webBrowser1.Navigate($"{Application.StartupPath}\\sqlxmlresults.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}