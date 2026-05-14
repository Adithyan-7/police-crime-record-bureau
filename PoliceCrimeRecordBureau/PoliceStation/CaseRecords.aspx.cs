using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliceCrimeRecordBureau.PoliceStation
{
    public partial class CaseRecords : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show_case();
                show_dis();
            }
        }
        public void show_dis()
        {
            ds.Clear();
            ds = db.discont("select * from [Districts]");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "DistrictName";
                DropDownList1.DataValueField = "DistrictId";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Filter By District");
            }
        }
        public void show_case()
        {
            string stcode = db.extscalr("select [stationCode] from [PoliceStation] where Username='" + Session["user"] + "' ");
            ds = db.discont("select * from [File_Info] where p_code!='" + stcode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    string fid = ((Label)DataList1.Items[i].FindControl("Label2")).Text;
                    string count = db.extscalr("select count(st) from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "'");
                    if (count != "0")
                    {
                        string st = db.extscalr("select st from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "' order by req_id desc ");
                        if (st == "0")
                        {
                            ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                            ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                            ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                        }
                        //if (st == "2")
                        //{
                        //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                        //    ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                        //    ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                        //}
                        //if (st == "1")
                        //{
                        //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                        //    //((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                        //    ((Button)DataList1.Items[i].FindControl("Button2")).Visible = true;

                        //}
                    }
                    else
                    {
                        ((Button)DataList1.Items[i].FindControl("Button1")).Visible = true;
                        // ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                        ((Label)DataList1.Items[i].FindControl("Label3")).Visible = false;

                    }

                }
            }


        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            string fid = ((Label)e.Item.FindControl("Label2")).Text;
            ds = db.discont("select * from File_Info where fid='" + fid + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string stationstatus = "";
                string req_to_dis = ds.Tables[0].Rows[0]["did"].ToString();
                string req_from = Session["user"].ToString();
                string req_to_st = db.extscalr("select stationAdmin from PoliceStation where stationCode='" + ds.Tables[0].Rows[0]["p_code"].ToString() + "'");

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string req_from_dis = db.extscalr("select [District_Id] from PoliceStation where StationCode in(select StationCode from PoliceStation where Username='" + Session["user"] + "')");
                if (req_to_dis == req_from_dis)
                {
                    stationstatus = "0";
                }
                else
                {
                    stationstatus = "1";
                }
                bool a = db.extnon("insert into [file_request] values('" + req_to_st + "','" + req_from + "','" + req_to_dis + "','" + req_from_dis + "','" + fid + "','" + date + "','" + stationstatus + "','" + 0 + "')");
                if (a == true)
                {
                    show_case();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {


                ds = db.discont("select * from [File_Info] where did='" + DropDownList1.SelectedValue + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = true;
                    Panel1.Visible = false;
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    for (int i = 0; i < DataList1.Items.Count; i++)
                    {
                        string fid = ((Label)DataList1.Items[i].FindControl("Label2")).Text;
                        string count = db.extscalr("select count(st) from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "'");
                        if (count != "0")
                        {
                            string st = db.extscalr("select st from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "' order by req_id desc ");
                            if (st == "0")
                            {
                                ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                                ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                                ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                            }
                            //if (st == "2")
                            //{
                            //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                            //    ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                            //    ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                            //}
                            //if (st == "1")
                            //{
                            //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                            //    //((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                            //    ((Button)DataList1.Items[i].FindControl("Button2")).Visible = true;

                            //}
                        }
                        else
                        {
                            ((Button)DataList1.Items[i].FindControl("Button1")).Visible = true;
                            // ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                            ((Label)DataList1.Items[i].FindControl("Label3")).Visible = false;

                        }

                    }
                }
                else
                {
                    DataList1.Visible = false;
                    Panel1.Visible = true;
                }

                ds.Clear();
                ds = db.discont("select * from [PoliceStation] where [District_Id]='" + DropDownList1.SelectedValue + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "StationName";
                    DropDownList2.DataValueField = "stationCode";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, "Filter By District");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Invalid District')</script>");
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex != 0)
            {


                ds = db.discont("select * from [File_Info] where did='" + DropDownList1.SelectedValue + "' and p_code='" + DropDownList2.SelectedValue + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.Visible = true;
                    Panel1.Visible = false;
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    for (int i = 0; i < DataList1.Items.Count; i++)
                    {
                        string fid = ((Label)DataList1.Items[i].FindControl("Label2")).Text;
                        string count = db.extscalr("select count(st) from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "'");
                        if (count != "0")
                        {
                            string st = db.extscalr("select st from [file_request] where [req_from]='" + Session["user"] + "' and fid='" + fid + "' order by req_id desc ");
                            if (st == "0")
                            {
                                ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                                ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                                ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                            }
                            //if (st == "2")
                            //{
                            //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                            //    ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                            //    ((Label)DataList1.Items[i].FindControl("Label3")).Visible = true;

                            //}
                            //if (st == "1")
                            //{
                            //    ((Button)DataList1.Items[i].FindControl("Button1")).Visible = false;
                            //    //((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Rejected!..";
                            //    ((Button)DataList1.Items[i].FindControl("Button2")).Visible = true;

                            //}
                        }
                        else
                        {
                            ((Button)DataList1.Items[i].FindControl("Button1")).Visible = true;
                            // ((Label)DataList1.Items[i].FindControl("Label3")).Text = "Request Waiting!..";
                            ((Label)DataList1.Items[i].FindControl("Label3")).Visible = false;

                        }

                    }
                }
                else
                {
                    DataList1.Visible = false;
                    Panel1.Visible = true;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Invalid Police Station')</script>");

            }
        }
    }
}