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

        DataSet ds = new DataSet();
        SqlXmlAdapter da;
        SqlXmlCommand cmd;
        string strConn = @"Provider=SQLOLEDB;server=.;database=northwind;integrated security=SSPI";

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd = new SqlXmlCommand(strConn);
            cmd.RootTag = "ROOT";
            cmd.CommandText = "Employees";
            cmd.CommandType = SqlXmlCommandType.XPath;
            cmd.SchemaPath = $"{Application.StartupPath}\\employees.xsd";
            ds = new DataSet();
            da = new SqlXmlAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da.Update(ds);
        }

    }
}