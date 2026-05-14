using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class Index : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string pil_name = db.extscalr("select StationName from [PoliceStation] where username='" + Session["user"] + "'");
                string dist = db.extscalr("select DistrictName from Districts where DistrictId in(select District_Id from [PoliceStation] where username='" + Session["user"] + "')");
                Label1.Text = "Welcome " + pil_name + " " + dist;

                ds = db.discont("select * from PoliceStation where username='" + Session["user"] + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Image1.ImageUrl = ds.Tables[0].Rows[0]["image"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["StationAdmin"].ToString();
                    Label3.Text = ds.Tables[0].Rows[0]["contact"].ToString();
                }
                show();

            }
        }
        public void show()
        {


            ds = db.discont("select * from [CaseCategory]");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = new DataSet();
                    string id = ((Label)DataList1.Items[i].FindControl("Label5")).Text;
                    ds1 = db.discont("select des from CaseCategory where c_id='" + id + "'");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ((GridView)DataList1.Items[i].FindControl("GridView1")).DataSource = ds1;
                        ((GridView)DataList1.Items[i].FindControl("GridView1")).DataBind();
                    }
                }
            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            ((GridView)e.Item.FindControl("GridView1")).Visible = true;
            ((LinkButton)e.Item.FindControl("LinkButton1")).Visible = false;
            ((LinkButton)e.Item.FindControl("LinkButton2")).Visible = true;
        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            ((GridView)e.Item.FindControl("GridView1")).Visible = false;
            ((LinkButton)e.Item.FindControl("LinkButton1")).Visible = true;
            ((LinkButton)e.Item.FindControl("LinkButton2")).Visible = false;
        }
    }
}