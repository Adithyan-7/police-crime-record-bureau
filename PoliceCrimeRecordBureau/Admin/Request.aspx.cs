using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PoliceCrimeRecordBureau.Admin
{
    public partial class Request : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DbConnect db = new DbConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ds = db.discont("select * from file_request");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        string rfrom = ((Label)GridView1.Rows[i].Cells[0].FindControl("Label3")).Text;
                        string rto = ((Label)GridView1.Rows[i].Cells[0].FindControl("Label1")).Text;
                        string req_from = db.extscalr("select StationName from PoliceStation where StationAdmin='" + rfrom + "'");
                        string req_to = db.extscalr("select StationName from PoliceStation where StationAdmin='" + rto + "'");
                        ((Label)GridView1.Rows[i].Cells[0].FindControl("Label4")).Text = req_from;
                        ((Label)GridView1.Rows[i].Cells[0].FindControl("Label2")).Text = req_to;

                    }
                }
            }
        }
    }
}