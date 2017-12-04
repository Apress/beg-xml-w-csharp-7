using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        string host = ConfigurationManager.AppSettings["host"];
        string email = ConfigurationManager.AppSettings["email"];

        SmtpClient client = new SmtpClient(host);
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(TextBox2.Text);
        msg.To.Add(email);
        msg.Subject = TextBox3.Text;
        msg.Body = "[" + DropDownList1.SelectedItem.Text + "]" + TextBox4.Text + "\r\n" + TextBox1.Text + "\r\n" + TextBox5.Text;
        client.Send(msg);
        Label9.Text = "Your message has been sent. Thank you!";
    }
}
