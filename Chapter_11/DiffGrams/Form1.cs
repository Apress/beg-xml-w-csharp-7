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

        
        string strConn = @"Provider=SQLOLEDB;server=.;database=northwind;integrated security=SSPI";
        DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlXmlCommand cmd = new SqlXmlCommand(strConn);
            cmd.RootTag = "ROOT";
            cmd.CommandText = "Employees";
            cmd.CommandType = SqlXmlCommandType.XPath;
            cmd.SchemaPath = $"{Application.StartupPath}\\employees.xsd";
            SqlXmlAdapter da = new SqlXmlAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText($"{Application.StartupPath}\\employees.xml");
            SqlXmlCommand cmd = new SqlXmlCommand(strConn);
            cmd.CommandType = SqlXmlCommandType.DiffGram;
            cmd.CommandText = reader.ReadToEnd();
            cmd.SchemaPath = $"{Application.StartupPath}\\employees.xsd";
            cmd.ExecuteNonQuery();
            MessageBox.Show("DiffGram updated to database successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter writer=File.CreateText($"{Application.StartupPath}\\employees.xml");
            ds.WriteXml(writer, XmlWriteMode.DiffGram);
            writer.Close();
        }

    }
}