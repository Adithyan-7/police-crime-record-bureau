using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.DistrictAdmin
{
    public partial class ManageCases : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        cryptography crypto = new cryptography();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show_case(); filter_police(); showCategoryFiletr();
            }
        }
        public void show_case()
        {
            string did = db.extscalr("select District_id from districtAdmin where username='" + Session["user"] + "'");
            ds = db.discont("select * from File_Info where did='" + did + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }
        public void showCategoryFiletr()
        {
            ds = db.discont("select * from CaseCategory ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "Category";
                DropDownList2.DataValueField = "c_id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "Filter category");
            }

        }
        public void filter_police()
        {

            ds = db.discont("select [StationName],[stationCode] from PoliceStation where [District_Id] in(select [District_id] from [districtAdmin] where username='" + Session["user"] + "') ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "StationName";
                DropDownList1.DataValueField = "stationCode";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Filter PoliceStation");
            }

        }


        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Session["caseid"] = ((Label)e.Item.FindControl("Label2")).Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;
        }


        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            Session["caseid"] = ((Label)e.Item.FindControl("Label2")).Text;
            load_CaseFile();
            MultiView1.ActiveViewIndex = 1;

        }


        public void load_CaseFile()
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
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
            Response.Redirect("ManageCases.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string fname = ds.Tables[0].Rows[0]["fname"].ToString();
                string ekey = ds.Tables[0].Rows[0]["ekey"].ToString();


                string inputpath = Server.MapPath("~/PoliceStation/Documents/EncryptResult/" + fname + ".txt");
                string outputpath = Server.MapPath("~/PoliceStation/Documents/down/" + fname + ".txt");
                try
                {

                    //aws
                 //   AmazoneCloud aws = new AmazoneCloud();
                 //   aws.UploadToCloud(fname + ".txt", outputpath);

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

        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            ds = db.discont("select * from File_Info where fid='" + Session["caseid"] + "'");
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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                showCategoryFiletr();
                ds.Clear();


                string did = db.extscalr("select District_id from districtAdmin where username='" + Session["user"] + "'");
                ds = db.discont("select * from File_Info where did='" + did + "' and [p_code]='" + DropDownList1.SelectedValue + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = false;
                    DataList2.Visible = true;
                    DataList2.DataSource = ds;
                    DataList2.DataBind();
                }
            }
            else
            {
                string did = db.extscalr("select District_id from districtAdmin where username='" + Session["user"] + "'");
                ds = db.discont("select * from File_Info where did='" + did + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = true;
                    DataList2.Visible = false;
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string did = db.extscalr("select District_id from districtAdmin where username='" + Session["user"] + "'");
            ds = db.discont("select * from File_Info where did='" + did + "' and [p_code]='" + DropDownList1.SelectedValue + "' and category='"+DropDownList2.SelectedValue+"' ");
            if (ds.Tables[0].Rows.Count > 0)
             {
                DataList1.Visible = false;
                DataList2.Visible = true;
                DataList2.DataSource = ds;
                DataList2.DataBind();
             }
            else
            {
                DataList2.DataSource = null;
                DataList2.DataBind();
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string did = db.extscalr("select District_id from districtAdmin where username='" + Session["user"] + "'");
            ds = db.discont("select * from File_Info where did='" + did + "' and [p_code]='" + DropDownList1.SelectedValue + "' and isActive='" + DropDownList3.SelectedValue + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.Visible = false;
                DataList2.Visible = true;
                DataList2.DataSource = ds;
                DataList2.DataBind();
            }
            else
            {
                DataList2.DataSource = null;
                DataList2.DataBind();
            }
        }
    }
}