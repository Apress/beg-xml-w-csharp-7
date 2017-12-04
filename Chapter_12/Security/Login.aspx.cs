using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if(Login1.UserName=="admin" && Login1.Password=="password")
        {
            FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
            e.Authenticated = true;
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }
        else
        {
            e.Authenticated = false;
        }
    }
}