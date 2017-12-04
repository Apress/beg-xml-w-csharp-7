using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace WindowsApplication35
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
                MessageBox.Show("Please specify SELECT query");
                return;
            }
            
            SqlConnection cnn = new SqlConnection(@"data source=.;initial catalog=northwind;integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"{textBox1.Text} FOR XML AUTO";
            cnn.Open();
            XmlReader reader=cmd.ExecuteXmlReader();
            StreamWriter writer= File.CreateText($"{Application.StartupPath}\\temp.xml");
            writer.Write("<root>");
            while (reader.Read())
            {
                writer.Write(reader.ReadOuterXml());
            }
            writer.Write("</root>");
            writer.Close();
            reader.Close();
            cnn.Close();
            Process.Start($"{Application.StartupPath}\\temp.xml");
        }
    }
}