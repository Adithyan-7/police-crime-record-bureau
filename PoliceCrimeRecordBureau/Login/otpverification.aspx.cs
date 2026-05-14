using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.Login
{
    public partial class otpverification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == Session["otp"].ToString())
            {
                Response.Redirect(Session["redirectpath"].ToString());
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Incorrect OTP Please Try Again')</script>");
            }
        }
    }
}