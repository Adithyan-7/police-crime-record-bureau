using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PoliceCrimeRecordBureau.Admin
{
    public partial class Manage_CaseCategory : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show_category();
            }
        }
        public void show_category()
        {

            ds = db.discont("select * from CaseCategory");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    DataSet ds3 = new DataSet();
                    string cat = ((Label)DataList1.Items[i].FindControl("Label1")).Text;
                    ds3 = db.discont("select des from CaseCategory where Category='" + cat + "'");
                    ((DataList)DataList1.Items[i].FindControl("DataList2")).DataSource = ds3;

                    ((DataList)DataList1.Items[i].FindControl("DataList2")).DataBind();

                    // ((Label)dt.Rows[0].Cells[0].FindControl("Label2")).Text = des;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string cat = db.extscalr("Select Category from [CaseCategory] where Category='" + TextBox1.Text + "'");
            if (cat == "")
            {
                bool b = db.extnon("insert into CaseCategory values('" + TextBox1.Text + "','" + TextBox2.Text + "')");
                TextBox2.Text = TextBox1.Text = "";
                show_category();
                ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Category Added ')</script>");

            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            DataList data = ((DataList)e.Item.FindControl("datalist2"));
            if (data.Visible == true)
            {
                data.Visible = false;
            }
            else
            {
                data.Visible = true;
            }
            // show_category();

        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            string cid=((Label)e.Item.FindControl("Label3")).Text;
            db.extnon("delete from [CaseCategory] where c_id='" + cid + "'");
            Response.Redirect("Manage_CaseCategory.aspx");
        }
    }
}