using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.DistrictAdmin
{
    public partial class Index : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = db.extscalr("select Name from [districtAdmin] where username='"+Session["user"]+"'");
                Label1.Text = name;
            }
        }
    }
}