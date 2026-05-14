using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.DistrictAdmin
{
    public partial class ManageDistrictRequest : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                show_request();
            }
        }
        public void show_request()
        {
            ds = db.discont("select File_Info.fname,rdate,StationName,req_from_dis,req_id from file_request,PoliceStation,File_Info where d_or_P='" + 1 + "' and PoliceStation.Username=file_request.req_from and File_Info.fid=file_request.fid and st='0' and file_request.[req_to_dis] in(select [District_id] from [districtAdmin] where username='" + Session["user"] + "' ) ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string did = ((Label)GridView1.Rows[i].Cells[4].FindControl("Label2")).Text;
                    string dname = db.extscalr("select DistrictName From Districts where DistrictId='" + did + "' ");
                    ((Label)GridView1.Rows[i].Cells[4].FindControl("Label3")).Text = dname;

                }
            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string rid = ((Label)GridView1.Rows[e.RowIndex].Cells[4].FindControl("Label1")).Text;
            db.extnon("update file_request set st='1' where req_id='" + rid + "'");
            show_request();
            Response.Redirect("ManageDistrictRequest.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rid = ((Label)GridView1.Rows[e.RowIndex].Cells[4].FindControl("Label1")).Text;
            db.extnon("update file_request set st='2' where req_id='" + rid + "'");
            show_request();
            Response.Redirect("ManageDistrictRequest.aspx");
        }
    }
}