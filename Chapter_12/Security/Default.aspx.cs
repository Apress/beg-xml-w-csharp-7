using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.Security;

// You may need to install the following NuGet package
// to use C# 6 / C# 7 features :
// Microsoft.CodeDom.Providers.DotNetCompilerPlatform


public partial class _Default : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = $"Welcome {Page.User.Identity.Name}!";
            if (Request.IsAuthenticated)
            {
                Label2.Text = "You are an authenticated user.";
            }
        }

    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}