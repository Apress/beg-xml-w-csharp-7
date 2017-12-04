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


        private void Form1_Load(object sender, EventArgs e)
        {
            string strConn = @"Provider=SQLOLEDB;server=.;database=northwind;integrated security=SSPI";
            SqlXmlCommand cmd = new SqlXmlCommand(strConn);
            cmd.CommandType = SqlXmlCommandType.TemplateFile;
            cmd.CommandText = $"{Application.StartupPath}\\querytemplate.xml";
            DataSet ds = new DataSet();
            SqlXmlAdapter da = new SqlXmlAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

    }
}