using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class ManageStationRequest : System.Web.UI.Page
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
            ds = db.discont("select File_Info.fname,rdate,StationName,req_id from [file_request],PoliceStation,File_Info where [d_or_P]='0' and PoliceStation.Username=file_request.[req_from] and File_Info.fid=file_request.fid and st='0'  and file_request.req_to in(select [stationAdmin] from [PoliceStation] where Username='" + Session["user"] + "')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string rid = ((Label)GridView1.Rows[e.RowIndex].Cells[4].FindControl("Label1")).Text;
            db.extnon("update file_request set st='1' where req_id='" + rid + "'");
            show_request();
            Response.Redirect("ManageStationRequest.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rid = ((Label)GridView1.Rows[e.RowIndex].Cells[4].FindControl("Label1")).Text;
            db.extnon("update file_request set st='2' where req_id='" + rid + "'");
            show_request();
            Response.Redirect("ManageStationRequest.aspx");
        }
    }
}