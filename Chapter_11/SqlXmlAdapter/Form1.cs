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
            string sql = "select employeeid,firstname,lastname from employees for xml auto";
            SqlXmlCommand cmd = new SqlXmlCommand(strConn);
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            SqlXmlAdapter da = new SqlXmlAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

    }
}