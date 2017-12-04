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
            cmd.CommandText = "select EmployeeID,FirstName,LastName from employees for xml auto";
            cmd.RootTag = "root";
            cmd.XslPath = $"{Application.StartupPath}\\employees.xslt";
            StreamWriter writer = File.CreateText($"{Application.StartupPath}\\sqlxmlresults.htm");
            cmd.ExecuteToStream(writer.BaseStream);
            writer.Close();
            webBrowser1.Navigate($"{Application.StartupPath}\\sqlxmlresults.htm");
        }
    }
}