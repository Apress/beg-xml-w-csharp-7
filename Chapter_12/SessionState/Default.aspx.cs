using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["timestamp"]==null)
        {
            Session["timestamp"] = DateTime.Now.ToString();
        }
        Label1.Text = Session["timestamp"].ToString();
    }
}