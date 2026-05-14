using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class RequestStatus : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        cryptography crypto = new cryptography();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                show_case();
        }
        public void show_case()
        {

            ds = db.discont("select File_Info.fname,file_request.fid,st,req_id from file_request,File_Info where req_from='" + Session["user"] + "' and st!=0 and File_Info.fid=file_request.fid");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    string fid = ((Label)DataList1.Items[i].FindControl("Label2")).Text;
                    string rid = ((Label)DataList1.Items[i].FindControl("Label7")).Text;
                    string st = db.extscalr("select st from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "' and req_id='" + rid + "'");
                    if (st == "1")
                    {
                        ((Button)DataList1.Items[i].FindControl("Button2")).Visible = true;

                        ((Label)DataList1.Items[i].FindControl("Label3")).Visible = false;

                    }
                    else if (st == "2")
                    {
                        ((Button)DataList1.Items[i].FindControl("Button2")).Visible = false;

                        ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;
                        ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected";
                    }

                }
            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Session["fid"] = ((Label)e.Item.FindControl("Label2")).Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;

        }
        public void load_CaseFile()
        {
            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = db.extscalr("select Category from CaseCategory where c_id='" + ds.Tables[0].Rows[0]["category"] + "'");
                Image2.ImageUrl = ds.Tables[0].Rows[0]["CulpritImage"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["CulpritName"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["des"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["udate"].ToString();

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestStatus.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string fname = ds.Tables[0].Rows[0]["fname"].ToString();
                string ekey = ds.Tables[0].Rows[0]["ekey"].ToString();


                string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ".txt");
                string outputpath = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ".txt");
                try
                {
                    //aws
                   // AmazoneCloud aws = new AmazoneCloud();
                   // aws.UploadToCloud(fname + ".txt", outputpath);


                    crypto.MultimediaDecrypt(inputpath, outputpath, ekey);

                    try
                    {
                        WebClient req = new WebClient();
                        HttpResponse response = HttpContext.Current.Response;
                        response.Clear();
                        response.ClearContent();
                        response.ClearHeaders();
                        response.Buffer = true;
                        response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(outputpath));
                        Response.WriteFile(outputpath);

                        Response.Flush();
                        response.End();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script Language=JavaScript>alert('something Wents Wrong!!')</Script>");

                }


            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["fid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                string image = ds.Tables[0].Rows[0]["culpritImage"].ToString();

                try
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(image));
                    Response.WriteFile(image);

                    Response.Flush();
                    response.End();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}