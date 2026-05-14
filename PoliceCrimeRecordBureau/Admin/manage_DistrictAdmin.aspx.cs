using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PoliceCrimeRecordBureau.Admin
{
    public partial class manage_DistrictAdmin : System.Web.UI.Page
    {
        DbConnect db = new DbConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dist_load();
                load_AdminList();
            }
        }

        public void load_AdminList()
        {


            ds.Clear();
            ds = db.discont("select Name,email,Phn,DistrictName,Da_id from Districts,districtAdmin where Districts.DistrictId=districtAdmin.District_id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        public void dist_load()
        {
            ds = db.discont1("Select * from Districts where districtId not in(select District_id from districtAdmin)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "DistrictId";
                DropDownList1.DataTextField = "DistrictName";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "**Choose District**");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = db.extscalr("Select username from Login where username='" + TextBox4.Text + "'");
            if (username == "")
            {
                bool a = db.extnon("insert into districtAdmin values('" + DropDownList1.SelectedValue + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox4.Text + "')");
                bool b = db.extnon("insert into Login values('" + TextBox4.Text + "','" + TextBox5.Text + "','" + '1' + "')");
                if (a == true && b == true)
                {
                    dist_load();
                    TextBox1.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text = TextBox7.Text = TextBox8.Text = "";
                    load_AdminList();
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script>alert('Registration Successfull')</script>");
                }
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           string did= ((Label)GridView1.Rows[e.RowIndex].Cells[5].FindControl("Label2")).Text;
            Session["da_id"] = did;

            ds = db.discont("select * from [districtAdmin] where  Da_id='"+did+"'");
            if (ds.Tables[0].Rows.Count>0)
            {
                //dist_load();
                DropDownList1.SelectedItem.Text = GridView1.Rows[e.RowIndex].Cells[0].Text;
                TextBox6.Text= ds.Tables[0].Rows[0]["Name"].ToString();
                TextBox7.Text = ds.Tables[0].Rows[0]["email"].ToString();
                TextBox8.Text = ds.Tables[0].Rows[0]["phn"].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0]["username"].ToString();
                TextBox7.ReadOnly = true;

                TextBox5.Visible = false;
                TextBox1.Visible = false;
                Button1.Visible = false;
                Button2.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            db.extnon("update districtAdmin set Name='"+TextBox6.Text+"',email='"+TextBox7.Text+"',phn='"+TextBox8.Text+"',username='"+TextBox4.Text+"' where Da_id='"+Session["da_id"]+"'");

            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox4.Text ="";
            TextBox7.ReadOnly = false;

            TextBox5.Visible = true;
            TextBox1.Visible = true;
            Button1.Visible = true;
            Button2.Visible = false;
            dist_load();
            load_AdminList();

        }

        public bool CHECK(string input)
        {
            Label3.Visible = false;

            if ((input.Length < 8) || (input.Length > 10))
            {
                Label3.Visible = true;
                return false;


            }
            else if (!input.Contains('A') && !input.Contains('B') && !input.Contains('C') && !input.Contains('D') && !input.Contains('E') && !input.Contains('F') && !input.Contains('G') && !input.Contains('H') && !input.Contains('I') && !input.Contains('J') && !input.Contains('K') && !input.Contains('L') && !input.Contains('M') && !input.Contains('N') && !input.Contains('O') && !input.Contains('P') && !input.Contains('Q') && !input.Contains('R') && !input.Contains('S') && !input.Contains('T') && !input.Contains('U') && !input.Contains('V') && !input.Contains('W') && !input.Contains('X') && !input.Contains('Y') && !input.Contains('Z'))
            {
                Label3.Visible = true;
                return false;
            }
            else if (!input.Contains('a') && !input.Contains('b') && !input.Contains('c') && !input.Contains('d') && !input.Contains('e') && !input.Contains('f') && !input.Contains('g') && !input.Contains('h') && !input.Contains('i') && !input.Contains('j') && !input.Contains('k') && !input.Contains('l') && !input.Contains('m') && !input.Contains('n') && !input.Contains('o') && !input.Contains('p') && !input.Contains('q') && !input.Contains('r') && !input.Contains('s') && !input.Contains('t') && !input.Contains('u') && !input.Contains('v') && !input.Contains('w') && !input.Contains('x') && !input.Contains('y') && !input.Contains('z'))
            {
                Label3.Visible = true;
                return false;
            }
            else if (!input.Contains('1') && !input.Contains('2') && !input.Contains('3') && !input.Contains('4') && !input.Contains('5') && !input.Contains('6') && !input.Contains('7') && !input.Contains('8') && !input.Contains('9') && !input.Contains('0'))
            {
                Label3.Visible = true;
                return false;
            }
            else if (!input.Contains('!') && !input.Contains('~') && !input.Contains('@') && !input.Contains('#') && !input.Contains('%') && !input.Contains('$') && !input.Contains('^') && !input.Contains('&') && !input.Contains('*') && !input.Contains('(') && !input.Contains(')') && !input.Contains('_'))
            {
                Label3.Visible = true;
                return false;
            }
            else
            {
                return true;
            }

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            Label3.Visible = false;
            bool b = CHECK(TextBox5.Text);
            if (b == false)
            {
                Label3.Visible = true;
               // TextBox5.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                   if( TextBox5.Text!=TextBox1.Text)
                {
                    Label3.Text = "Password not matching";
                }
            }
        }
    }
}