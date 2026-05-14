using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Login_login : System.Web.UI.Page
{
    PoliceCrimeRecordBureau.DbConnect db=new PoliceCrimeRecordBureau.DbConnect();
    PoliceCrimeRecordBureau.mail m = new PoliceCrimeRecordBureau.mail();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string val = db.extscalr("select type from login where username='"+TextBox1.Text+"' and password='" + TextBox2.Text + "'");
        if (val != "")
        {
            switch (val)
            {
                case "0":
                    Session["user"] = TextBox1.Text;
                    Response.Redirect("~/Admin/Home.aspx");
                    break;
                case "1":
                    Session["user"] = TextBox1.Text;
                    Session["redirectpath"] = "~/DistrictAdmin/Index.aspx";
                    string email = db.extscalr("select email from [districtAdmin] where username='"+TextBox1.Text+"'");
                   string otp= db.MakePwd(4);
                    Session["otp"] = otp;
                    m.sendMail(email, "Login Verification", "Your OneTime Password For Login is " + otp);
                    Response.Redirect("otpverification.aspx");
                    break;
                case "2":
                    Session["user"] = TextBox1.Text;
                    Session["redirectpath"] = "~/PoliceStation/Index.aspx";
                    string email1 = db.extscalr("select contact from [PoliceStation] where username='" + TextBox1.Text + "'");
                    string otp1 = db.MakePwd(4);
                    Session["otp"] = otp1;
                    m.sendMail(email1, "Login Verification", "Your OneTime Password For Login is " + otp1);
                    Response.Redirect("otpverification.aspx");
                    break;
                default:
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Invalid User')</script>");

                    break;
            }
        }

    }
}