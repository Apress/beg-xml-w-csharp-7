using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strConn= ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("select EmployeeID,FirstName,LastName from Employees", strConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "employees");
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
